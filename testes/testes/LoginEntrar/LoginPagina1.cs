using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testes.Classes;

namespace testes.LoginEntrar
{
    public partial class LoginPagina1 : Form
    {
        private Login login;
        public LoginPagina1()
        {
            InitializeComponent();
            login = new Login();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            login.Usuario = txtLogin.Text;
            login.Senha = txtSenha.Text;
            if (login.Logar())
            {
                FormPrincipal p = new FormPrincipal();
                p.FormClosed += FecharForm;
                this.Hide();
                p.Show();
            }
            else
            {
                MessageBox.Show("Usuário e senha inválidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FecharForm(object sender, FormClosedEventArgs e)
        {
            Visible = true;
        }
    }
}
