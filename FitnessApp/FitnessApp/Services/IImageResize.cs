using System;

namespace FitnessApp
{
    public interface IImageResize
    {
        byte[] ResizeImage(byte[] imageData, float width, float height);
    }
}

