using System;
using System.Linq;
using System.Collections.Generic;
using Formulario.Domain.ViewModels.Question;
using Formulario.Domain.Repositories;
using Formulario.Domain.Interfaces.Identities;
using Formulario.Domain.ViewModels.Form;
using Formulario.Domain.Enum;

namespace Formulario.Domain.Entities
{
    public class Form : IForm
    {
        private readonly IFormRepository _repositoryForm;

        public Form(IFormRepository repositoryForm)
        {
            _repositoryForm = repositoryForm;
        }

        public Form()
        {
            Id = Guid.NewGuid();
            IsDeleted = false;
            CreatedDate = DateTime.Now;
        }

        private Guid Id { get; set; }

        private DateTime CreatedDate { get; set; }

        private DateTime? LastModified { get; set; }

        private bool IsDeleted {get;set;}

        public FormType FormType { get; set; }

        public List<Question> Questions { get; set; }

        public dynamic Create(FormViewModel form)
        {
            if (form == null)
                throw new Exception("Formulário vazio.");

            Form _form = new Form
            {
                Questions = form.Question.Select(s => new Question
                {
                    Description = s.Description
                })
                .ToList()
            };

            return _repositoryForm.Create(_form);
        }

        public dynamic Update(FormViewModel form)
        {
            if (form == null)
                throw new Exception("Formulário vazio.");

            Form _form = _repositoryForm.Find(wh => wh.FormType == form.FormType);

            _form.Questions = form.Question?.Select(question => new Question().ConvertViewModelToDomain(question))
                                           .ToList();

            return _repositoryForm.Update(wh => wh.Id == _form.Id, _form);
        }

        public dynamic Get(FormType formType)
        {
            Form _form = _repositoryForm.Find(wh => wh.FormType == formType);

            return new FormViewModel
            {
                Question = _form.Questions?.Select(question => new QuestionViewModel().ConvertDomainToViewModel(question))
                                          .ToList()
            };
        }
    }
}