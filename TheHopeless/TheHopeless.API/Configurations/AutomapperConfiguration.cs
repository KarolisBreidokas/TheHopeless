using AutoMapper;
using System.Linq;
using TheHopeless.API.Contracts.ProductController;
using TheHopeless.API.Database.Entities.ProductControl;
using Attribute = TheHopeless.API.Database.Entities.ProductControl.Attribute;

namespace TheHopeless.API.Configurations
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration() : this("AcademyDemo")
        {

        }
        protected AutomapperConfiguration(string name) : base(name)
        {
            CreateMap<Product, ProductDto>(MemberList.None)
                .ForMember(x => x.Attributes, opt => opt.MapFrom(y => y.Values))
                .ForMember(x => x.Picture,
                    opt => opt.MapFrom(y => y.Pictures.Select(z => new PictureDto() { PictureId = z.Id })));
            CreateMap<ProductAttribute, ProductAttributeDto>(MemberList.None);
            CreateMap<Attribute, AttributeDto>(MemberList.None);
            CreateMap<NewProductDto, Product>(MemberList.None)
                .ForMember(x => x.Values, opt => opt.MapFrom(y => y.Attributes));
            CreateMap<NewProductAttributeDto, ProductAttribute>(MemberList.None)
                .ForMember(x => x.Attribute, opt => opt.MapFrom(y => new Attribute() { Name = y.Name }));
            CreateMap<AttributeDto, Attribute>(MemberList.None);
        }


    }
}
