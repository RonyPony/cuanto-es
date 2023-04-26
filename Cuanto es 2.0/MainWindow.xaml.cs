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

namespace Cuanto_es_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void comboBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text == "")
            {
                comunicar("Introduzca su nombre", "Antes de comenzar debes identificarte con un nombre de usuario.");
            }
            else
            {
                comunicar("", "");
                if (comboBox.Text == "")
                {
                    comunicar("Selecciona una categoria", "Para continuar debe seleccionar una categoria de entre las disponibles arriba.");
                }
                else { comunicar("", "");
                    juego jj = new juego(comboBox.Text,textBox.Text);
                    jj.Show();
                }
            }
        }

        public void comunicar(String errorTitulo ,String error) {
            errorReporter.Content = error;
            this.Title = errorTitulo;
        }
    }
}
