using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Práctica1
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

        private void AbrirInicio(object sender, RoutedEventArgs e)
        {
            Inicio.Visibility = Visibility.Visible;
            Login.Visibility = Visibility.Collapsed;
            Galería.Visibility = Visibility.Collapsed;
            MX5.Visibility = Visibility.Collapsed;
            MenuLateral.Visibility = Visibility.Collapsed;
        }

        private void AbrirLogin(object sender, RoutedEventArgs e)
        {
            Inicio.Visibility = Visibility.Collapsed;
            Login.Visibility = Visibility.Visible;
            Galería.Visibility = Visibility.Collapsed;
            MX5.Visibility = Visibility.Collapsed;
            MenuLateral.Visibility = Visibility.Collapsed;
        }

        private void AbrirGalería(object sender, RoutedEventArgs e)
        {
            Inicio.Visibility = Visibility.Collapsed;
            Login.Visibility = Visibility.Collapsed;
            Galería.Visibility = Visibility.Visible;
            MX5.Visibility = Visibility.Collapsed;
            MenuLateral.Visibility = Visibility.Collapsed;
        }
        private void AbrirMX5(object sender, RoutedEventArgs e)
        {
            Inicio.Visibility = Visibility.Collapsed;
            Login.Visibility = Visibility.Collapsed;
            Galería.Visibility = Visibility.Collapsed;
            MX5.Visibility = Visibility.Visible;
        }

        private void SolicitarPrueba(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Solicitud registrada. Un asesor de Mazda se pondrá en contacto contigo.", "Mazda MX-5");
        }

        private void ComprobarLogin(object sender, RoutedEventArgs e)
        {
            string User = this.txtUsuario.Text;
            string Password = this.txtPassword.Password;

            if (User == "" || Password == "")
            {

                MessageBox.Show("Inserte el nombre del usuario o el Password");
                this.txtUsuario.Focus();
                return;
            }
            else
            {

                if (txtUsuario.Text != "Alumno" || txtPassword.Password != "1234")
                {
                    MessageBox.Show("El nombre de usuario o el password es incorrecto");
                    this.txtUsuario.Focus();
                    return;
                }
                else
                    MessageBox.Show("Usuario correcto");
                return;
            }
        }


        private void BotonSalir(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnTabLoginClick(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToElementState(GridPrincipal, "EstadoLogin", true);
            BtnTabSignUp.FontWeight = FontWeights.Normal;
            BtnTabSignUp.Foreground = new SolidColorBrush(Color.FromRgb(0x88, 0x88, 0x88));
            BtnTabLogin.FontWeight = FontWeights.Bold;
            BtnTabLogin.Foreground = new SolidColorBrush(Color.FromRgb(0x11, 0x11, 0x11));
            BtnInicioSesion.Content = "INICIAR SESIÓN";
        }

        private void BtnTabSignUpClick(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToElementState(GridPrincipal, "EstadoSignUp", true);
            BtnTabLogin.FontWeight = FontWeights.Normal;
            BtnTabLogin.Foreground = new SolidColorBrush(Color.FromRgb(0x88, 0x88, 0x88));
            BtnTabSignUp.FontWeight = FontWeights.Bold;
            BtnTabSignUp.Foreground = new SolidColorBrush(Color.FromRgb(0x11, 0x11, 0x11));
            BtnInicioSesion.Content = "REGISTRARSE";
        }

        private void OlvidasteContrasena(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Se ha enviado un correo electrónico de recuperación.");
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PlaceholderPassword.Visibility = txtPassword.Password.Length > 0 ? Visibility.Collapsed : Visibility.Visible;
        }

        private void AbrirLateral(object sender, RoutedEventArgs e)
        {
            MenuLateral.Visibility = Visibility.Visible;

            // Anima la posición X desde 240 (fuera de pantalla) hasta 0 (posición visible)
            DoubleAnimation animAbrir = new DoubleAnimation
            {
                From = 240,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.25),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };
            TransfMenu.BeginAnimation(TranslateTransform.XProperty, animAbrir);
        }

        private void CerrarLateral(object sender, RoutedEventArgs e)
        {
            // Anima la posición X de vuelta a 240
            DoubleAnimation animCerrar = new DoubleAnimation
            {
                From = 0,
                To = 240,
                Duration = TimeSpan.FromSeconds(0.20),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseIn }
            };

            // Al terminar la animación, oculta el menú
            animCerrar.Completed += (s, ev) => MenuLateral.Visibility = Visibility.Collapsed;
            TransfMenu.BeginAnimation(TranslateTransform.XProperty, animCerrar);
        }
    }
}