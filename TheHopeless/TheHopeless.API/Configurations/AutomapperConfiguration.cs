using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TheHopeless.API.Contracts.ProductController;
using TheHopeless.API.Contracts.RentalController;
using TheHopeless.API.Database.Entities.ProductControl;
using TheHopeless.API.Database.Entities.RentalControl;
using Attribute = TheHopeless.API.Database.Entities.ProductControl.Attribute;

namespace TheHopeless.API.Configurations
{
    public class AutomapperConfiguration:Profile
    {
        public AutomapperConfiguration() : this("AcademyDemo")
        {

        }
        protected AutomapperConfiguration(string name) : base(name)
        {
            CreateMap<Product, ProductDto>(MemberList.None)
                .ForMember(x => x.Attributes, opt => opt.MapFrom(y => y.Values))
                .ForMember(x => x.Picture,
                    opt => opt.MapFrom(y => y.Pictures.Select(z => new PictureDto() {PictureId = z.Id})));
            CreateMap<ProductAttribute, ProductAttributeDto>(MemberList.None);
            CreateMap<Attribute, AttributeDto>(MemberList.None);
            CreateMap<RentalAgreement, RentalAgreementDto>(MemberList.None);
            CreateMap<RentalPaymentType, RentalPaymentTypeDto>(MemberList.None);
        }


    }
}
