using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testes.Classes
{
    internal class AlunoProjeto
    {
        public int IdAluno
        {
            get; set;
        }
        public int IdProjeto
        {
            get; set;
        }

        // Construtor
        public AlunoProjeto(int idAluno, int idProjeto)
        {
            IdAluno = idAluno;
            IdProjeto = idProjeto;
        }
    }
}
