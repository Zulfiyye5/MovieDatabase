using System.Collections.Generic;

using Microsoft.Data.SqlClient;
namespace MyProject
{
    public class MovieService
    {
        private readonly string connectionString = "Dataa Source=DESKTOP-U5F3V0U\\SQLEXPRESS;Initial Catalog=moviesDatabase;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";  

       
        public List<Movie> GetAllMovies()
        {
            var movies = new List<Movie>();
            string query = "SELECT * FROM Movie";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    movies.Add(new Movie
                    {
                        dbId = Convert.ToInt32(reader["dbId"]),
                        Title = reader["Title"].ToString(),
                        Overview = reader["Overview"].ToString(),
                        Image_path = reader["image_path"].ToString(),
                        Bg_image_path = reader["bg_image_path"].ToString(),
                        Imdb = Convert.ToInt32(reader["Imdb"]),
                        Origin_country = reader["Origin_country"].ToString(),
                        Origin_language = reader["Origin_language"].ToString(),
                        Director_name = reader["Director_name"].ToString(),
                        Runtime = Convert.ToInt32(reader["Runtime"]),
                        WatchList = Convert.ToInt32(reader["WatchList"]),
                        Liked = Convert.ToInt32(reader["Liked"]),
                        Watched = Convert.ToInt32(reader["Watched"]),
                        ReleaseDate = reader["release_date"].ToString()
                    
                     
                    });
                }

            }
            return movies;
        }
        public Movie FindMovieById(int movieId)
        {
            Movie movie = null;

            string query = "SELECT dbId, Title, PosterUrl FROM Movie WHERE dbId = @movieId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@movieId", movieId);  

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            movie = new Movie
                            {
                                dbId = reader.GetInt32(0),         
                                Title = reader.GetString(1),       
                                Image_path = reader.GetString(2)  
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return movie;
        }

        public List<Genre> FindGenreByMovieId(int movieId)
        {
            List<Genre> genres = new List<Genre>();

            string query = @"
        SELECT g.dbId, g.name 
        FROM MovieGenre mg
        JOIN Genre g ON mg.genre_id = g.dbId
        WHERE mg.movie_id = @movieId;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@movieId", movieId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Genre genre = new Genre
                        {
                  
                            Name = reader.GetString(reader.GetOrdinal("name"))
                        };

                        genres.Add(genre);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return genres;
        }

        public List<MovieCast> FindCastByMovieId(int movieId)
        {
            List<MovieCast> cast = new List<MovieCast>();

             string query = @"
SELECT p.image_path, mg.character_name, mg.person_id,p.person_name
FROM MovieCast mg
JOIN Person p ON mg.person_id = p.dbId
JOIN Movie g ON mg.movie_id = g.dbId
WHERE g.dbId = @movieId;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@movieId", movieId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        MovieCast person = new MovieCast
                        {
                            Name = reader.GetString(reader.GetOrdinal("person_name")),
                            Person_id = reader.GetInt32(reader.GetOrdinal("person_id")),
                            Character_name = reader.GetString(reader.GetOrdinal("character_name")),
                           image_url = reader.GetString(reader.GetOrdinal("image_path"))
                        };

                        cast.Add(person);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return cast;
        }


    }
}
