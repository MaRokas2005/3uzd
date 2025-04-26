namespace _3uzd
{
    public class PardavėjasP2(int surašytiPrekes, int gautiPrekes) : IPardavėjas
    {
        private static int skaitiklis = 0;
        public string Id { get; init; } = $"Pardavėjas_{++skaitiklis}";
        public KlientasP2? Klientas { get; private set; } = null;
        public Queue<KlientasP2> PoKasininko { get; init; } = new Queue<KlientasP2>();
        public int AptarnavimoLaikas { get; set; }
        public int SurašytiPrekes { get; init; } = surašytiPrekes;
        public int GautiPrekes { get; init; } = gautiPrekes;

        public override string ToString()
        {
            if (Klientas == null)
                return $"{Id} laisvas";
            if (!Klientas.ArSusimokėjoUžPrekes)
                return $"{Id} surašo prekes klientui {Klientas.Id}, liko {surašytiPrekes - AptarnavimoLaikas} {Parduotuvė.GaukMinučiųŽymę(surašytiPrekes - AptarnavimoLaikas)}";
            return $"{Id} atneša prekes klientui {Klientas.Id}, liko {gautiPrekes - AptarnavimoLaikas} {Parduotuvė.GaukMinučiųŽymę(gautiPrekes - AptarnavimoLaikas)}";
        }
        public void PradėtiPrekiųSurašymą(ref KlientasP2 klientas)
        {
            Klientas = klientas;
            Klientas.Pardavėjas = this;
            AptarnavimoLaikas = 0;
        }
        public void BaigtiPrekiųSurašymą(ref Queue<KlientasP2> klientųEilėPasKasininkus)
        {
            if (Klientas == null)
                throw new InvalidOperationException("Pardavėjas negali baigti prekių surašymo, nes jis nieko neaptarnauja.");
            Klientas.LaukimoLaikas += surašytiPrekes;
            klientųEilėPasKasininkus.Enqueue(Klientas);
            Klientas = null;
            AptarnavimoLaikas = -1;
        }
        public void PradėtiPrekiųSurinkimą(ref KlientasP2 klientas)
        {
            Klientas = klientas;
            AptarnavimoLaikas = 0;
        }
        public void BaigtiPrekiųSurinkimą()
        {
            if (Klientas == null)
                throw new InvalidOperationException("Pardavėjas negali baigti prekių surinkimo, nes jis nieko neaptarnauja.");
            Klientas = null;
            AptarnavimoLaikas = -1;
        }
        public static void NunulintiSkaitliuką() => skaitiklis = 0;
    }
}