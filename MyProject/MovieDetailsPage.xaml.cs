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

namespace MyProject
{
    /// <summary>
    /// Interaction logic for MovieDetailsPage.xaml
    /// </summary>
    /// 
    public partial class MovieDetailsPage : Page
    {
        Movie Movie { get; set; }
        private readonly MovieService _movieService;
        public MovieDetailsPage(Movie movie)
        {
            Movie = movie;
            _movieService = new MovieService();

            InitializeComponent();
            DataContext = new MoviesDetailViewModel(movie,_movieService);  
        }

        private void GoBackToHomePage(object sender, RoutedEventArgs e)
        {
            var mainFrame = Application.Current.MainWindow.FindName("MainFrame") as Frame;

            mainFrame?.Navigate(new HomePage());
        }
    }
}
