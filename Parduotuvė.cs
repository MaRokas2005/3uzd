using System.Text;

namespace _3uzd
{
    public class Parduotuvė
    {
        private int simuliavimoTrukmė { get; init; }
        private int tikimybėAteitiKlientui;
        private int pardavėjaiP1;
        private int pilnaiAptarnautiP1;
        private int pardavėjaiP2;
        private int kasininkaiP2;
        private int surašytiPrekesP2;
        private int sumokėtiKasininkuiP2;
        private int gautiPrekesP2;
        private int aptarnautaKlientųP1 = 0;
        private int aptarnautaKlientųP2 = 0;
        private int ilgiausiaEilėP1 = 0;
        private int ilgiausiaEilėP2 = 0;
        private List<int> kasųUžimtumasP1;
        private List<int> kasųUžimtumasP2;
        private List<int> pardavėjųUžimtumasP2;
        private List<int> minučiųPilnasAptarnavimasP1 = [];
        private List<int> minučiųPilnasAptarnavimasP2 = [];

        public Parduotuvė(int simuliavimoTrukmė,
            int tikimybėAteitiKlientui,
            int pardavėjaiP1,
            int pilnaiAptarnautiP1,
            int pardavėjaiP2,
            int kasininkaiP2,
            int surašytiPrekesP2,
            int sumokėtiKasininkuiP2,
            int gautiPrekesP2)
        {
            PardavėjasP1.NunulintiSkaitliuką();
            PardavėjasP2.NunulintiSkaitliuką();
            KlientasP1.NunulintiSkaitliuką();
            KlientasP2.NunulintiSkaitliuką();
            KasininkasP2.NunulintiSkaitliuką();
            this.simuliavimoTrukmė = simuliavimoTrukmė;
            this.tikimybėAteitiKlientui = tikimybėAteitiKlientui;
            this.pardavėjaiP1 = pardavėjaiP1;
            this.pilnaiAptarnautiP1 = pilnaiAptarnautiP1;
            this.pardavėjaiP2 = pardavėjaiP2;
            this.kasininkaiP2 = kasininkaiP2;
            this.surašytiPrekesP2 = surašytiPrekesP2;
            this.sumokėtiKasininkuiP2 = sumokėtiKasininkuiP2;
            this.gautiPrekesP2 = gautiPrekesP2;
            this.kasųUžimtumasP1 = [.. new int[pardavėjaiP1]];
            this.kasųUžimtumasP2 = [.. new int[kasininkaiP2]];
            this.pardavėjųUžimtumasP2 = [.. new int[pardavėjaiP2]];
        }

