using System.Linq;
using AutoMapper;
using datingapp.API.Dtos;
using datingapp.API.Models;

namespace datingapp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                    .ForMember(dest => dest.Age, opt => 
                        opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.PhotoUrl, opt => 
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.Age, opt =>
                opt.MapFrom(src => src.DateOfBirth.CalculateAge()))    ;
            CreateMap<Photo, PhotosForDetailedDto>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto, Photo>();  
            CreateMap<UserForRegisterDto, User>();  
            CreateMap<TaskToCreate, Tasks>().ReverseMap();
            CreateMap<TaskToUpdate, Tasks>();
            CreateMap<CommentsToCreate, Comments>().ReverseMap();
            CreateMap<MessageForCreationDto, Message>().ReverseMap();
            CreateMap<Message, MessageToReturnDto>()
                    .ForMember(m => m.SenderPhotoUrl, opt => opt 
                        .MapFrom(u => u.Sender.Photos.FirstOrDefault(p => p.IsMain).Url))
                    .ForMember(m => m.RecipientPhotoUrl, opt => opt 
                        .MapFrom(u => u.Recipient.Photos.FirstOrDefault(p => p.IsMain).Url));    
                         
            }
    }
}