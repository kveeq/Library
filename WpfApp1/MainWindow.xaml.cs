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
        private int x = 0;
        private int y = 0;
        private int z = 0;
        private List<BaseBook> lstBooks;
        private List<BasePazzle> lstPazzles;
        private List<BaseGame> lstGames;


        public MainWindow()
        {
            InitializeComponent();
            FillBookData();
            FillPazzleData();
            FillGameData();
        }

        // заполнение данными
        private void FillBookData()
        {
            try
            {
                lstBooks = BaseBook.TakeList();
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
        
        private void FillPazzleData()
        {
            try
            {
                lstPazzles = BasePazzle.TakeList();
                txt_name_pazzle.Text = lstPazzles[y].Name;
                txt_count_of_elem_pazzle.Text = lstPazzles[y].Count_of_elem.ToString();
                txt_name_company_pazzle.Text = lstPazzles[y].Company_name;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удается загрузить с базы \n {ex.Message}");
            }
        }  
        
        private void FillGameData()
        {
            try
            {
                lstGames = BaseGame.TakeList();
                txt_name_game.Text = lstGames[z].Name;
                txt_developer_game.Text = lstGames[z].Developer;
                txt_description_game.Text = lstGames[z].Description;
                txt_count_of_players_game.Text = lstGames[z].Count_of_players.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удается загрузить с базы \n {ex.Message}");
            }
        }


        // Книги
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

        // Передвижение
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


        // Пазл
        private void btn_add_pazzle_Click(object sender, RoutedEventArgs e)
        {
            tryFormatPazzle();
            Collection pazzle = new Pazzle(txt_name_pazzle.Text, Convert.ToInt32(txt_count_of_elem_pazzle.Text), txt_name_company_pazzle.Text);
            pazzle.Add();
        }

        private void btn_reduct_pazzle_Click(object sender, RoutedEventArgs e)
        {
            tryFormatPazzle();
            Collection pazzle = new Pazzle(txt_name_pazzle.Text, Convert.ToInt32(txt_count_of_elem_pazzle.Text), txt_name_company_pazzle.Text);
            pazzle.Reduct(lstPazzles[y]._id.ToString());
        }

        private void btn_delete_pazzle_Click(object sender, RoutedEventArgs e)
        {
            tryFormatPazzle();
            Collection pazzle = new Pazzle(txt_name_pazzle.Text, Convert.ToInt32(txt_count_of_elem_pazzle.Text), txt_name_company_pazzle.Text);
            pazzle.Delete(lstPazzles[y]._id.ToString()) ;
        }

        private void tryFormatPazzle()
        {
            try
            {
                Convert.ToInt32(txt_count_of_elem_pazzle.Text);
            }
            catch
            {
                MessageBox.Show("Неправильный формат количество элементов");
            }
        }

        // Передвижение
        private void btn_next_pazzle_Click(object sender, RoutedEventArgs e)
        {
            lstPazzles = BasePazzle.TakeList();
            if (y + 1 <= lstPazzles.Count - 1)
            {
                y++;
                FillPazzleData();
            }
            else
            {
                y = 0;
                FillPazzleData();
            }
        }

        private void btn_prev_pazzle_Click(object sender, RoutedEventArgs e)
        {
            lstPazzles = BasePazzle.TakeList();
            if (y - 1 >= 0)
            {
                y--;
                FillPazzleData();
            }
            else
            {
                y = lstPazzles.Count - 1;
                FillPazzleData();
            }
        }


        // настольные игры
        private void btn_add_game_Click(object sender, RoutedEventArgs e)
        {
            tryFormatGame();
            Collection game = new Game(txt_name_game.Text, txt_developer_game.Text, txt_description_game.Text, Convert.ToInt32(txt_count_of_players_game.Text));
            game.Add();
        }

        private void btn_delete_game_Click(object sender, RoutedEventArgs e)
        {
            tryFormatGame();
            Collection game = new Game(txt_name_game.Text, txt_developer_game.Text, txt_description_game.Text, Convert.ToInt32(txt_count_of_players_game.Text));
            game.Delete(lstGames[z]._id.ToString());
        }

        private void btn_reduct_game_Click(object sender, RoutedEventArgs e)
        {
            tryFormatGame();
            Collection game = new Game(txt_name_game.Text, txt_developer_game.Text, txt_description_game.Text, Convert.ToInt32(txt_count_of_players_game.Text));
            game.Reduct(lstGames[z]._id.ToString());
        }
        
        // Передвижение
        private void btn_next_game_Click(object sender, RoutedEventArgs e)
        {
            lstGames = BaseGame.TakeList();
            if (z + 1 <= lstGames.Count - 1)
            {
                z++;
                FillGameData();
            }
            else
            {
                z = 0;
                FillGameData();
            }
        }

        private void btn_prev_game_Click(object sender, RoutedEventArgs e)
        {
            lstGames = BaseGame.TakeList();
            if (z - 1 >= 0)
            {
                z--;
                FillGameData();
            }
            else
            {
                z = lstGames.Count - 1;
                FillGameData();
            }
        }

        private void tryFormatGame()
        {
            try
            {
                Convert.ToInt32(txt_count_of_players_game.Text);
            }
            catch
            {
                MessageBox.Show("Неправильный формат количествa игроков");
            }
        }
    }
}
