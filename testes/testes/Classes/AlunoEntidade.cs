using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testes.Classes
{
    public class Aluno
    {
        public int IdAluno
        {
            get; set;
        }
        public string Nome
        {
            get; set;
        }
        public string Email
        {
            get; set;
        }
        public int? IdProjeto
        {
            get; set;
        }

        public override string ToString()
        {
            return Nome; // O nome será exibido no CheckedListBox
        }
    }

}
