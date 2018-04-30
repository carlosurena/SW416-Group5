using System;
using PSC.Xamarin.MvvmHelpers;
using Xamarin.Forms;

namespace FitnessApp.Models
{
    public class GalleryImage : ObservableObject
    {
        public GalleryImage()
        {
            ImageId = Guid.NewGuid();
        }

        public Guid ImageId
        {
            get;
            set;
        }

        public ImageSource Source
        {
            get;
            set;
        }

        public byte[] OrgImage
        {
            get;
            set;
        }

    }
}

