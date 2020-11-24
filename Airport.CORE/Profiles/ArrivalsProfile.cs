using AutoMapper;

namespace Airport.CORE.Profiles
{
    public class ArrivalsProfile : Profile
    {
        public ArrivalsProfile()
        {
            CreateMap<Entities.Plane, Models.PlaneDto>();

            CreateMap<Models.PlaneForCreationDto, Entities.Plane>();
        }
    }
}
