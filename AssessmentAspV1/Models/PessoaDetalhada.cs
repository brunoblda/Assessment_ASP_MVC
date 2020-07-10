using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssessmentAspV1.Models
{
    public class PessoaDetalhada:Pessoa
    {   
        [Display(Name = "Dias para aniversário")]
        public int TempoParaAniversario { get; set; }

        public void aniversario()
        {
            
            DateTime agora = DateTime.Now;
            string dataDeNascimentoShort = DataDeNascimento.ToShortDateString();
            string diaMes = dataDeNascimentoShort.Remove(6);
            string diaMesAno = diaMes + agora.Year;
            DateTime aniversario = DateTime.Parse(diaMesAno);

            string tempoQueFalta;

            TimeSpan umDia = new TimeSpan(1, 0, 0, 0);

            if (agora > aniversario)
            {
                int ano = agora.Year + 1;
                diaMesAno = diaMes + ano;
                aniversario = DateTime.Parse(diaMesAno);
                TimeSpan tempo = aniversario.Subtract(agora) + umDia;
                if (int.Parse(tempo.Days.ToString()) == 365)
                {
                    tempoQueFalta = "0";
                }
                else
                {
                    tempoQueFalta = tempo.Days.ToString();
                }
            }
            else
            {
                TimeSpan tempo = aniversario.Subtract(agora) + umDia;

                if (int.Parse(tempo.Days.ToString()) == 365)
                {
                    tempoQueFalta = "0";
                }
                else
                {
                    tempoQueFalta = tempo.Days.ToString();
                }
            }



            TempoParaAniversario = int.Parse(tempoQueFalta);

        }
    }
}