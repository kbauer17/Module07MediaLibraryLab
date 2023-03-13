using NLog;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");

/*
Movie movie = new Movie
{
    mediaId = 123,
    title = "Greatest Movie Ever, The (2023)",
    director = "Jeff Grissom",
    // timespan (hours, minutes, seconds)
    runningTime = new TimeSpan(2, 21, 23),
    genres = { "Comedy", "Romance" }
};

Console.WriteLine(movie.Display());

Album album = new Album
{
    mediaId = 321,
    title = "Greatest Album Ever, The (2020)",
    artist = "Jeff's Awesome Band",
    recordLabel = "Universal Music Group",
    genres = { "Rock" }
};
Console.WriteLine(album.Display());

Book book = new Book
{
    mediaId = 111,
    title = "Super Cool Book",
    author = "Jeff Grissom",
    pageCount = 101,
    publisher = "",
    genres = { "Suspense", "Mystery" }
};
Console.WriteLine(book.Display());
*/

string scrubbedFile = FileScrubber.ScrubMovies("movies.csv");
logger.Info(scrubbedFile);

MovieFile movieFile = new MovieFile(scrubbedFile);

string choice = "";
do
{
  // display choices to user
  Console.WriteLine("1) Add Movie");
  Console.WriteLine("2) Display All Movies");
  Console.WriteLine("Enter to quit");
  // input selection
  choice = Console.ReadLine();
  
  if (choice == "1")
  {
    // Add movie
    Movie movie = new Movie();
    // ask user to input movie title
    Console.WriteLine("Enter movie title");
    // input title
    movie.title = Console.ReadLine();
    // verify title is unique
    if (movieFile.isUniqueTitle(movie.title)){
      // input genres
      string input;
      do
      {
        // ask user to enter genre
        Console.WriteLine("Enter genre (or done to quit)");
        // input genre
        input = Console.ReadLine();
        // if user enters "done"
        // or does not enter a genre do not add it to list
        if (input != "done" && input.Length > 0)
        {
          movie.genres.Add(input);
        }
      } while (input != "done");
      // specify if no genres are entered
      if (movie.genres.Count == 0)
      {
        movie.genres.Add("(no genres listed)");
      }
            // add movie
      movieFile.AddMovie(movie);
    }
  } else if (choice == "2")
  {
    // Display All Movies
    foreach(Movie m in movieFile.Movies)
    {
      Console.WriteLine(m.Display());
    }
  }
  logger.Info("User choice: {Choice}", choice);
} while (choice == "1" || choice == "2");


logger.Info("Program ended");
