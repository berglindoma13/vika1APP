using System;
using DM.MovieApi;

namespace HelloWorld
{
    public class MyClass : IMovieDbSettings
    {
        public string ApiKey
        {
            set { ApiKey = "933832d8d52af17d616ac7be600e4f8c"; }
            get { return ApiKey; }
        }
        public string ApiUrl
        {
            set { ApiUrl = "https://api.themoviedb.org/3/search/movie?api_key="; }
            get { return ApiUrl; }
        }

        public MyClass()
        {
            
        }



    }
}

