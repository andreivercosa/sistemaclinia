using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;

namespace DAL.Persistence
{
    public class MedicoDal : Conexao
    {
        public void Salvar(Medico medico)
        {
            try
            {
                AbrirConexao();
                var sql = "INSERT INTO medico(idEspecialidade, nome, crm, dtCadastro)" +
                          "VALUES(@idEspecialidade, @nome, @crm, CURRENT_TIMESTAMP())";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idEspecialidade", medico.IdEspecialidade);
                command.Parameters.AddWithValue("@nome", medico.Nome);
                command.Parameters.AddWithValue("@crm", medico.CRM);
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

        public List<Medico> Listar()
        {
            try
            {
                AbrirConexao();
                var sql = "SELECT * FROM medico";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Medico> listaMedico = new List<Medico>();

                while (dataReader.Read())
                {
                    Medico medico = new Medico();

                    medico.Id = Convert.ToInt32(dataReader["id"]);
                    medico.Nome = dataReader["nome"].ToString();
                    medico.Nome = dataReader["crm"].ToString();
                    medico.DtCadastro = dataReader["dtCadastro"].ToString();

                }
                return listaMedico;

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

        public MedicoDal()
        {
        }
    }
}
