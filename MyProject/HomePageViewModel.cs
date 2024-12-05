using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;
using static System.Net.WebRequestMethods;

namespace MyProject
{
    public class HomePageViewModel
    {
        private readonly MovieService _movieService;

        public ObservableCollection<Movie> Movies { get; set; }
    
        public HomePageViewModel(MovieService movieService)
        {
            //_movieService = movieService;
            //Movies = new ObservableCollection<Movie>(_movieService.GetAllMovies());


            Movies = new ObservableCollection<Movie>()
{
    new Movie
    {
        dbId = 587,
        Image_path = "https://image.tmdb.org/t/p/w300//tjK063yCgaBAluVU72rZ6PKPH2l.jpg",
        Bg_image_path = "https://image.tmdb.org/t/p/w780//bLqUd0tBvKezDr9MEla7k34i3rp.jpg",
        Imdb = 8,
        Origin_country = "US",
        Origin_language = "en",
        Title="Big fish",
        Overview = "Throughout his life Edward Bloom has always been a man of big appetites, enormous passions and tall tales. In his later years, he remains a huge mystery to his son, William. Now, to get to know the real man, Will begins piecing together a true picture of his father from flashbacks of his amazing adventures.",
        ReleaseDate = "2003-12-25 00:00:00.000",
        Runtime = 125,
        Director_name = "Tim Burton",
    },
    new Movie
    {
        dbId = 453,
        Title="A Beutiful Mind",
        
        Image_path = "https://image.tmdb.org/t/p/w300//zwzWCmH72OSC9NA0ipoqw5Zjya8.jpg",
        Bg_image_path = "https://image.tmdb.org/t/p/w780//pRBBy46A54eiayd8zPbGOz2yKcH.jpg",
        Imdb = 8,
        Origin_country = "US",
        Origin_language = "en",
        Overview = "Brilliant mathematician, John Nash, is on the brink of international acclaim when he becomes entangled in a mysterious conspiracy.",
        ReleaseDate = "2001-12-14 00:00:00.000",
        Runtime = 135,
        Director_name = "Ron Howard",
    },
    new Movie
    {
        dbId = 124,
        Title="Little Women",
        Image_path = "https://image.tmdb.org/t/p/w300//yn5ihODtZ7ofn8pDYfxCmxh8AXI.jpg",
        Bg_image_path = "https://image.tmdb.org/t/p/w780//g6FTNDZutDR2QbWjfuAoH8ik0MU.jpg",
        Imdb = 7,
        Origin_country = "FR",
        Origin_language = "fr",
        Overview = "A beautiful journey through the life of a Parisian artist who discovers the meaning of life through his paintings.",
        ReleaseDate = "1998-09-18 00:00:00.000",
        Runtime = 118,
        Director_name = "Claude Lelouch",
    },
    // Add more movies here as needed
};


        }


    }
}
