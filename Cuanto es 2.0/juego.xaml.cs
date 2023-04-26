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

namespace Cuanto_es_2._0
{
    /// <summary>
    /// Interaction logic for juego.xaml
    /// </summary>
    public partial class juego : Window
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        string nivel;
        string usuario;

        int vidas = 5;
        int fallidas = 0;
        int puntos = 0;


        public juego(string nivell,string usuarioo)
        {
            InitializeComponent();
            nivel = nivell;
            usuario = usuarioo;
        }
               


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // code goes here
            barra.Width = barra.Width - 1;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("iniciando timer");
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0,100);
            numero1();
           // operador();
            //contadores();
        }

        public void numero1()
        {
            Random r1 = new Random();
            int randomNumber1 = r1.Next(0, 300);            
            uno.Text = randomNumber1.ToString();
            int randomNumber2 = r1.Next(0, 300);
            dos.Text = randomNumber2.ToString();
        }

        public void operador()
        {            
            Random valor = new Random();
            valor.Next(0,40);
            int val = Convert.ToInt32(valor);
            if (val>=0 & val<10)
            {
                operacion.Content = "+";
            }else if (val >= 10 & val < 20)
            {
                operacion.Content = "-";
            }else if (val >= 20 & val < 30)
            {
                operacion.Content = "x";
            }else if (val >= 30 & val < 40)
            {
                operacion.Content = "/";
            }
        }

        public void contadores()
        {
            if (vidas == 5) { lifes.Content = "❤ ❤ ❤ ❤ ❤"; }
            if (vidas == 4) { lifes.Content = "❤ ❤ ❤ ❤"; }
            if (vidas == 3) { lifes.Content = "❤ ❤ ❤"; }
            if (vidas == 2) { lifes.Content = "❤ ❤"; }
            if (vidas == 1) { lifes.Content = "❤"; }
            if (vidas == 0) { lifes.Content = ""; }
            points.Content = puntos;
            failed.Content = fallidas;
        }

        private void TextBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return")
            {
                dispatcherTimer.Start();
                verificar();
            }
            else
            {
               MessageBox.Show(e.Key.ToString());
               // MessageBox.Show(Key.Enter.ToString());
            }
            
        }
        public void buena()
        {
            vidas = vidas;
            fallidas = fallidas;
            puntos = puntos + 10;
            contadores();
        }
        public void mala()
        {
            vidas = vidas-1;
            fallidas = fallidas+1;
            puntos = puntos - 5;
            contadores();
        }

        public void verificar()
        {
            int num1 = Convert.ToInt32(uno.Text);
            int num2 = Convert.ToInt32(dos.Text);
            string operador = operacion.Content.ToString();
            int resultador = Convert.ToInt32(resultadox.Text);

            if (operador == "+")
            {
                if (resultador == num1+num2) { buena(); }
            }else if (operador == "-")
            {
                if (resultador == num1 - num2) { buena(); }
            }else if (operador == "x")
            {
                if (resultador == num1 * num2) { buena(); }
            }else if (operador == "/")
            {
                if (resultador == num1 / num2) { buena(); }
            }
            else
            {
                mala();
            }
            numero1();
        }
    }
}
