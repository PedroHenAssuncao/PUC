using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista6
{
    public class Aluno
    {
        public string Matricula { get; set; }
        public string Telefone { get; set; }

        public Aluno(string matricula, string telefone)
        {
            Matricula = matricula;
            Telefone = telefone;
        }
    }
}
