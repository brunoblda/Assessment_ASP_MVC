using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace AssessmentAspV1.Models
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        [Required(ErrorMessage = "Informe o Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o Sobrenome")]
        public string Sobrenome { get; set; }
        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "Informe a data de Nascimento")]
        [DataType(DataType.Date)]      
        public DateTime DataDeNascimento { get; set; }

    }
}