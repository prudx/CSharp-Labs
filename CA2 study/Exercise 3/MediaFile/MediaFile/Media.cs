using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//x00127907 daniel maguire
namespace Media
{
    public abstract class MediaFile
    {
        string filename;

        public string Filename
        {
            get
            {
                return filename;
            }
            set
            {
                // validate the input
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Filename cannot be null");
                }
                filename = value;
            }
        }

        public MediaFile(string fileN)
        {
            filename = fileN;
        }

        public override string ToString()
        {
            return "Filename: " + Filename;
        }

    }

    public enum Genre { Pop, Rock, Dance, HipHop, Rap, Other }

    public class MusicFile : MediaFile
    {
        private string title;
        private string artist;
        public Genre Genre { get; }


        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Title cannot be null");
                }
                title = value;
            }
        }

        public string Artist
        {
            get
            {
                return artist;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Artist cannot be null");
                }
                artist = value;
            }
        }

        public MusicFile(string filename, string title, string artist, Genre genre) : base(filename)
        {
            Title = title;
            Artist = artist;
            Genre = genre;
        }

        public MusicFile(string filename, string title, string artist) : base(filename)
        {
            Title = title;
            Artist = artist;
            Genre = Genre.Other;
        }

        public override string ToString()
        {
            return base.ToString() +"\nTitle: "+Title+"\nArtist: "+Artist+"\nGenre: "+Genre+"\n";
        }
    }

    public class Playlist : IEnumerable
    {
        string PlaylistName { get; set; }
        public List<MusicFile> Songs { get; }

        public Playlist(string playlistName)
        {
            PlaylistName = playlistName;
            Songs = new List<MusicFile>();
        }

        public void AddMusicFile(MusicFile newSong)
        {
            if (Songs == null)
            {
                Songs.Add(newSong);
            }
            else
            {
                foreach (MusicFile song in Songs)
                {
                    if (song.Title == newSong.Title && song.Artist == newSong.Artist)
                    {
                        throw new Exception("Songs in playlist must be unique");
                    }
                }
                Songs.Add(newSong);
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (MusicFile m in Songs)
            {
                yield return m;
            }
        }


        public IEnumerable<MusicFile> this[Genre genre]
        {
            get
            {
                var tracksForGenre = Songs.Where(song => song.Genre == genre);           // LINQ query, select the whole music file
                return tracksForGenre;
            }
        }
    }

    class Test
    {
        public static void Main()
        {
            
            MusicFile song = new MusicFile("AmericanIdiot.mp3", "American Idiot", "Greenday", Genre.Rock);
            MusicFile song2 = new MusicFile("Song 2.mp3", "Song 2", "Blur", Genre.Rock);
            MusicFile song3 = new MusicFile("I Wont Let You Down.mp3", "I Wont Let You Down", "Ok Go", Genre.Pop);
            
            Playlist p1 = new Playlist("Cool songs");

            p1.AddMusicFile(song);
            p1.AddMusicFile(song2);
            p1.AddMusicFile(song3);


            foreach (MusicFile track in p1)
            {
                Console.WriteLine(track);
            }

            MediaFile song4 = new MusicFile("", "American Idiot", "Greenday", Genre.Rock);



            Console.ReadLine();
        }
    }
}
        

    

