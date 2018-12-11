using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using TheHopeless.API.Constants;
using TheHopeless.API.Contracts.ProductController;
using TheHopeless.API.Database;
using TheHopeless.API.Database.Entities.ProductControl;

namespace TheHopeless.API.Services.Implementations
{
    public class PictureService:IPictureService
    {
        private readonly EshopDbContext _context;
        private readonly DbSet<Picture> _pictures;
        private readonly IMapper _mapper;

        public PictureService(EshopDbContext context, IMapper mapper)
        {
            _pictures = context.Pictures;
            _context = context;
            _mapper = mapper;
        }

        public async Task<Picture> GetPicture(int id)
        {
            var entity = await _pictures.FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public async Task<PictureDto> PostPicture(int productId, bool main,MimeType type, Stream info)
        {
            var picture = new Picture
            {
                Main = main,
                Type = type,
                ProductId = productId
            };
            using(var memoryStream = new MemoryStream())
            {
                
                info.CopyTo(memoryStream);
                picture.Data=memoryStream.ToArray();
            }

            _pictures.Add(picture);
             await _context.SaveChangesAsync();
            return _mapper.Map<PictureDto>(picture);
        }

        public async Task<bool> DeletePicure(int id)
        {
            var entity = await _pictures.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null)
            {
                return false;
            }
            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
