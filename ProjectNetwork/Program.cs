namespace ProjectNetwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Network networkExample = new Network(8);

            networkExample.Connect(1,6);
            networkExample.Connect(1,2);
            networkExample.Connect(6,2);
            networkExample.Connect(2,4);
            networkExample.Connect(5,8);
            networkExample.Connect(4, 8);

            Console.WriteLine(networkExample.LevelConnection(1,6));
            Console.WriteLine(networkExample.LevelConnection(1, 4));
            Console.WriteLine(networkExample.LevelConnection(1, 5));
            Console.WriteLine(networkExample.LevelConnection(5, 1));
            Console.WriteLine(networkExample.LevelConnection(5, 5));

            networkExample.Disconnet(5,8);
            Console.WriteLine(networkExample.LevelConnection(5, 1));

            Console.ReadLine();
        }
    }

    
}
