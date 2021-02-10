using System;

namespace Formulario.Domain.Entities
{
    public class Answer
    {
        public Answer()
        {
            Id = Guid.NewGuid();
            IsDeleted = false;
            CreatedDate = DateTime.Now;
        }

        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModified { get; set; }

        public bool IsDeleted {get;set;}

        public Guid QuestionId {get;set;}

        public Guid? OptionId { get; set; }

        public string Description { get; set; }
    }
}