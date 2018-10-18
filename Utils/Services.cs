using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data.Linq;

namespace MovieRecommenderSystem.Utils
{
    class Services
    {

        public static void initiateDataFromFile(string folderPath) {

            string tempUserId = "";
            TwitterUser user;
            UserMovieRank movieRank;
            Genre genre;
            Movie movie;
            MovieGenre movieGenre;
            //List<Genre> genresList = new List<Genre>();


            Dictionary<string, TwitterUser> userDir = new Dictionary<string, TwitterUser>();
            ImdbDataClassDataContext context = new ImdbDataClassDataContext();

            foreach (string file in Directory.EnumerateFiles(folderPath, "*.txt"))
            {
                //read all user txt files and parse to TwitterUser objects
                if (Path.GetFileName(file).Contains("user"))
                {
                    user = new TwitterUser();
                    var userSp = File.ReadAllText(file).Split(':', '\n');
                    // set TwitterUser object properties  
                    for (int i = 0; i < userSp.Length; i++)
                    {

                        if (userSp[i].Equals("TwitterId"))
                        {
                            tempUserId = userSp[i + 1].Trim();// save temp id to Match movies txt file id  
                        }
                        else if (userSp[i].Equals("ScreenName"))
                        {
                            user.userName = userSp[i + 1].Trim();// set TwitterUser object Name property  
                        }
                        else if (userSp[i].Equals("FollowersNumber"))
                        {
                            user.followNum = Convert.ToInt16(userSp[i + 1].Trim());// set TwitterUser object FollowersNumber property 

                        }
                                                                                        
                    }
                    context.TwitterUsers.InsertOnSubmit(user);
                    userDir.Add(tempUserId, user);// Dictionary (like Java's HashMap) holeds (key, value) set 

                }

            } // End foreach statement 

            context.SubmitChanges();

            //foreach Dictionary key ID open movie file with the same ID ~ for example ID 1 will open C:\MyDir\...\movies_1.txt file
            foreach (string userKey in userDir.Keys)
            {
                string filePath = folderPath + @"\movies_" + userKey+".txt";
                
                if (File.Exists(filePath))// check if file Exists
                {
                    // Split file to lines <~ NOTE each line represents Movie object ~>
                    var movieLine = File.ReadAllText(filePath).Split('\n');

                    foreach (var line in movieLine)
                    {
                        
                        movieRank = new UserMovieRank();

                        if (line.Length > 0)
                        {                      
                            var matcheName = Regex.Match(line, "(?<=\\d\\s)([\\D]+).*(?=\\s+\\()");
                            
                            if (!context.Movies.Any(m => m.movieName == matcheName.ToString())) {
                                movie = new Movie();
                                movie.movieName = matcheName.ToString();

                            var matcheRank = Regex.Match(line, "(?<=\\d\\s)([\\d]+)");
                            movieRank.movieRank = Convert.ToByte(matcheRank.ToString());

                            var matcheYear = Regex.Match(line, "(?<=\\().+?(?=\\))");
                            movie.publishYear = Convert.ToInt16(matcheYear.ToString());

                            var matcheGenres = Regex.Matches(line, "(((?<=\\::)|(?<=\\|))([\\w]+)((?<=\\S)|(?<=\\|)))");
                            var genresResult = String.Join(" ", matcheGenres.Cast<Match>().Select(m => m.Value)).Split(' ');
                            
                            //foreach Genre in genresResult create a new Genre object and add it to MovieGenre
                            foreach (string gen in genresResult)
                            {
                                if (!context.Genres.Any(g => g.genreName == gen))
                                {
                                    genre = new Genre();
                                    genre.genreName = gen;
                                    movieGenre = new MovieGenre();
                                    movieGenre.Genre = genre;
                                    movieGenre.Movie = movie;
                                    movie.MovieGenres.Add(movieGenre);
                                    context.Genres.InsertOnSubmit(genre);
                                    context.MovieGenres.InsertOnSubmit(movieGenre);
                                }
                                else
                                {
                                    movieGenre = new MovieGenre();
                                    movieGenre.Genre = context.Genres.First(d => d.genreName == gen);
                                    movieGenre.Movie = movie;
                                    movie.MovieGenres.Add(movieGenre);
                                    context.MovieGenres.InsertOnSubmit(movieGenre);
                                }
                                

                            }// End foreach statement 

                            movieRank.Movie = movie;
                            movieRank.TwitterUser = userDir[userKey];                           
                            context.Movies.InsertOnSubmit(movie);
                            context.UserMovieRanks.InsertOnSubmit(movieRank);
                            try
                            {
                                context.SubmitChanges();
                            }
                            catch (Exception e)
                            {
                                Debug.WriteLine(e.ToString());
                            }

                            }
                            else
                            {
                                var matcheRank = Regex.Match(line, "(?<=\\d\\s)([\\d]+)");
                                movieRank.movieRank = Convert.ToByte(matcheRank.ToString());

                                movieRank.Movie = context.Movies.First(n => n.movieName == matcheName.ToString()); ;
                                movieRank.TwitterUser = userDir[userKey];                              
                                context.UserMovieRanks.InsertOnSubmit(movieRank);
                                try
                                {
                                    context.SubmitChanges();
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine(e.ToString());
                                }
                            }
                      }
                    }

                }

            } // End foreach statement 

        }// End method initiateDataFromFile()

