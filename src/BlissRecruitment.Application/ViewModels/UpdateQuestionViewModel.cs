using System;
using System.Collections.Generic;

namespace BlissRecruitment.Application.ViewModels
{
    public class UpdateQuestionViewModel
    {
        public long id { get; set; }

        public string question { get; set; }

        public string image_url { get; set; }

        public string thumb_url { get; set; }

        public ICollection<QuestionChoiceViewModel> Choices { get; set; }
    }
}
