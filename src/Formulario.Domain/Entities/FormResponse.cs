using System;
using System.Collections.Generic;

namespace Formulario.Domain.Entities
{
    public class FormResponse
    {
        public FormResponse()
        {
            Id = Guid.NewGuid();
            IsDeleted = false;
            CreatedDate = DateTime.Now;
        }

        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModified { get; set; }

        public bool IsDeleted {get;set;}

        public List<Answer> Answers { get;set; }
    }
}