using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeuGuardaRoupa
{
    public partial class ListaPeca : Form
    {
        public ListaPeca()
        {
            InitializeComponent();
        }

        private void ListaPeca_Load(object sender, EventArgs e)
        {
            AtualizarLista();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarLista();
        }

        private void AtualizarLista()
        {
            dgvListaPeca.Rows.Clear();
            for (int i = 0; i < Program.pecas.Count; i++)
            {
                Peca peca = Program.pecas[i];
                dgvListaPeca.Rows.Add(new object[]{
                    peca.Nome, peca.Cor, peca.Marca, peca.Valor
                });
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            new CadastroPeca().ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (dgvListaPeca.CurrentRow == null)
            {
                MessageBox.Show("Não tem nenhuma peça selecionada");
                return;
            }

            int linhaSelecionada = dgvListaPeca.CurrentRow.Index;
            Peca peca = Program.pecas[linhaSelecionada];
            new CadastroPeca(peca, linhaSelecionada).ShowDialog();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (dgvListaPeca.CurrentRow == null)
            {
                MessageBox.Show("Não tem nenhuma peça selecionada");
                return;
            }

            int linhaSelecionada = dgvListaPeca.CurrentRow.Index;

            Peca peca = Program.pecas[linhaSelecionada];
            DialogResult resultado = MessageBox.Show("Deseja apagar " + peca.Nome + " o registro?",
                "AVISO", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                Program.pecas.RemoveAt(linhaSelecionada);
                AtualizarLista();
                MessageBox.Show("Registro apagado com sucesso");
            }
            else
            {
                MessageBox.Show("Ta salvo o seu registro jovem");
            }


        }

    }
}
