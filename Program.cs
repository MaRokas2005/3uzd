namespace _3uzd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N;
            if(!Directory.Exists("./Protokolai"))
            {
                Directory.CreateDirectory("./Protokolai");
            }
            do
            {
                Console.Write("Įveskite testų skaičių: ");
            } while (!int.TryParse(Console.ReadLine(), out N));
            for (int i = 0; i < N; i++)
            {
                Testas testas = new Testas();
                testas.PaleistiTestą();
            }
        }
    }
}