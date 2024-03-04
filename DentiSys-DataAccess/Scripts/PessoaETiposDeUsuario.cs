using DentiSys_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentiSys_DataAccess.Scripts
{
    public class PessoaETiposDeUsuario
    {
        public class Pessoa
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
            public string SobreNome { get; set; }
            public int Idade { get; set; }
            public string CPF { get; set; }
            public DateTime DataDeAniversario { get; set; }
            public string Email { get; set; }
            public string NumeroDeTelefone { get; set; }
            public int MyProperty { get; set; }
            public Endereco Endereco { get; set; }

        }

        public class Paciente : Pessoa
        {
            public Guid Id { get; set; }
            //List<PacienteProcedimento> Procedimentos { get; set; }
            //List<PacientePlano> Planos { get; set; }
        }

        public class Dentista : Pessoa
        {
            public Guid Id { get; set; }
            public string Especializacao { get; set; }
            public string NumeroDeRegistro { get; set; } //Numero de registro emitido pela pregadora do curso superior
        }
    }
}
