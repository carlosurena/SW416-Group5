﻿using System;
using System.Windows.Input;
using Xamarin.Forms;
using Plugin.Media;
using System.Threading.Tasks;
using System.IO;
using FitnessApp.Models;
using System.Collections.ObjectModel;
using Plugin.Media.Abstractions;
using System.Linq;
using PSC.Xamarin.MvvmHelpers;
using FitnessApp.Services;


namespace FitnessApp.ViewModels
{
    public class ProtectedViewModel : BaseViewModel
    {
        ICommand _cameraCommand, _previewImageCommand = null;
        ObservableCollection<GalleryImage> _images = new ObservableCollection<GalleryImage>();
        ImageSource _previewImage = null;

        public ProtectedViewModel()
        {
         
        }

        public ObservableCollection<GalleryImage> Images
        {
            get { return _images; }
        }

        public ImageSource PreviewImage
        {
            get { return _previewImage; }
            set
            {
                SetProperty(ref _previewImage, value);
            }
        }

        public ICommand CameraCommand
        {
            get { return _cameraCommand ?? new Command(async () => await ExecuteCameraCommand(), () => CanExecuteCameraCommand()); }
        }

        public bool CanExecuteCameraCommand()
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                return false;
            }
            return true;
        }

        public async Task ExecuteCameraCommand()
        {
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions { PhotoSize = PhotoSize.Small });

            if (file == null)
                return;


            byte[] imageAsBytes = null;
            using (var memoryStream = new MemoryStream())
            {
                file.GetStream().CopyTo(memoryStream);
                file.Dispose();
                imageAsBytes = memoryStream.ToArray();
            }

            var resizer = DependencyService.Get<IImageResize>();

            imageAsBytes = resizer.ResizeImage(imageAsBytes, 1080, 1080);

            var imageSource = ImageSource.FromStream(() => new MemoryStream(imageAsBytes));

            _images.Add(new GalleryImage { Source = imageSource, OrgImage = imageAsBytes });


            return;
        }

        public ICommand PreviewImageCommand
        {
            get
            {
                return _previewImageCommand ?? new Command<Guid>((img) => {

                    var image = _images.Single(x => x.ImageId == img).OrgImage;

                    PreviewImage = ImageSource.FromStream(() => new MemoryStream(image));

                });
            }
        }
    }
}

