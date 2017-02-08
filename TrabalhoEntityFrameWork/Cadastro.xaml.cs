using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TrabalhoEntityFrameWork.Controller;
using TrabalhoEntityFrameWork.Model;

namespace TrabalhoEntityFrameWork
{
    /// <summary>
    /// Interaction logic for Cadastro.xaml
    /// </summary>
    public partial class Cadastro : Window
    {
        private Funcionario funcionario = null;
        private OperacaoCRUD<Funcionario> crud = new OperacaoCRUD<Funcionario>();

        public Cadastro()
        {
            InitializeComponent();
        }

        public Cadastro(Funcionario funcionario)
        {
            InitializeComponent();
            if (funcionario == null)
                throw new ArgumentNullException("funcionario");
            this.funcionario = funcionario;
            nomeTXT.Text = funcionario.Nome;
            cargoTXT.Text = funcionario.Cargo;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nomeTXT.Text))
                MessageBox.Show("Campo nome é obrigatório!", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (string.IsNullOrEmpty(cargoTXT.Text))
                MessageBox.Show("Campo cargo é obrigatório!", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                if (this.funcionario == null)
                {
                    crud.Salvar(new Funcionario() { Nome = nomeTXT.Text, Cargo = cargoTXT.Text });
                    MessageBox.Show("Salvo com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    Fechar();
                }
                else
                {
                    funcionario.Nome = nomeTXT.Text;
                    funcionario.Cargo = cargoTXT.Text;
                    crud.Editar(funcionario);
                    MessageBox.Show("Editado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    Fechar();
                }
            }
        }

        private void Fechar()
        {
            this.Close();
        }
    }
}
