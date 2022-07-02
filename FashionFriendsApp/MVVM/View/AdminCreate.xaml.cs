using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace FashionFriendsApp.MVVM.View
{
    /// <summary>
    /// Interaction logic for AdminCreate.xaml
    /// </summary>
    public partial class AdminCreate : UserControl
    {
        private static readonly Regex regex = new Regex("[^0-9.-]+");
        public AdminCreate()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            txtCena.Text = "";
            txtNaziv.Text = "";
            txtSlika.Text = "";
            imgPhoto.Source = null;
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Izaberite sliku";
            op.Filter = "Podrzani fajlovi|*.jpg;*.jpeg;*.png|"+
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|"+
                "Portable Network Graphic (*.png)|*.png";
            if(op.ShowDialog() == true)
            {
                txtSlika.Text = op.FileName;
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
            }
        }


        private void txtCena_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
            if(e.Handled == true)
            {
                errorText.Text = "Molimo vas da unesete samo cifre!";
            }
            else
            {
                errorText.Text = "";
            }
        }

        private bool IsTextAllowed(string text)
        {
            return !regex.IsMatch(text);
        }

        private void productCreate_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCena.Text) && !String.IsNullOrEmpty(txtNaziv.Text) && !String.IsNullOrEmpty(txtSlika.Text))
            {

                string picture = txtSlika.Text;

                byte[] b = File.ReadAllBytes(picture);

                SqlConnection con = new SqlConnection(@"Data Source=localhost\sqlexpress; Initial Catalog=fashion&friends&backend; Integrated Security=True;");
                 con.Open();
                 SqlCommand sqlCommand = new SqlCommand("Insert into desktopProduct (Name, Price, PicturePath) values (@Name, @Price, @PicturePath)", con)
                 {
                     CommandType = CommandType.Text
                 };
                 sqlCommand.Parameters.AddWithValue("@Name", txtNaziv.Text);
                 sqlCommand.Parameters.AddWithValue("@Price", txtCena.Text);
                 sqlCommand.Parameters.AddWithValue("@PicturePath", txtSlika.Text);
                 sqlCommand.ExecuteNonQuery();
                 con.Close();
                 MessageBox.Show("Uspesno ste uneli proizvod u bazu!");
                 Reset();

            }
            else
            {
                MessageBox.Show("Molimo vas da unesete sve potrebne podatke!");
            }
        }
    }
}
