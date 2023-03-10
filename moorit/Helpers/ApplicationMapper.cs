using AutoMapper;
using Moorit.Data;
using Moorit.Models;

namespace Moorit.Helpers
{
    public class ApplicationMapper:Profile
    {

        public ApplicationMapper()
        {
            CreateMap<Booking, BookingModel>()
                .ForMember(dest => dest.Mooring, opt => opt.MapFrom(src => src.Mooring))
                .ForMember(dest => dest.ApplicationUserModelId, opt => opt.MapFrom(src => src.ApplicationUserModelId));
            CreateMap<Location, LocationModel>();
            CreateMap<Mooring, MooringModel>();
        }
    }
}
