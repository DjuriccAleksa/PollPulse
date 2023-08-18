using AutoMapper;
using PollPulse.Common.DTO.ClosedQuestionOptionsDTOs;
using PollPulse.Common.DTO.OpenResponsesDTOs;
using PollPulse.Common.DTO.QuestionResponsesDTOs;
using PollPulse.Common.DTO.QuestionsDTOs;
using PollPulse.Common.DTO.SurveysDTOs;
using PollPulse.Common.DTO.UsersDTOs;
using PollPulse.Entities.Models;

namespace PollPulse.CommandsAndQueries.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserRegisterDTO, User>();
        CreateMap<User, UserDTO>();

        CreateMap<ClosedQuestionOption, ClosedQuestionOptionDTO>()
            .ReverseMap();
        CreateMap<OpenResponse, OpenResponseDTO>();
        CreateMap<QuestionResponse, QuestionResponseDTO>();

        CreateMap<Question,QuestionDTO>()
            .ForCtorParam("QuestionType",
            opt => opt.MapFrom(src => src.QuestionType.ToString()))
            .ReverseMap();

        CreateMap<Survey, SurveyDTO>()
            .ForCtorParam("TotalResponses",
            opt => opt.MapFrom(src => Convert.ToInt32(src.SurveyResponses.Count())));
        CreateMap<SurveyCreateDTO, Survey>();
        CreateMap<Survey, SurveyUpdateDTO>()
            .ReverseMap();
        
    }
}
