using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheHopeless.API.Constants
{
    public static class MimeTypeBuilder
    {
        public static string GetString(this MimeType type)
        {
            switch (type)
            {
                case MimeType.Gif:
                    return "Image/Gif";
                case MimeType.Png:
                    return "Image/Png";
                case MimeType.Jpeg:
                    return "Image/Jpeg";
                case MimeType.Bmp:
                    return "Image/Bmp";
                case MimeType.Webp:
                    return "Image/Webp";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
