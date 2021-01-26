namespace CanHazFunny
{
    class Program
    {
        static void Main(string[] args)
        {
            Jester joke = new Jester(new JokeService(), new JokeOutput());
            joke.TellJoke();
        }
    }
}
