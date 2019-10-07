using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace HashGenerator
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void gerarSal_Click(object sender, RoutedEventArgs e)
        {
            caixaSal.Text = gerarSalAleatorio();
        }

        private void gerarHash_Click(object sender, RoutedEventArgs e)
        {
            if (caixaTexto.Text != String.Empty)
            {
                string textoFinal = caixaTexto.Text + caixaSal.Text;
                HashAlgorithm hashCrip = SHA256.Create();
                byte[] bHash = hashCrip.ComputeHash(Encoding.UTF8.GetBytes(textoFinal));
                StringBuilder build = new StringBuilder();
                for (int ct = 0; ct < bHash.Length; ct++)
                {
                    build.Append(bHash[ct].ToString("x2"));
                }
                textoHash.Text = build.ToString();
            }
        }

        private string gerarSalAleatorio()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] bSalt = new byte[8];
            rng.GetBytes(bSalt);
            string salt = BitConverter.ToString(bSalt);
            rng.Dispose();
            return salt;
        }
    }
}
