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
using ClassLibrary1;

namespace WpfApp1
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
        private int x;
        private List<BaseBook> lstBooks = new List<BaseBook>();

        private void btn_prev_book_Click(object sender, RoutedEventArgs e)
        {
            lstBooks = BaseBook.TakeList();
            if (x - 1 >= 0)
            {
                x--;
                FillBookData();
            }
            else
            {
                x = lstBooks.Count - 1;
                FillBookData();
            }
        }

        private void btn_next_book_Click(object sender, RoutedEventArgs e)
        {
            lstBooks = BaseBook.TakeList();
            if (x + 1 <= lstBooks.Count - 1)
            {
                x++;
                FillBookData();
            }
            else
            {
                x = 0;
                FillBookData();
            }
        }

        private void FillBookData()
        {
            try
            {
                txt_name_book.Text = lstBooks[x].Name;
                txt_autor_book.Text = lstBooks[x].Autor;
                txt_izdatelstvo_book.Text = lstBooks[x].Izdatelstvo;
                txt_year_book.Text = lstBooks[x].Year;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удается загрузить с базы \n {ex.Message}");
            }
        }

        private void btn_add_book_Click(object sender, RoutedEventArgs e)
        {
            Collection book = new Book(txt_name_book.Text, txt_autor_book.Text, txt_izdatelstvo_book.Text, txt_year_book.Text);
            book.Add();
        }

        private void btn_reduct_book_Click(object sender, RoutedEventArgs e)
        {
            Collection book = new Book(txt_name_book.Text, txt_autor_book.Text, txt_izdatelstvo_book.Text, txt_year_book.Text);
            book.Reduct(lstBooks[x]._id.ToString());
        }

        private void btn_delete_book_Click(object sender, RoutedEventArgs e)
        {
            Collection book = new Book(txt_name_book.Text, txt_autor_book.Text, txt_izdatelstvo_book.Text, txt_year_book.Text);
            book.Delete(lstBooks[x]._id.ToString());
        }

        private void btn_add_pazzle_Click(object sender, RoutedEventArgs e)
        {
            Collection pazzle = new Pazzle(txt_name_pazzle.Text, Convert.ToInt32(txt_count_of_elem_pazzle.Text), txt_name_company_pazzle.Text);
            pazzle.Add();
        }

        private void btn_reduct_pazzle_Click(object sender, RoutedEventArgs e)
        {
            Collection pazzle = new Pazzle(txt_name_pazzle.Text, Convert.ToInt32(txt_count_of_elem_pazzle.Text), txt_name_company_pazzle.Text);
            pazzle.Reduct(lstPazzles[x]._id.ToString());
        }
    }
}
