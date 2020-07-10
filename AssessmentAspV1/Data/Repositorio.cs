using AssessmentAspV1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace AssessmentAspV1.Data
{
    public class Repositorio
    {
        public IEnumerable<Pessoa> TodasAsPessoas()
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bruno\Desktop\Infnet\Ads\AspNet\AssessmentAspV1\AssessmentAspV1\App_Data\BancoDeDados.mdf;Integrated Security=True";

            var connection = new SqlConnection(connectionString);

            var commandText = "SELECT * FROM PessoasInfo";

            var selectCommand = connection.CreateCommand();

            selectCommand.CommandText = commandText;



            var Pessoas = new List<Pessoa>();

            try
            {
                connection.Open();

                var reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {

                    var pessoa = new Pessoa()
                    {
                        PessoaId = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Sobrenome = reader.GetString(2),
                        DataDeNascimento = reader.GetDateTime(3)
                    };

                    Pessoas.Add(pessoa);

                }

            }
            finally
            {
                connection.Close();
            }

            return Pessoas;

        }

        public void ExluirPessoa(int Id)
        {

            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bruno\Desktop\Infnet\Ads\AspNet\AssessmentAspV1\AssessmentAspV1\App_Data\BancoDeDados.mdf;Integrated Security=True";

            var connection = new SqlConnection(connectionString);

            var commandText = "DELETE FROM PessoasInfo WHERE PessoaId=@Id";

            var selectCommand = connection.CreateCommand();

            selectCommand.CommandText = commandText;

            selectCommand.Parameters.AddWithValue("@Id", Id);


            try
            {
                connection.Open();


                selectCommand.ExecuteNonQuery();

            }
            finally
            {
                connection.Close();
            }

        }

        public void EditarPessoa(Pessoa p)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bruno\Desktop\Infnet\Ads\AspNet\AssessmentAspV1\AssessmentAspV1\App_Data\BancoDeDados.mdf;Integrated Security=True";

            var connection = new SqlConnection(connectionString);

            var commandText = "UPDATE PessoasInfo SET Nome=@nome, Sobrenome=@Sobrenome, DataDeNascimento=@DataDeNascimento WHERE PessoaId =@PessoaId";

            var selectCommand = connection.CreateCommand();                       

            selectCommand.CommandText = commandText;

            selectCommand.Parameters.AddWithValue("@Nome", p.Nome);
            selectCommand.Parameters.AddWithValue("@Sobrenome", p.Sobrenome);
            selectCommand.Parameters.AddWithValue("@DataDeNascimento", p.DataDeNascimento);
            selectCommand.Parameters.AddWithValue("@PessoaId", p.PessoaId);
                      

            try
            {
                connection.Open();


                selectCommand.ExecuteNonQuery();

            }
            finally
            {
                connection.Close();
            }

        }

        public void IncluirPessoa(Pessoa p)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bruno\Desktop\Infnet\Ads\AspNet\AssessmentAspV1\AssessmentAspV1\App_Data\BancoDeDados.mdf;Integrated Security=True";

            var connection = new SqlConnection(connectionString);

            //var selectCommand = connection.CreateCommand();

            var selectCommand = new SqlCommand("Insert_Pessoa");

            selectCommand.CommandType = CommandType.StoredProcedure;

            //var commandText = @"INSERT INTO PessoasInfo (Nome, Sobrenome, DataDeNascimento)
            //                    VALUES (@Nome, @Sobrenome, @DataDeNascimento)";

           

            //selectCommand.CommandText = commandText;

            selectCommand.Parameters.AddWithValue("@Nome", p.Nome);
            selectCommand.Parameters.AddWithValue("@Sobrenome", p.Sobrenome);
            selectCommand.Parameters.AddWithValue("@DataDeNascimento", p.DataDeNascimento);

            selectCommand.Connection = connection;

            try
            {
                connection.Open();


                selectCommand.ExecuteNonQuery();

            }
            finally
            {
                connection.Close();
            }

        }

        public Pessoa BuscarPessoaPorId(int Id)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bruno\Desktop\Infnet\Ads\AspNet\AssessmentAspV1\AssessmentAspV1\App_Data\BancoDeDados.mdf;Integrated Security=True";

            var connection = new SqlConnection(connectionString);

            var commandText = "SELECT * FROM PessoasInfo WHERE PessoaId=@PessoaId";

            Pessoa pessoa = null;

            var selectCommand = connection.CreateCommand();

            selectCommand.CommandText = commandText;
            selectCommand.Parameters.AddWithValue("@PessoaId", Id);

            try
            {

                connection.Open();

                var reader = selectCommand.ExecuteReader();


                while (reader.Read())
                {

                    pessoa = new Pessoa()
                    {

                        PessoaId = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Sobrenome = reader.GetString(2),
                        DataDeNascimento = reader.GetDateTime(3)
                    };
                }

            }
            finally
            {
                connection.Close();
            }

            return pessoa;

        }

        public List<Pessoa> BuscarPessoaPorNome(string nome)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bruno\Desktop\Infnet\Ads\AspNet\AssessmentAspV1\AssessmentAspV1\App_Data\BancoDeDados.mdf;Integrated Security=True";

            var connection = new SqlConnection(connectionString);

            var commandText = "SELECT * FROM PessoasInfo WHERE Nome LIKE '%'+@nome+'%' OR Sobrenome LIKE '%'+@nome+'%'";

            var selectCommand = connection.CreateCommand();

            selectCommand.CommandText = commandText;

            selectCommand.Parameters.AddWithValue("@nome", nome);

            List<Pessoa> pessoas = new List<Pessoa>();

            try
            {
                connection.Open();

                var reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {

                    var pessoa = new Pessoa()
                    {
                        PessoaId = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Sobrenome = reader.GetString(2),
                        DataDeNascimento = reader.GetDateTime(3)
                    };

                    pessoas.Add(pessoa);

                }

            }
            finally
            {
                connection.Close();
            }

            return pessoas;

        }


    }
}