using System.Collections.Generic;
using Formulario.Domain.Enum;
using Formulario.Domain.ViewModels.Question;

namespace Formulario.Domain.ViewModels.Form
{
    public class FormViewModel
    {
        public FormType FormType { get; set; }
        
        public List<QuestionViewModel> Question { get; set; }
    }
}