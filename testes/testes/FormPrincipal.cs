using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testes.LoginEntrar;

namespace testes
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void projetoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProjeto p = new FrmProjeto();
            p.ShowDialog();

        }

        private void alunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAluno p = new FormAluno();
            p.ShowDialog();
        }

        private void gerenciarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenciarUsuarios g = new GerenciarUsuarios();
            g.ShowDialog();
        }
    }
}
