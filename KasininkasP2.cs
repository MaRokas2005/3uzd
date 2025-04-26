namespace _3uzd
{
    public class KasininkasP2(int aptarnavimoTrukmė)
    {
        private static int skaitiklis = 0;
        public string Id { get; init; } = $"Kasininkas_{++skaitiklis}";
        public KlientasP2? Klientas { get; private set; } = null;
        public int AptarnavimoLaikas { get; set; }
        public override string ToString() => $"{Id} {(Klientas == null ? "laisvas" : $"aptarnauja klientą {Klientas.Id}, liko {aptarnavimoTrukmė - AptarnavimoLaikas} {Parduotuvė.GaukMinučiųŽymę(aptarnavimoTrukmė - AptarnavimoLaikas)}")}";
        public void PradėtiAptarnavimą(KlientasP2 klientas)
        {
            Klientas = klientas;
            AptarnavimoLaikas = 0;
        }
        public void BaigtiAptarnavimą()
        {
            if (Klientas == null)
                throw new InvalidOperationException("Kasininkas negali baigti aptarnavimo, nes jis nieko neaptarnauja.");
            if (Klientas.Pardavėjas == null)
                throw new InvalidOperationException($"Klientas {Klientas.Id} nebuvo apsilankęs pas pardavėją.");
            Klientas.ArSusimokėjoUžPrekes = true;
            Klientas.LaukimoLaikas += aptarnavimoTrukmė;
            Klientas.Pardavėjas.PoKasininko.Enqueue(Klientas);
            Klientas = null;
            AptarnavimoLaikas = -1;
        }
        public static void NunulintiSkaitliuką() => skaitiklis = 0;
    }
}