        //determine whether the sentence contains only letters and numbers
        public static Boolean isNumbersLetters(TextBox t)
        {
            if ((Regex.IsMatch(t.Text, @"^[a-zA-Z0-9# ]+$") || Regex.IsMatch(t.Text, "^[0-9]$")) && !Regex.IsMatch(t.Text, "^\\d[^<]+"))
                return true;
            else return false;
        }// End method isNumbersLetters()

        public static string genersToList(EntitySet<MovieGenre> geners )
        {
            ImdbDataClassDataContext context = new ImdbDataClassDataContext();
            StringBuilder add = new StringBuilder();
            foreach (var item in geners)
            {
                if(item != geners.Last())
                {
                    add.Append(context.Genres.First(g => g.genreId == item.genreId).genreName+", ");
                }
                else
                {
                    add.Append(context.Genres.First(g => g.genreId == item.genreId).genreName);
                }
            }
            return add.ToString();
        }// End method genersToList()

        public static IQueryable mostWatchedMovies(string userName)
        {
            ImdbDataClassDataContext context = new ImdbDataClassDataContext();
            var result = (from movie in context.Movies                        
                          where  !(from u in movie.UserMovieRanks select u.TwitterUser.userName).Contains(userName)
                          orderby movie.UserMovieRanks.Count descending
                          select new
                            {                                        
                               ID = movie.movieId,
                               Name = movie.movieName,
                               Year = movie.publishYear,
                               Genres = genersToList(movie.MovieGenres),
                               Watched = movie.UserMovieRanks.Count,
                               Trailer = "Watch trailer..."
                            }).Take(5);

            return result;
        }// End method mostWatchedMovies()

        public static IQueryable mostPopularMovies(String userName)
        {
            ImdbDataClassDataContext context = new ImdbDataClassDataContext();
            //var result = (from u in context.UserMovieRanks
            //              where u.TwitterUser.userName != userName
            //              group new { u.Movie, u } by new
            //              {
            //                  u.Movie.movieId,
            //                  u.Movie.movieName,
            //                  u.Movie.publishYear                             
            //              } into g
            //              orderby
            //                (double?)g.Average(p => p.u.movieRank) descending
            //              select new
            //              {
            //                  ID = g.Key.movieId,
            //                  Name = g.Key.movieName,
            //                  Year = g.Key.publishYear,
            //                  AverageRank = (double?)g.Average(p => p.u.movieRank),
            //                  //Genres = 
            //                  Trailer = "Watch trailer..."
            //              }).Take(5);

            var result = (from movie in context.Movies
                          where !(from u in movie.UserMovieRanks select u.TwitterUser.userName).Contains(userName)
                          orderby movie.UserMovieRanks.Average(a => a.movieRank) descending
                          select new
                          {
                              ID = movie.movieId,
                              Name = movie.movieName,
                              Year = movie.publishYear,
                              Genres = genersToList(movie.MovieGenres),
                              AverageRank = movie.UserMovieRanks.Average(a => a.movieRank),
                              Trailer = "Watch trailer..."
                          }).Take(5);
            return result;
        }// End method mostPopularMovies()

        public static IQueryable mostPopularUser(String userName)
        {
            ImdbDataClassDataContext context = new ImdbDataClassDataContext();           

            var result = from movie in context.UserMovieRanks
                         let user = (from u in context.TwitterUsers
                                     orderby u.followNum descending
                                     select u).FirstOrDefault()
                         where movie.userId.Equals(user.userId) && movie.TwitterUser.userName != userName
                         orderby movie.movieRank descending
                         select new
                         {
                             ID = movie.Movie.movieId,
                             Name = movie.Movie.movieName,
                             Year = movie.Movie.publishYear,
                             Genres = genersToList(movie.Movie.MovieGenres),
                             Rank = movie.movieRank,
                             User = user.userName,
                             Followers = user.followNum,
                             Trailer = "Watch trailer..."
                         };


            return result.AsQueryable();
        }// End method mostPopularUsers()

