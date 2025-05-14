using System.Text;

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
                return $"|{$"        {Id} laisvas",-Protokolas.EILUTĖS_ILGIS + 2}|\n";
            var sb = new StringBuilder();
            if (!Klientas.ArSusimokėjoUžPrekes)
                sb.AppendLine($"|{$"        {Id} surašo prekes klientui {Klientas.Id}, liko {SurašytiPrekes - AptarnavimoLaikas} {Parduotuvė.GaukMinučiųŽymę(SurašytiPrekes - AptarnavimoLaikas)}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            else
                sb.AppendLine($"|{$"        {Id} atneša prekes klientui {Klientas.Id}, liko {GautiPrekes - AptarnavimoLaikas} {Parduotuvė.GaukMinučiųŽymę(GautiPrekes - AptarnavimoLaikas)}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"           Klientų, eilėje pas pardavėją, yra {PoKasininko.Count}:",-Protokolas.EILUTĖS_ILGIS + 2}|");
            if (PoKasininko.Count == 0)
            {
                sb.AppendLine($"|{$"           {{}}",-Protokolas.EILUTĖS_ILGIS + 2}|");
                return sb.ToString();
            }
            sb.AppendLine($"|{$"           {{",-Protokolas.EILUTĖS_ILGIS + 2}|");
            int i = 0;
            var sbLine = new StringBuilder();
            foreach (var klientas in PoKasininko)
            {
                ++i;
                sbLine.Append($"{klientas.Id}{(i == PoKasininko.Count ? "" : ", ")}");
                if (sbLine.Length <= Protokolas.EILUTĖS_ILGIS - 25)
                {
                    sb.AppendLine($"|{$"               {sbLine}",-Protokolas.EILUTĖS_ILGIS + 2}|");
                    sbLine.Clear();
                }
            }
            if (sbLine.Length > 0)
            {
                sb.AppendLine($"|{$"               {sbLine}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            }
            sb.AppendLine($"|{$"           }}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            return sb.ToString();
        }
        public string Tag()
        {
            if (Klientas == null)
                return $"{Id} laisvas";
            if (!Klientas.ArSusimokėjoUžPrekes)
                return $"{Id} surašo prekes klientui {Klientas.Id}, liko {SurašytiPrekes - AptarnavimoLaikas} {Parduotuvė.GaukMinučiųŽymę(SurašytiPrekes - AptarnavimoLaikas)}";
            return $"{Id} atneša prekes klientui {Klientas.Id}, liko {GautiPrekes - AptarnavimoLaikas} {Parduotuvė.GaukMinučiųŽymę(GautiPrekes - AptarnavimoLaikas)}";
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
            Klientas.LaukimoLaikas += SurašytiPrekes;
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