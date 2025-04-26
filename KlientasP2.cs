namespace _3uzd
{
    public class KlientasP2 : IKlientas
    {
        private static int skaitiklis = 0;
        public string Id { get; init; }
        public int LaukimoLaikas { get; set; } = 0;
        public bool ArSusimokėjoUžPrekes { get; set; } = false;
        public PardavėjasP2? Pardavėjas { get; set; } = null;
        public KlientasP2()
        {
            Id = $"Klientas_{++skaitiklis}";
        }
        public override string ToString() => $"{Id}, laukia {LaukimoLaikas} min";
        public static void NunulintiSkaitliuką() => skaitiklis = 0;
    }
}