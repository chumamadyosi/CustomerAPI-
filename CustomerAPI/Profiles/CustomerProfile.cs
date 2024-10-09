using AutoMapper;
using CustomerAPI.Data;
using CustomerAPI.Dtos;

namespace CustomerAPI.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerReadDto>();
            CreateMap<CustomerCreateDto, Customer>().
                ForMember(m => m.CreatedAt, o => o.MapFrom(s => DateTime.Now.Date));
        }
    }
}

