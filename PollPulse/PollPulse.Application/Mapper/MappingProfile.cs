using AutoMapper;
using PollPulse.Common.DTO.ClosedQuestionOptionsDTOs;
using PollPulse.Common.DTO.QuestionResponsesDTOs;
using PollPulse.Common.DTO.QuestionsDTOs;
using PollPulse.Common.DTO.SelectedOptionsDTOs;
using PollPulse.Common.DTO.SurveyResponsesDTOs;
using PollPulse.Common.DTO.SurveysDTOs;
using PollPulse.Common.DTO.UsersDTOs;
using PollPulse.Entities.Models;

namespace PollPulse.Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserRegisterDTO, User>();
        CreateMap<User, UserDTO>();

        CreateMap<ClosedQuestionOption, ClosedQuestionOptionDTO>()
            .ForCtorParam("ClosedQuestionOptionId",
            opt => opt.MapFrom(src => src.Id))
            .ReverseMap();

        CreateMap<QuestionResponse, QuestionResponseDTO>();
        CreateMap<SelectedOption, SelectedOptionDTO>();

        CreateMap<Question, QuestionDTO>()
            .ForCtorParam("QuestionType",
            opt => opt.MapFrom(src => src.QuestionType.ToString()))
            .ReverseMap();

        CreateMap<QuestionCreateDTO, Question>();

        CreateMap<Survey, SurveyDTO>()
            .ForCtorParam("TotalResponses",
                opt => opt.MapFrom(src => src.SurveyResponses.Count())
            );

        CreateMap<SurveyCreateDTO, Survey>();
        CreateMap<Survey, SurveyUpdateDTO>()
            .ReverseMap();

        CreateMap<SurveyResponseCreateDTO, SurveyResponse>()
            .ForMember("QuestionResponses", opt => opt.Ignore());

        CreateMap<SurveyResponse, SurveyResponseDTO>();

        CreateMap<QuestionResponseCreateDTO, QuestionResponse>();
        CreateMap<SelectedOptionCreateDTO, SelectedOption>();
    }
}
