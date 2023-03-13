using NLog;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");

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


logger.Info("Program ended");
