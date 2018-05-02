using System;
using PSC.Xamarin.MvvmHelpers;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FitnessApp
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

