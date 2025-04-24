namespace _3uzd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(!Directory.Exists("./../../../Protokolai"))
            {
                Directory.CreateDirectory("./../../../Protokolai");
            }
            int N;
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
