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
using testes.Editar;

namespace testes.LoginEntrar
{
    public partial class GerenciarUsuarios : Form
    {
        public GerenciarUsuarios()
        {
            InitializeComponent();
            Usuarios user = new Usuarios();
            dtgridusuarios.DataSource = user.PreencherGrid();
        }



        private void FecharForm(object sender, FormClosedEventArgs e)
        {
            // Atualiza o grid sempre que um formulário (de editar ou novo) for fechado
            AtualizarGrid();
        }

        private void Fechou_Editar_FormClosed(object sender, FormClosedEventArgs e)
        {
            Usuarios user = new Usuarios();
            dtgridusuarios.DataSource = user.PreencherGrid();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            Usuarios u = new Usuarios();
            dtgridusuarios.DataSource = u.Pesquisar(txtPesquisar.Text);
        }

        private void btnNovo_Click_1(object sender, EventArgs e)
        {
            NovoUsuario frm = new NovoUsuario();
            frm.FormClosed += FecharForm;
            frm.ShowDialog();
        }

        private void dtgridusuarios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Captura o ID da linha selecionada. Supondo que o ID esteja na primeira coluna
                int idUsuario = Convert.ToInt32(dtgridusuarios.Rows[e.RowIndex].Cells[0].Value);

                // Passa o ID para o formulário de edição
                EditarUsuario u = new EditarUsuario(idUsuario);
                u.FormClosed += Fechou_Editar_FormClosed;
                u.ShowDialog();
            }

            

            // Inscreve-se no evento
            

        }
        public void AtualizarGrid()
        {
            // Recarregar o DataGridView com os dados mais recentes
            dtgridusuarios.DataSource = null; // Limpa o DataGridView antes de preencher novamente
            Usuarios usuarios = new Usuarios();
            dtgridusuarios.DataSource = usuarios.PreencherGrid();
        }



    }
}
