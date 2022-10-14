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

namespace Tema3_VisorImagenes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int numeroFotos;
        public MainWindow()
        {
            InitializeComponent();
            CambiarTexto();
        }

        private void añadirImagenButton_Click(object sender, RoutedEventArgs e)
        {
            Image imagen = new Image();
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri("./assets/episodioIV.jpg", UriKind.Relative);
            logo.EndInit();

            imagen.Source = logo;

            panelImagenesWrapPanel.Children.Add(imagen);

            CambiarTexto();
        }

        private void eliminarImagen_Button_Click(object sender, RoutedEventArgs e)
        {
            if (panelImagenesWrapPanel.Children.Count > 0)
            {
                panelImagenesWrapPanel.Children.RemoveAt(panelImagenesWrapPanel.Children.Count - 1);

                CambiarTexto();
            }
            
        }

        private void eliminarTodas_Button_Click(object sender, RoutedEventArgs e)
        {
            if (panelImagenesWrapPanel.Children.Count > 0)
            {
                panelImagenesWrapPanel.Children.Clear();

                CambiarTexto();
            }
        }

        private void rotar_Button_Click(object sender, RoutedEventArgs e)
        {

            eliminarImagen_Button_Click(sender, e);
            BitmapImage bitmap = new BitmapImage();

            Image image = new Image();
            image.Height = 120;
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("./assets/episodioIV.jpg", UriKind.Relative);
            bitmap.Rotation = Rotation.Rotate90;
            bitmap.EndInit();

            image.Source = bitmap;
            panelImagenesWrapPanel.Children.Add(image);
        }

        private void CambiarTexto()
        {
            numeroFotos = panelImagenesWrapPanel.Children.Count;
            numeroImagenes_TextBlock.Text = "Nº de imagenes: " + numeroFotos;
        }
    }
}
