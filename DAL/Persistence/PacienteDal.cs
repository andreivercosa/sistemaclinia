using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;
using System.Data;

namespace DAL.Persistence
{
    public class PacienteDal : Conexao
    {
        public void Salvar(Paciente paciente)
        {
            try
            {
                AbrirConexao();
                var sql = "INSERT INTO paciente(idCidade, nome, dtCadastro)" +
                          "VALUES(@idCidade, @nome, CURRENT_TIMESTAMP())";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nome", paciente.nome);
                command.Parameters.AddWithValue("@idCidade", paciente.idCidade);
                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Paciente> Listar()
        {
            try
            {
                AbrirConexao();
                var sql = "SELECT * FROM paciente";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Paciente> listaPaciente = new List<Paciente>();

                while (dataReader.Read())
                {
                    Paciente paciente = new Paciente();

                    paciente.Id = Convert.ToInt32(dataReader["id"]);
                    paciente.nome = dataReader["nome"].ToString();

                    listaPaciente.Add(paciente);
                }

                return listaPaciente;

            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());
            }
            finally
            {
                FecharConexao();
            }
        }
        public DataTable ListarNome(string nome)
        {
            try
            {

                var sql = "SELECT * FROM paciente WHERE nome LIKE '%" + nome + "%' ";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();


                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("paciente");
                dataTable.Columns.Add("cidade");
                dataTable.Columns.Add("estado");
                while (dataReader.Read())
                {
                    Paciente paciente = new Paciente();
                    CidadeDal cidadeDal = new CidadeDal();
                    EstadoDal estadoDal = new EstadoDal();


                    paciente.Id = Convert.ToInt32(dataReader["id"]);
                    paciente.idCidade = Convert.ToInt32(dataReader["idCidade"]);
                    paciente.nome = dataReader["nome"].ToString();
                    paciente.Cidade = cidadeDal.pesquisarCidade (paciente.idCidade);
                    paciente.Cidade.Estado = estadoDal.pesquisarEstado(paciente.Cidade.IdEstado);
                    dataTable.Rows.Add(paciente.nome, paciente.Cidade.Descricao,paciente.Cidade.Estado.Nome);
                }

                return dataTable;

            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());
            }
            finally
            {
                FecharConexao();
            }
        }
        public PacienteDal()
        {
        }
    }
}
