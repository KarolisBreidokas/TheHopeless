using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheHopeless.API.Constants
{
    public static class MimeTypeBuilder
    {
        private static readonly IDictionary<MimeType,string> dictionary=new Dictionary<MimeType, string>()
        {
            {MimeType.Gif,"image/gif"},
            {MimeType.Png,"image/png"},
            {MimeType.Jpeg,"image/jpeg"},
            {MimeType.Bmp,"image/bmp"},
            {MimeType.Webp,"image/webp"},
        };

        public static MimeType GeMimeType(string type)
        {
            var t= dictionary.FirstOrDefault(x => x.Value == type);
            if (t.Key ==MimeType.NA)
            {
                
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return t.Key;
        }
        public static string GetString(this MimeType type)
        {

            if (dictionary[type] is null)
            {
                
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return dictionary[type];
        }
    }
}
