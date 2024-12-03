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
    public partial class EditarUsuario : Form
    {
        public EditarUsuario()
        {
        }

        public EditarUsuario(int Id)
        {
            InitializeComponent();
            Usuarios user = new Usuarios();
            user.PesquisarPorId(Id);
            txtId.Text = user.Id.ToString();
            txtLogin.Text = user.Login;
            txtSenha.Text = user.Senha;
            chkAtivo.Checked = user.Ativo;
            user = null;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Criar uma nova instância do objeto Usuarios e preencher com dados do formulário
            Usuarios usuarios = new Usuarios();
            usuarios.Id = Convert.ToInt32(txtId.Text);
            usuarios.Login = txtLogin.Text;
            usuarios.Senha = txtSenha.Text;
            usuarios.Ativo = chkAtivo.Checked;

            // Chama o método para editar o usuário
            usuarios.Editar();

            // Exibe a MessageBox apenas depois de editar o usuári

            // Atualiza o grid após a exibição da MessageBox
            usuarios.PreencherGrid();


            // Fecha o formulário de edição
            this.Close();
        }



        private void btn_excluir_Click(object sender, EventArgs e)
        {
            // Criar uma nova instância do objeto Usuarios e preencher com dados do formulário
            Usuarios usuarios = new Usuarios();
            usuarios.Id = Convert.ToInt32(txtId.Text);

            // Chama o método para excluir o usuário
            usuarios.Excluir();

            // Exibe a MessageBox após a exclusão com sucesso
            

            // Atualiza o grid após a exibição da MessageBox
            usuarios.PreencherGrid();

            // Fecha o formulário de edição
            this.Close();
        }



    }
}

