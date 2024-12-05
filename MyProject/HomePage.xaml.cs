using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyProject
{
    public partial class HomePage : Page
    {
        private readonly MovieService _movieService;

        

        public HomePage()
        {
            InitializeComponent();
            _movieService = new MovieService();
         this.DataContext = new HomePageViewModel(_movieService);      
        }
        private void MovieItem_Click(object sender, MouseButtonEventArgs e)
        {
          
            var border = sender as Border;
            var movie = border?.DataContext as Movie;

            if (movie != null)
            {
                var mainFrame = Application.Current.MainWindow.FindName("MainFrame") as Frame;

                mainFrame?.Navigate(new MovieDetailsPage(movie)); 
            }
        }

    }
}
