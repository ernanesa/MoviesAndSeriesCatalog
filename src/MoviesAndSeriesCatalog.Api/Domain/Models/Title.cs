namespace MoviesAndSeriesCatalog.Api.Domain.Models
{
    public class Title(Guid id, string name,string? synopsis, int releaseYear, TitleType type, List<Genre> genres)
    {
        public Guid Id { get; private set;} = id;
        public string Name { get; private set;} = name;
        public string? Synopsis { get; private set;} = synopsis;
        public int ReleaseYear { get; private set;} = releaseYear;
        public TitleType Type { get; private set;} = type;
        public List<Genre> Genres { get; private set;} = genres;
    }
}