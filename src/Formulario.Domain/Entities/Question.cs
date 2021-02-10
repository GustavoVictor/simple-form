using System;
using System.Collections.Generic;
using Formulario.Domain.ViewModels.Question;

namespace Formulario.Domain.Entities
{
    public class Question
    {
        public Question()
        {
            Id = Guid.NewGuid();
            IsDeleted = false;
            CreatedDate = DateTime.Now;
            Options = new List<Option>();
        }

        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModified { get; set; }

        public bool IsDeleted {get;set;}

        public string Description { get; set; } 

        public virtual ICollection<Option> Options { get; set; }

        public Question ConvertViewModelToDomain(QuestionViewModel questionViewModel)
        {
            return new Question
            {
                Id = questionViewModel.Id,
                LastModified = questionViewModel.LastModified,
                IsDeleted = questionViewModel.IsDeleted,
                Description = questionViewModel.Description
            };
        }
    }
}