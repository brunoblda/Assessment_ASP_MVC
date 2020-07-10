using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssessmentAspV1.Models
{
    public class OrdenarLista
    {

       public List<PessoaDetalhada> AniversariosDoDia(List<Pessoa> pessoas)
        {

            List<PessoaDetalhada> AniversariosHoje = new List<PessoaDetalhada>();

           

            foreach (Pessoa p in pessoas)
            {
                PessoaDetalhada Pd = new PessoaDetalhada();
                Pd.Nome = p.Nome;
                Pd.Sobrenome = p.Sobrenome;
                Pd.DataDeNascimento = p.DataDeNascimento;
               

                Pd.aniversario();

                if(Pd.TempoParaAniversario == 0)
                {
                    AniversariosHoje.Add(Pd);
                }

            }

            return AniversariosHoje;

        }

        public List<Pessoa> TempoParaAniversario(List<Pessoa> pessoas)
        {
            List<PessoaDetalhada> PessoasDetalhadas = new List<PessoaDetalhada>();

            foreach (Pessoa p in pessoas)
            {
                PessoaDetalhada Pd = new PessoaDetalhada();
                Pd.PessoaId = p.PessoaId;
                Pd.Nome = p.Nome;
                Pd.Sobrenome = p.Sobrenome;
                Pd.DataDeNascimento = p.DataDeNascimento;


                Pd.aniversario();

                PessoasDetalhadas.Add(Pd);

            }

            List<PessoaDetalhada> ListaDetalhadaOrdenada = PessoasDetalhadas.OrderBy(x => x.TempoParaAniversario).ToList();

            List<Pessoa> PessoasOrdenadas = new List<Pessoa>();

            foreach (PessoaDetalhada Pdn in ListaDetalhadaOrdenada)
            {
                Pessoa Pe = new Pessoa();
                Pe.PessoaId = Pdn.PessoaId;
                Pe.Nome = Pdn.Nome;
                Pe.Sobrenome = Pdn.Sobrenome;
                Pe.DataDeNascimento = Pdn.DataDeNascimento;

                PessoasOrdenadas.Add(Pe);

            }

            return PessoasOrdenadas;

        }

    }
}