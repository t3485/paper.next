using AutoMapper;
using Paper.Papers;
using Paper.Papers.MA;

namespace Paper
{
    public class PaperApplicationAutoMapperProfile : Profile
    {
        public PaperApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateInputMap();
        }

        private void CreateInputMap()
        {
            CreateMap<IndustryWheelRequestDto, PagedPaperRequestDto>();
            CreateMap<Point, PointDto>(); 
        }
    }
}
