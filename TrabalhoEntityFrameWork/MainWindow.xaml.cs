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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrabalhoEntityFrameWork.Controller;
using TrabalhoEntityFrameWork.Model;

namespace TrabalhoEntityFrameWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            funcionariosGRID.ItemsSource = new OperacaoCRUD<Funcionario>().Get();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (new Cadastro().ShowDialog() == false)
            {
                CarregarGrid();
            }
        }

        private void Button_Click_Editar(object sender, RoutedEventArgs e)
        {
            if (new Cadastro(funcionariosGRID.SelectedItem as Funcionario).ShowDialog() == false)
            {
                CarregarGrid();
            }
        }

        private void Button_Click_Excluir(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja excluir realmente o funcionário?", "Excluir",MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                new OperacaoCRUD<Funcionario>().Delete((funcionariosGRID.SelectedItem as Funcionario).Id);
                CarregarGrid();
            }
        }
    }
}
