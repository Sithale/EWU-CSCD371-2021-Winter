using System;

namespace CanHazFunny
{
    public class Jester
    {
        private IJokeService JokeService;
        private IJokeOutput JokeOutServ;

        public IJokeOutput JokeOut { get => JokeOutServ; set => JokeOutServ = value; }
        public IJokeService JokeServ { get => JokeService; set => JokeService = value; }

        public Jester(IJokeService jokeService, IJokeOutput outJoke)
        {
            if(jokeService == null || outJoke == null)
            {
                throw new ArgumentNullException(nameof(jokeService));
            }
            else
            {
                this.JokeOut = outJoke;
                this.JokeService = jokeService;
            }
        }

        public void TellJoke()
        {
            string theJoke = this.JokeService.GetJoke();

            while(theJoke.Contains("Chuck") || theJoke.Contains("Norris"))
            {
                theJoke = this.JokeService.GetJoke();
            }

            this.JokeOut.TellJoke(theJoke);
        }
    }
}
