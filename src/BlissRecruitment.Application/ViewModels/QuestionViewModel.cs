using BlissRecruitment.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BlissRecruitment.Application.ViewModels
{
    public class QuestionViewModel
    {
        public long id { get; set; }

        public string question { get; set; }

        public string image_url { get; set; }

        public string thumb_url { get; set; }

        public DateTime published_at { get; set; }

        public ICollection<QuestionChoiceViewModel> Choices { get; set; }
    }
}
