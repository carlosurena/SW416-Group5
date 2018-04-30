using System;

namespace FitnessApp.Services
{
    public interface IImageResize
    {
        byte[] ResizeImage(byte[] imageData, float width, float height);
    }
}

