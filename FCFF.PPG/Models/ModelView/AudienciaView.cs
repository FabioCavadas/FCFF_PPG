using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FCFF.PPG.Models.ModelView
{
    public class AudienciaView
    {
        [Key]
        [Display(Name = "Identificador")]
        public int Id { get; set; }

        [Display(Name = "Pontos")]
        [Required(ErrorMessage = "Informe pontuação")]
        public int Pontos { get; set; }

        [Display(Name = "Data - Hora")]
        public DateTime DataHora { get; set; }

        [Display(Name = "ID Emissora")]
        [Required(ErrorMessage = "Informe o identificador da emissora")]
        public int IdEmissora { get; set; }

        [Display(Name = "Emissora")]        
        public string Nome { get; set; }

        [Display(Name = "Somatório de Pontos")]        
        public int Somatorio { get; set; }

        [Display(Name = "Média Audiência")]        
        public int Media { get; set; }

        public List<SelectListItem> ListagemEmissoras { get; set; }
    }
}