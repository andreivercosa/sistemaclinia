using System;
using System.Collections.Generic;
using BLL.Model;
using MySql.Data.MySqlClient;
namespace DAL.Percistence
{
    public class EstadoDal : Conexao
    {
        public void Salvar(Estado estado){
            try{
                AbrirConexao();
                var sql = "INSERT INTO estado (nome, sigla, dtCadastro)" +
                    "VALUES(@nome, @sigla,CURRENT_TIME_STAMP())";
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nome", estado.Nome);
                command.Parameters.AddWithValue("@sigla", estado.Sigla);
            }
            catch(Exception erro){
                throw new Exception("Erro ao registrar dado" + erro.Message + erro.ToString());

            }
            finally {

                FecharConexao();
            }
        }

        public List<Estado> Listar()
        {
            try{
                AbrirConexao();
                var sql = "SELECT * FROM estado";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                List<Estado> listaEstado = new List<Estado>();
                while(dataReader.Read()){
                    Estado estado = new Estado();
                    estado.Id = Convert.ToInt32(dataReader["id"]);
                    estado.Nome = dataReader["nome"].ToString();
                    estado.Sigla = dataReader["sigla"].ToString();
                }
                return listaEstado;

            }catch (Exception erro){
                throw new Exception("Erro ao registrar dado" + erro.Message + erro.ToString());

            }finally{
                FecharConexao();
            }
        }

        public EstadoDal()
        {
        }
    }
}
