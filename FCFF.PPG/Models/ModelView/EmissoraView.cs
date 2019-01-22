using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FCFF.PPG.Models.ModelView
{
    public class EmissoraView
    {
        [Key]
        [Display(Name = "Identificador")]
        public int Id { get; set; }

        [Display(Name = "Emissora")]
        [Required(ErrorMessage = "Informe o nome da emissora")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use apenas caracteres alfabéticos.")]
        public string Nome { get; set; }

        [Display(Name = "Ações")]
        public string Acao { get; set; }

    }
}