﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using TheHopeless.API.Contracts.ProductController;
using TheHopeless.API.Database.Entities.ProductControl;

namespace TheHopeless.API.Services
{
    public interface IPictureService
    {
        Task<Picture> GetPicture(int id);
        Task<PictureDto> PostPicture(int productId,bool main,IFileInfo info);
        Task DeletePicure(int id);
    }
}