        public static IQueryable usersWithSimilarTastes(String userName)
        {
            ImdbDataClassDataContext context = new ImdbDataClassDataContext();

            //query to get the selected userId from userName
            var param_user = (from user in context.TwitterUsers
                                  where user.userName == userName
                                  select user.userId);

            //get the user with the most commons movies
            var user_res = (from u1 in context.UserMovieRanks
                          join u2 in context.UserMovieRanks on u1.movieId equals u2.movieId
                          where
                            u1.userId == param_user.First() &&
                            u2.userId != param_user.First()
                          group u2 by new
                          {
                              u2.userId
                          } into g
                          orderby
                            g.Count(p => p.userId != null) descending
                          select new
                          {
                              g.Key.userId,
                              cnt = g.Count(p => p.userId != null)
                          }).Take(1);

            //get the userId
            var userid = (from user in user_res
                            select user.userId);

            //get the movies that the sekected user didnt watch but the other one did.
            var result = from Movies in context.Movies
                         where
                             (from UserMovieRanks in context.UserMovieRanks
                              where
                                UserMovieRanks.userId == userid.First() &&
                                !
                                  (from UserMovieRanks0 in context.UserMovieRanks
                                   where
                                     UserMovieRanks0.userId == param_user.First()
                                   select new
                                   {
                                       UserMovieRanks0.movieId
                                   }).Contains(new { movieId = UserMovieRanks.movieId })
                              select new
                              {
                                  UserMovieRanks.movieId
                              }).Contains(new { movieId = Movies.movieId })
                         select new
                         {
                             ID = Movies.movieId,
                             Name = Movies.movieName,
                             Year = Movies.publishYear,
                             Genres = genersToList(Movies.MovieGenres),
                             Trailer = "Watch trailer..."
                         };

            return result;
        }// End method UsersWithSimilarTastes()

        public static IQueryable userGenrePreferences(String userName)
        {
            ImdbDataClassDataContext context = new ImdbDataClassDataContext();

            //query to get the selected userId from userName
            var param_user = (from user in context.TwitterUsers
                              where user.userName == userName
                              select user.userId);

            //return the movie's ids the the user didnt watch
            var movies = from UserMovieRanks in context.UserMovieRanks
                         where
                           UserMovieRanks.userId != param_user.First() &&
                             (from MovieGenres in context.MovieGenres
                              where
                                  ((from ranks in context.UserMovieRanks
                                    join g in context.MovieGenres on ranks.movieId equals g.movieId
                                    where
                                      ranks.userId == param_user.First()
                                    group g by new
                                    {
                                        g.genreId
                                    } into g
                                    orderby
                                      g.Count(p => p.genreId != null) descending
                                    select new
                                    {
                                        g.Key.genreId
                                    }).Take(1)).Contains(new { genreId = MovieGenres.genreId })
                              select new
                              {
                                  MovieGenres.movieId
                              }).Contains(new { movieId = UserMovieRanks.movieId })
                         group UserMovieRanks by new
                         {
                             UserMovieRanks.movieId
                         } into g
                         orderby
                           g.Average(p => p.movieRank) descending
                         select new
                         {
                             g.Key.movieId,
                             avg_rank = (double?)g.Average(p => p.movieRank)
                         };

            //the sql for this query
            //select movieid from usermovierank where userid<>1 and movieid in
            //(
            //select movieid from MovieGenre where genreId in
            //(
            //select top 1 g.genreId from usermovierank ranks
            //inner join moviegenre g on ranks.movieid=g.movieid
            //where userid=1
            //group by g.genreId
            //order by count(g.genreId) desc
            //)
            //)
            //group by movieId
            //order by avg(movierank) desc


            //joins the ids with the movies table to get the movies information for display
            var result = from item in movies
                         join original_movies in context.Movies on item.movieId equals original_movies.movieId
                         select new
                         {
                             ID = original_movies.movieId,
                             Name = original_movies.movieName,
                             Year = original_movies.publishYear,
                             Genres = genersToList(original_movies.MovieGenres),
                             Average_Rank = item.avg_rank,
                             Trailer = "Watch trailer..."
                         };


            return result;
        }// End method UserGenrePreferences()


    }
}
