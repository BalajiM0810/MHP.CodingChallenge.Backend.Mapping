using System;

namespace MHP.CodingChallenge.Backend.Mapping.Data.DTO
{
    public class ImageDto
    {
        public String Url
        {
            get; set;
        }
        public ImageSizeDto ImageSize
        {
            get; set;
        }
    }
}