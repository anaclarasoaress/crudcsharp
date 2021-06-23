using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_First.Models
{
    public class FuncionarioDAL: IFuncionarioDAL
    {
        string connectionString = @"Data Source = .\SQLEXPRESS; User Id= sa; Password= 20072019;  Initial Catalog = CadastroDB;";

        public IEnumerable<Funcionario> GetAllFuncionario()//Lista tudo
        {
            List<Funcionario> listFuncionario = new List<Funcionario>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from Funcionarios", con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Funcionario funcionario = new Funcionario();

                    funcionario.FuncionarioId = Convert.ToInt32(rdr["FuncionarioId"]);
                    funcionario.Nome = rdr["Nome"].ToString();
                    funcionario.Cidade = rdr["Cidade"].ToString();
                    funcionario.Departamento = rdr["Departamento"].ToString();
                    funcionario.Sexo = rdr["Sexo"].ToString();

                    listFuncionario.Add(funcionario);//adiciono tudo em uma variavel que salva no banco;
                }
                con.Close();
            }
            return listFuncionario;
        }
        public void AddFuncionario(Funcionario funcionario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSql = "Insert into Funcionarios(Nome,Cidade,Departamento,Sexo) values (@Nome,@Cidade,@Departamento,@Sexo)";
                SqlCommand cmd = new SqlCommand(comandoSql, con);

                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Cidade", funcionario.Cidade);
                cmd.Parameters.AddWithValue("@Departamento", funcionario.Departamento);
                cmd.Parameters.AddWithValue("@Sexo", funcionario.Sexo);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteFuncionario(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSql = "Delete from Funcionarios where FuncionarioId= @FuncionarioId";
                SqlCommand cmd = new SqlCommand(comandoSql, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@FuncionarioId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
                
        }

        public Funcionario GetFuncionario(int? id)//Seleciona com um id
        {
            Funcionario funcionario = new Funcionario();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSql = "Select * from Funcionarios Where FuncionarioId =" + id;
                SqlCommand cmd = new SqlCommand(comandoSql, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    funcionario.FuncionarioId = Convert.ToInt32(rdr["FuncionarioId"]);
                    funcionario.Nome = rdr["Nome"].ToString();
                    funcionario.Cidade = rdr["Cidade"].ToString();
                    funcionario.Departamento = rdr["Departamento"].ToString();
                    funcionario.Sexo = rdr["Sexo"].ToString();
                }
            }

            return funcionario;
        }

        public void UpdateFuncionario(Funcionario funcionario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSql = "Update Funcionarios set Nome=@Nome, Cidade=@Cidade, Departamento=@Departamento, Sexo=@Sexo where FuncionarioId = @FuncionarioId";
                SqlCommand cmd = new SqlCommand(comandoSql, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@FuncionarioId", funcionario.FuncionarioId);
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Cidade", funcionario.Cidade);
                cmd.Parameters.AddWithValue("@Departamento", funcionario.Departamento);
                cmd.Parameters.AddWithValue("@Sexo", funcionario.Sexo);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
