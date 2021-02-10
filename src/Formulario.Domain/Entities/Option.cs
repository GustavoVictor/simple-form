using System;

namespace Formulario.Domain.Entities
{
    public class Option
    {
        public Option()
        {
            Id = Guid.NewGuid();
            IsDeleted = false;
            CreatedDate = DateTime.Now;
        }

        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModified { get; set; }

        public bool IsDeleted {get;set;}

        public string Description { get; set; }
    }
}