        public string PradiniaiDuomenys()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{new string('=', Protokolas.EILUTĖS_ILGIS)}");
            sb.AppendLine($"|{"PIRMA DALIS. Pradiniai duomenys",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{new string('=', Protokolas.EILUTĖS_ILGIS - 2)}|");
            sb.AppendLine($"|{"Bendri:",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"    1) Simuliacijos trukmė: {simuliavimoTrukmė + $" {GaukMinučiųŽymę(simuliavimoTrukmė)}",-66}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"    2) Tikimybė ateiti pirkėjui: {tikimybėAteitiKlientui + "%",-34}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{new string('-', Protokolas.EILUTĖS_ILGIS - 2)}|");
            sb.AppendLine($"|{"Procesas 1:",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"    1) Pardavėjų skaičius: {pardavėjaiP1,-18}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"    2) Aptarnavimo trukmė: {pilnaiAptarnautiP1 + $" {GaukMinučiųŽymę(pilnaiAptarnautiP1)}",-24}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{new string('-', Protokolas.EILUTĖS_ILGIS - 2)}|");
            sb.AppendLine($"|{"Procesas 2:",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"    1) Pardavėjų skaičius: {pardavėjaiP2,-18}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"    2) Kasininkių skaičius: {kasininkaiP2,-18}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"    3) Trukmė surašyti prekes: {surašytiPrekesP2 + $" {GaukMinučiųŽymę(surašytiPrekesP2)}",-22}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"    4) Trukmė susimokėti už prekes: {sumokėtiKasininkuiP2 + $" {GaukMinučiųŽymę(sumokėtiKasininkuiP2)}",-26}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"    5) Trukmė pasiimti prekes: {gautiPrekesP2 + $" {GaukMinučiųŽymę(gautiPrekesP2)}",-19}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"{new string('=', Protokolas.EILUTĖS_ILGIS)}\n\n\n");

            return sb.ToString();
        }
        public string VykdytiProcesą1()
        {
            var sb = new StringBuilder();
            int dabartinėMinutė = 0;
            int veiksmas;
            List<PardavėjasP1> pardavėjai = [];
            Queue<KlientasP1> klientai = new();

            sb.AppendLine($"{new string('=', Protokolas.EILUTĖS_ILGIS)}");
            sb.AppendLine($"|{"Procesas 1",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{new string('=', Protokolas.EILUTĖS_ILGIS - 2)}|");
            sb.AppendLine($"|{$"T ={" 0 minučių"}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{"Būsena_0:",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{"    1) Klientų eilė: {}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{"    2) Pardavėjai:",-Protokolas.EILUTĖS_ILGIS + 2}|");
            for (int i = 0; i < pardavėjaiP1; i++)
            {
                pardavėjai.Add(new PardavėjasP1(pilnaiAptarnautiP1));
                sb.AppendLine($"|{$"        {pardavėjai[i]}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            }

            while (++dabartinėMinutė <= simuliavimoTrukmė)
            {
                veiksmas = 0;
                sb.AppendLine($"|{new string(' ', Protokolas.EILUTĖS_ILGIS - 2)}|");
                sb.AppendLine($"|{$"T ={$" {dabartinėMinutė} {GaukMinučiųŽymę(dabartinėMinutė)}"}",-Protokolas.EILUTĖS_ILGIS + 2}|");
                //Veiksmai_{dabartinėMinutė}
                sb.AppendLine($"|{$"Veiksmai_{dabartinėMinutė}",-Protokolas.EILUTĖS_ILGIS + 2}|");
                if (new Random().Next(0, 100) < tikimybėAteitiKlientui)
                {
                    KlientasP1 klientas = new();
                    klientai.Enqueue(klientas);
                    sb.AppendLine($"|{$"    {++veiksmas}) Atėjo naujas klientas: " + klientas.Id,-Protokolas.EILUTĖS_ILGIS + 2}|");
                }
                foreach (var pardavėjas in pardavėjai)
                {
                    if (pardavėjas.Klientas != null)
                    {
                        if (pardavėjas.AptarnavimoLaikas >= pilnaiAptarnautiP1)
                        {
                            sb.AppendLine($"|{$"    {++veiksmas}) {pardavėjas.Id} baigė aptarnauti {pardavėjas.Klientas.Id}",-Protokolas.EILUTĖS_ILGIS + 2}|");
                            minučiųPilnasAptarnavimasP1.Add(pilnaiAptarnautiP1 + pardavėjas.Klientas.LaukimoLaikas);
                            aptarnautaKlientųP1++;
                            pardavėjas.BaigtiAptarnavimą();
                        }
                        pardavėjas.AptarnavimoLaikas++;
                    }
                    if (pardavėjas.Klientas == null && klientai.Count > 0)
                    {
                        KlientasP1 klientas = klientai.Dequeue();
                        pardavėjas.PradėtiAptarnavimą(klientas);
                        sb.AppendLine($"|{$"    {++veiksmas}) {pardavėjas}",-Protokolas.EILUTĖS_ILGIS + 2}|");
                        pardavėjas.AptarnavimoLaikas++;
                    }
                    if (pardavėjas.Klientas != null)
                    {
                        kasųUžimtumasP1[pardavėjas.Id[^1] - '1']++;
                    }
                }
                ilgiausiaEilėP1 = Math.Max(ilgiausiaEilėP1, klientai.Count);
                Laukti(klientai);
                //Būsena_{dabartinėMinutė}
                sb.AppendLine($"|{$"Būsena_{dabartinėMinutė}",-Protokolas.EILUTĖS_ILGIS + 2}|");
                sb.Append(GrąžintiKlientus(klientai, 1));
                sb.Append(GrąžintiPardavėjus(pardavėjai, 2));
            }
            sb.AppendLine($"{new string('=', Protokolas.EILUTĖS_ILGIS)}\n\n\n");
            return sb.ToString();
        }
        public string VykdytiProcesą2()
        {
            var sb = new StringBuilder();
            int dabartinėMinutė = 0;
            int veiksmas;
            int eilėjeKlientų;
            List<PardavėjasP2> pardavėjai = [];
            List<KasininkasP2> kasininkai = [];
            Queue<KlientasP2> klientųEilėPasPardavėjus = new();
            Queue<KlientasP2> klientųEilėPasKasininkus = new();
            sb.AppendLine($"{new string('=', Protokolas.EILUTĖS_ILGIS)}");
            sb.AppendLine($"|{"Procesas 2",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{new string('=', Protokolas.EILUTĖS_ILGIS - 2)}|");
            sb.AppendLine($"|{$"T ={" 0 minučių"}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{"Būsena_0:",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{"    1) Klientų eilė pas pardavėjus: {}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{"    2) Klientų eilė pas kasininkus: {}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{"    3) Pardavėjai:",-Protokolas.EILUTĖS_ILGIS + 2}|");
            for (int i = 0; i < pardavėjaiP2; i++)
            {
                pardavėjai.Add(new PardavėjasP2(surašytiPrekesP2, gautiPrekesP2));
                sb.AppendLine($"|{$"        {pardavėjai[i]}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            }
            sb.AppendLine($"|{"    4) Kasininkai:",-Protokolas.EILUTĖS_ILGIS + 2}|");
            for (int i = 0; i < kasininkaiP2; i++)
            {
                kasininkai.Add(new KasininkasP2(sumokėtiKasininkuiP2));
                sb.AppendLine($"|{$"        {kasininkai[i]}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            }

            while (++dabartinėMinutė <= simuliavimoTrukmė)
            {
                eilėjeKlientų = 0;
                veiksmas = 0;
                sb.AppendLine($"|{new string(' ', Protokolas.EILUTĖS_ILGIS - 2)}|");
                sb.AppendLine($"|{$"T ={$" {dabartinėMinutė} {GaukMinučiųŽymę(dabartinėMinutė)}"}",-Protokolas.EILUTĖS_ILGIS + 2}|");
                //Veiksmai_{dabartinėMinutė}
                sb.AppendLine($"|{$"Veiksmai_{dabartinėMinutė}",-Protokolas.EILUTĖS_ILGIS + 2}|");
                if (new Random().Next(0, 100) < tikimybėAteitiKlientui)
                {
                    KlientasP2 klientas = new();
                    klientųEilėPasPardavėjus.Enqueue(klientas);
                    sb.AppendLine($"|{$"    {++veiksmas}) Atėjo naujas klientas: " + klientas.Id,-Protokolas.EILUTĖS_ILGIS + 2}|");
                }

                foreach (var kasininkas in kasininkai)
                {
                    if (kasininkas.Klientas != null)
                    {
                        if (kasininkas.AptarnavimoLaikas >= sumokėtiKasininkuiP2)
                        {
                            sb.AppendLine($"|{$"    {++veiksmas}) {kasininkas.Id} baigė aptarnauti {kasininkas.Klientas.Id}",-Protokolas.EILUTĖS_ILGIS + 2}|");
                            kasininkas.BaigtiAptarnavimą();
                        }
                        kasininkas.AptarnavimoLaikas++;
                    }
                }
                foreach (var pardavėjas in pardavėjai)
                {
                    int arUžimtas = 0;
                    eilėjeKlientų += pardavėjas.PoKasininko.Count;
                    Laukti(pardavėjas.PoKasininko);
                    if (pardavėjas.Klientas != null)
                    {
                        if (!pardavėjas.Klientas.ArSusimokėjoUžPrekes)
                        {
                            if (pardavėjas.AptarnavimoLaikas >= pardavėjas.SurašytiPrekes)
                            {
                                sb.AppendLine($"|{$"    {++veiksmas}) {pardavėjas.Id} baigė prekių surašymą klientui {pardavėjas.Klientas.Id}",-Protokolas.EILUTĖS_ILGIS + 2}|");
                                pardavėjas.BaigtiPrekiųSurašymą(ref klientųEilėPasKasininkus);
                            }
                        }
                        else
                        {
                            if (pardavėjas.AptarnavimoLaikas >= pardavėjas.GautiPrekes)
                            {
                                sb.AppendLine($"|{$"    {++veiksmas}) {pardavėjas.Id} baigė prekių surinkimą klientui {pardavėjas.Klientas.Id}",-Protokolas.EILUTĖS_ILGIS + 2}|");
                                minučiųPilnasAptarnavimasP2.Add(pardavėjas.Klientas.LaukimoLaikas + pardavėjas.GautiPrekes);
                                pardavėjas.BaigtiPrekiųSurinkimą();
                                aptarnautaKlientųP2++;
                            }
                        }
                        arUžimtas = 1;
                    }
                    if (pardavėjas.Klientas == null && pardavėjas.PoKasininko.Count > 0)
                    {
                        KlientasP2 klientas = pardavėjas.PoKasininko.Dequeue();
                        pardavėjas.PradėtiPrekiųSurinkimą(ref klientas);
                        sb.AppendLine($"|{$"    {++veiksmas}) {pardavėjas}",-Protokolas.EILUTĖS_ILGIS + 2}|");
                        arUžimtas = 1;
                    }
                    if (pardavėjas.Klientas == null && klientųEilėPasPardavėjus.Count > 0)
                    {
                        KlientasP2 klientas = klientųEilėPasPardavėjus.Dequeue();
                        pardavėjas.PradėtiPrekiųSurašymą(ref klientas);
                        sb.AppendLine($"|{$"    {++veiksmas}) {pardavėjas}",-Protokolas.EILUTĖS_ILGIS + 2}|");
                        arUžimtas = 1;
                    }
                    pardavėjas.AptarnavimoLaikas += arUžimtas;
                    pardavėjųUžimtumasP2[pardavėjas.Id[^1] - '1'] += arUžimtas;
                }
                foreach (var kasininkas in kasininkai)
                {
                    if (kasininkas.Klientas == null && klientųEilėPasKasininkus.Count > 0)
                    {
                        KlientasP2 klientas = klientųEilėPasKasininkus.Dequeue();
                        kasininkas.PradėtiAptarnavimą(klientas);
                        sb.AppendLine($"|{$"    {++veiksmas}) {kasininkas}",-Protokolas.EILUTĖS_ILGIS + 2}|");
                        kasininkas.AptarnavimoLaikas++;
                    }
                    if (kasininkas.Klientas != null)
                    {
                        kasųUžimtumasP2[kasininkas.Id[^1] - '1']++;
                    }
                }
                eilėjeKlientų += klientųEilėPasPardavėjus.Count + klientųEilėPasKasininkus.Count;
                ilgiausiaEilėP2 = Math.Max(ilgiausiaEilėP2, eilėjeKlientų);
                Laukti(klientųEilėPasPardavėjus);
                Laukti(klientųEilėPasKasininkus);
                //Būsena_{dabartinėMinutė}
                sb.AppendLine($"|{$"Būsena_{dabartinėMinutė}",-Protokolas.EILUTĖS_ILGIS + 2}|");
                sb.Append(GrąžintiKlientus(klientųEilėPasPardavėjus, 1, "Klientų eilė pas pardavėjus"));
                sb.Append(GrąžintiKlientus(klientųEilėPasKasininkus, 2, "Klientų eilė pas kasininkus"));
                sb.Append(GrąžintiPardavėjus(pardavėjai, 3));
                sb.Append(GrąžintiKasininkus(kasininkai, 4));
            }

            sb.AppendLine($"{new string('=', Protokolas.EILUTĖS_ILGIS)}\n\n\n");
            return sb.ToString();
        }
        public string AtspausdintiAnalizę()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{new string('=', Protokolas.EILUTĖS_ILGIS)}");
            sb.AppendLine($"|{"ANALIZĖ",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{new string('=', Protokolas.EILUTĖS_ILGIS - 2)}|");
            sb.AppendLine($"|{$"Procesas1:",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"Daugiausia kiek buvo žmonių eilėje yra {ilgiausiaEilėP1}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"{(aptarnautaKlientųP1 == 1 ? "Aptarnautas" : "Aptarnauti")} {aptarnautaKlientųP1} {GaukKlientoŽymę(aptarnautaKlientųP1)}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"Minimalus aptarnavimo laikas: {(minučiųPilnasAptarnavimasP1.Count != 0 ? minučiųPilnasAptarnavimasP1.Min() : "niekas neaptarnautas iki galo")} {(minučiųPilnasAptarnavimasP1.Count != 0 ? GaukMinučiųŽymę(minučiųPilnasAptarnavimasP1.Min()) : "")}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"Vidutinis aptarnavimo laikas: {(minučiųPilnasAptarnavimasP1.Count != 0 ? $"{minučiųPilnasAptarnavimasP1.Average():f2}" : "niekas neaptarnautas iki galo")} {(minučiųPilnasAptarnavimasP1.Count != 0 ? "minučių" : "")}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"Ilgiausias aptarnavimo laikas: {(minučiųPilnasAptarnavimasP1.Count != 0 ? minučiųPilnasAptarnavimasP1.Max() : "niekas neaptarnautas iki galo")} {(minučiųPilnasAptarnavimasP1.Count != 0 ? GaukMinučiųŽymę(minučiųPilnasAptarnavimasP1.Max()) : "")}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"Būtų užtekę {kasųUžimtumasP1.Count(n => n > 0)} {(kasųUžimtumasP1.Count(n => n > 0) == 1 ? "pardavėjos" : "pardavėjų")}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"Pardavėjų vidutinis užimtumas:",-Protokolas.EILUTĖS_ILGIS + 2}|");
            for (int i = 0; i < kasųUžimtumasP1.Count; i++)
            {
                sb.AppendLine($"|{$"    Pardavėjas_{i + 1}: {kasųUžimtumasP1[i] / (double)simuliavimoTrukmė * 100:f2}%",-Protokolas.EILUTĖS_ILGIS + 2}|");
            }
            sb.AppendLine($"|{new string('-', Protokolas.EILUTĖS_ILGIS-2)}|");
            sb.AppendLine($"|{$"Procesas2:",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"Daugiausia kiek buvo žmonių eilėje yra {ilgiausiaEilėP2}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"{(aptarnautaKlientųP1 == 1 ? "Aptarnautas" : "Aptarnauti")} {aptarnautaKlientųP2} {GaukKlientoŽymę(aptarnautaKlientųP2)}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"Minimalus aptarnavimo laikas: {(minučiųPilnasAptarnavimasP2.Count != 0 ? minučiųPilnasAptarnavimasP2.Min() : "niekas neaptarnautas iki galo")} {(minučiųPilnasAptarnavimasP2.Count != 0 ? GaukMinučiųŽymę(minučiųPilnasAptarnavimasP2.Min()) : "")}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"Vidutinis aptarnavimo laikas: {(minučiųPilnasAptarnavimasP2.Count != 0 ? $"{minučiųPilnasAptarnavimasP2.Average():f2}" : "niekas neaptarnautas iki galo")} {(minučiųPilnasAptarnavimasP2.Count != 0 ? "minučių" : "")}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"Ilgiausias aptarnavimo laikas: {(minučiųPilnasAptarnavimasP2.Count != 0 ? minučiųPilnasAptarnavimasP2.Max() : "niekas neaptarnautas iki galo")} {(minučiųPilnasAptarnavimasP2.Count != 0 ? GaukMinučiųŽymę(minučiųPilnasAptarnavimasP2.Max()) : "")}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"Būtų užtekę {pardavėjųUžimtumasP2.Count(n => n > 0)} {(pardavėjųUžimtumasP2.Count(n => n > 0) == 1 ? "pardavėjos" : "pardavėjų")} ir {kasųUžimtumasP2.Count(n => n > 0)} {(kasųUžimtumasP2.Count(n => n > 0) == 1 ? "kasos" : "kasų")}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"Pardavėjų vidutinis užimtumas:",-Protokolas.EILUTĖS_ILGIS + 2}|");
            for (int i = 0; i < pardavėjųUžimtumasP2.Count; i++)
            {
                sb.AppendLine($"|{$"    Pardavėjas_{i + 1}: {pardavėjųUžimtumasP2[i] / (double)simuliavimoTrukmė * 100:f2}%",-Protokolas.EILUTĖS_ILGIS + 2}|");
            }
            sb.AppendLine($"|{$"Kasininkų vidutinis užimtumas:",-Protokolas.EILUTĖS_ILGIS + 2}|");
            for (int i = 0; i < kasųUžimtumasP2.Count; i++)
            {
                sb.AppendLine($"|{$"    Kasininkas_{i + 1}: {kasųUžimtumasP2[i] / (double)simuliavimoTrukmė * 100:f2}%",-Protokolas.EILUTĖS_ILGIS + 2}|");
            }
            sb.AppendLine($"|{new string('-', Protokolas.EILUTĖS_ILGIS - 2)}|");
            sb.AppendLine($"|{$"Apibendrinimas:",-Protokolas.EILUTĖS_ILGIS + 2}|");
            if (aptarnautaKlientųP1 == aptarnautaKlientųP2)
            {
                sb.AppendLine($"|{$"    Aptarnauta vienodai klientų abiejuose procesuose.",-Protokolas.EILUTĖS_ILGIS + 2}|");
            } else
            {
                sb.AppendLine($"|{$"    Daugiau klientų aptarnauta {(aptarnautaKlientųP1 > aptarnautaKlientųP2 ? "pirmame" : "antrame")} procese.",-Protokolas.EILUTĖS_ILGIS + 2}|");
            }
            if (kasųUžimtumasP1.Count(n => n > 0) == pardavėjųUžimtumasP2.Count(n => n > 0) + kasųUžimtumasP2.Count(n => n > 0))
            {
                sb.AppendLine($"|{$"    Abiejuose procesuose vienodai reikėjo kasų aparatų.",-Protokolas.EILUTĖS_ILGIS + 2}|");
            }
            else
            {
                sb.AppendLine($"|{$"    Mažiau kasos aparatų reikėjo {(kasųUžimtumasP1.Count(n => n > 0) < pardavėjųUžimtumasP2.Count(n => n > 0) + kasųUžimtumasP2.Count(n => n > 0) ? "pirmame" : "antrame")} procese.",-Protokolas.EILUTĖS_ILGIS + 2}|");
            }

            sb.AppendLine($"|{$"",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.Append($"{new string('=', Protokolas.EILUTĖS_ILGIS)}");

            return sb.ToString();
        }
        public static string GaukMinučiųŽymę(int minutes) => minutes switch
        {
            _ when minutes % 10 == 1 && minutes % 100 != 11 => "minutė",
            _ when minutes % 10 >= 2 && minutes % 10 <= 9 && (minutes % 100 < 11 || minutes % 100 > 19) => "minutės",
            _ => "minučių"
        };
        public static string GaukKlientoŽymę(int klientų) => klientų switch
        {
            _ when klientų == 1 => "klientas",
            _ when klientų % 10 >= 2 && klientų % 10 <= 9 && (klientų % 100 < 11 || klientų % 100 > 19) => "klientai",
            _ => "klientų"
        };
        public static void Laukti<T>(Queue<T> klientai) where T : IKlientas
        {
            foreach (var klientas in klientai)
            {
                klientas.LaukimoLaikas++;
            }
        }
        public static string GrąžintiKlientus<T>(Queue<T> klientai, int numer, string pavadinimas = "Klientų eilė") where T : IKlientas
        {
            var sb = new StringBuilder();
            sb.AppendLine($"|{$"    {numer}) {pavadinimas}: {(klientai.Count == 0 ? "{}" : "")}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            foreach (var klientas in klientai) sb.AppendLine($"|{$"        {klientas}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            return sb.ToString();

        }
        public static string GrąžintiPardavėjus<T>(List<T> pardavėjai, int numer) where T : IPardavėjas
        {
            var sb = new StringBuilder();
            sb.AppendLine($"|{$"    {numer}) Pardavėjai:",-Protokolas.EILUTĖS_ILGIS + 2}|");
            foreach (var pardavėjas in pardavėjai) sb.AppendLine($"|{$"        {pardavėjas}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            return sb.ToString();
        }
        public static string GrąžintiKasininkus(List<KasininkasP2> kasininkai, int numer)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"|{$"    {numer}) Kasininkai:",-Protokolas.EILUTĖS_ILGIS + 2}|");
            foreach (var kasininkas in kasininkai) sb.AppendLine($"|{$"        {kasininkas}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            return sb.ToString();
        }
    }
}