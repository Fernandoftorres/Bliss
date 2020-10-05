using AutoMapper;
using BlissRecruitment.Application.ViewModels;
using BlissRecruitment.Domain.Models;

namespace BlissRecruitment.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<QuestionChoice, QuestionChoiceViewModel>();
            CreateMap<Question, QuestionViewModel>()
                .ForMember(x => x.id, m => m.MapFrom(f => f.Id))
                .ForMember(x => x.question, m => m.MapFrom(f => f.QuestionDescription))
                .ForMember(x => x.image_url, m => m.MapFrom(f => f.ImageUrl))
                .ForMember(x => x.thumb_url, m => m.MapFrom(f => f.ThumbUrl))
                .ForMember(x => x.published_at, m => m.MapFrom(f => f.PublishedAt))
                .ForMember(x => x.Choices, m => m.MapFrom(f => f.QuestionChoices));
            
        }
    }
}
