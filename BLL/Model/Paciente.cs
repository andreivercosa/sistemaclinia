using System;
namespace BLL.Model
{
    public class Paciente
    {
        public int Id { get; set; }
        public int idCidade { get; set; }
        public string nome { get; set; }
        public string DtCadastro { get; set; }
        public Paciente()
        {
        }
    }
}
