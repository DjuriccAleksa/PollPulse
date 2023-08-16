using AutoMapper;
using PollPulse.Common.DTO;
using PollPulse.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.CommandsAndQueries.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterDTO, User>();
            CreateMap<User, UserDTO>();

            CreateMap<ClosedAnswer, ClosedAnswerDTO>()
                .ReverseMap();
            CreateMap<OpenedAnswer, OpenedAnswerDTO>();
            CreateMap<GivenAnswer, GivenAnswerDTO>();

            CreateMap<Question,QuestionDTO>()
                .ForCtorParam("QuestionType",
                opt => opt.MapFrom(src => src.QuestionType.ToString()))
                .ReverseMap();

            CreateMap<Survey, SurveyDTO>()
                .ForCtorParam("TotalResponses",
                opt => opt.MapFrom(src => (src.Questions.Any() && src.Questions.First().GivenAnswers != null) ? src.Questions.First().GivenAnswers.Count : 0));
            CreateMap<SurveyCreateDTO, Survey>()
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions));
            CreateMap<Survey, SurveyUpdateDTO>()
                .ReverseMap();
            
        }
    }
}
