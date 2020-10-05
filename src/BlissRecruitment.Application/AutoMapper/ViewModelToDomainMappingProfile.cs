using AutoMapper;
using BlissRecruitment.Application.ViewModels;
using BlissRecruitment.Domain.Commands;
using BlissRecruitment.Domain.Models;
using System.Linq;

namespace BlissRecruitment.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {            
            CreateMap<RegisterQuestionViewModel, RegisterNewQuestionCommand>()
                .ConstructUsing(c => new RegisterNewQuestionCommand(c.question, c.image_url, c.thumb_url, c.choices));
            
            CreateMap<UpdateQuestionViewModel, UpdateQuestionCommand>()
                .ConstructUsing(c => new UpdateQuestionCommand(c.id, c.question, c.image_url, c.thumb_url, 
                c.Choices.Select(x => new QuestionChoice(0,0, x.Choice, x.Votes)).ToList()));
        }
    }
}
