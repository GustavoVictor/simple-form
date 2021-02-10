using System;
using System.Collections.Generic;
using Formulario.Domain.Entities;
using Formulario.Domain.ViewModels.Option;

namespace Formulario.Domain.ViewModels.Question
{
    public class QuestionViewModel
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public DateTime? LastModified { get; set; }

        public bool IsDeleted { get;set; }

        public List<OptionViewModel> Option { get; set; }

        public QuestionViewModel ConvertDomainToViewModel(Formulario.Domain.Entities.Question question)
        {
            return new QuestionViewModel
            {
                Id = question.Id,
                LastModified = question.LastModified,
                IsDeleted = question.IsDeleted,
                Description = question.Description
            };
        }
    }
}