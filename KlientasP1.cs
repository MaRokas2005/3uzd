namespace _3uzd
{
    public class KlientasP1 : IKlientas
    {
        private static int skaitiklis = 0;
        public string Id { get; init; }
        public int LaukimoLaikas { get; set; } = 0;
        public KlientasP1()
        {
            Id = $"K{++skaitiklis}";
        }
        public override string ToString() => $"{Id}, laukia {LaukimoLaikas} min";
        public static void NunulintiSkaitliuką() => skaitiklis = 0;
    }
}