using System.Text;

namespace _3uzd
{
    public class Parduotuvė
    {
        private int simuliavimoTrukmė;
        private int tikimybėAteitiKlientui;
        private int pardavėjosP1;
        private int pilnaiAptarnautiP1;
        private int pardavėjosP2;
        private int kasininkėsP2;
        private int surašytiPrekesP2;
        private int sumokėtiKasininkeiP2;
        private int gautiPrekesP2;

        public Parduotuvė(int simuliavimoTrukmė, int tikimybėAteitiKlientui, int pardavėjosP1, int pilnaiAptarnautiP1, int pardavėjosP2, int kasininkėsP2, int surašytiPrekesP2, int sumokėtiKasininkeiP2, int gautiPrekesP2)
        {
            this.simuliavimoTrukmė = simuliavimoTrukmė;
            this.tikimybėAteitiKlientui = tikimybėAteitiKlientui;
            this.pardavėjosP1 = pardavėjosP1;
            this.pilnaiAptarnautiP1 = pilnaiAptarnautiP1;
            this.pardavėjosP2 = pardavėjosP2;
            this.kasininkėsP2 = kasininkėsP2;
            this.surašytiPrekesP2 = surašytiPrekesP2;
            this.sumokėtiKasininkeiP2 = sumokėtiKasininkeiP2;
            this.gautiPrekesP2 = gautiPrekesP2;
        }

        public string PirmaDalis()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{new string('=', Protokolas.EILUTĖS_ILGIS)}"                                                                                                      );
            sb.AppendLine($"|{"PIRMA DALIS. Pradiniai duomenys",-Protokolas.EILUTĖS_ILGIS + 2}|"                                                                              );
            sb.AppendLine($"|{new string('=', Protokolas.EILUTĖS_ILGIS - 2)}|"                                                                                                );
            sb.AppendLine($"|{"Bendri:",-Protokolas.EILUTĖS_ILGIS + 2}|"                                                                                                      );
            sb.AppendLine($"|{$"    1) Simuliacijos trukmė: {simuliavimoTrukmė + $" {GaukMinučiųŽymę(simuliavimoTrukmė)}",-66}",-Protokolas.EILUTĖS_ILGIS + 2}|"              );
            sb.AppendLine($"|{$"    2) Tikimybė ateiti pirkėjui: {tikimybėAteitiKlientui + "%",-34}",-Protokolas.EILUTĖS_ILGIS + 2}|"                                         );
            sb.AppendLine($"|{new string('-', Protokolas.EILUTĖS_ILGIS - 2)}|"                                                                                                );
            sb.AppendLine($"|{"Procesas 1:",-Protokolas.EILUTĖS_ILGIS + 2}|"                                                                                                  );
            sb.AppendLine($"|{$"    1) Pardavėjų skaičius: {pardavėjosP1,-18}",-Protokolas.EILUTĖS_ILGIS + 2}|"                                                               );
            sb.AppendLine($"|{$"    2) Aptarnavimo trukmė: {pilnaiAptarnautiP1 + $" {GaukMinučiųŽymę(pilnaiAptarnautiP1)}",-24}",-Protokolas.EILUTĖS_ILGIS + 2}|"             );
            sb.AppendLine($"|{new string('-', Protokolas.EILUTĖS_ILGIS - 2)}|"                                                                                                );
            sb.AppendLine($"|{"Procesas 2:",-Protokolas.EILUTĖS_ILGIS + 2}|"                                                                                                  );
            sb.AppendLine($"|{$"    1) Pardavėjų skaičius: {pardavėjosP2,-18}",-Protokolas.EILUTĖS_ILGIS + 2}|"                                                               );
            sb.AppendLine($"|{$"    2) Kasininkių skaičius: {kasininkėsP2,-18}",-Protokolas.EILUTĖS_ILGIS + 2}|"                                                              );
            sb.AppendLine($"|{$"    3) Trukmė surašyti prekes: {surašytiPrekesP2 + $" {GaukMinučiųŽymę(surašytiPrekesP2)}",-22}",-Protokolas.EILUTĖS_ILGIS + 2}|"             );
            sb.AppendLine($"|{$"    4) Trukmė susimokėti už prekes: {sumokėtiKasininkeiP2 + $" {GaukMinučiųŽymę(sumokėtiKasininkeiP2)}",-26}",-Protokolas.EILUTĖS_ILGIS + 2}|");
            sb.AppendLine($"|{$"    5) Trukmė pasiimti prekes: {gautiPrekesP2 + $" {GaukMinučiųŽymę(gautiPrekesP2)}",-19}",-Protokolas.EILUTĖS_ILGIS + 2}|"                   );
            sb.AppendLine($"{new string('=', Protokolas.EILUTĖS_ILGIS)}\n\n\n"                                                                                                );

            return sb.ToString();
        }
        public string PaleistiTestąProcesas1()
        {
            throw new NotImplementedException();
        }
        public string PaleistiTestąProcesas2()
        {
            throw new NotImplementedException();
        }
        public string AtspausdintiAnalizę()
        {
            throw new NotImplementedException();
        }
        private static string GaukMinučiųŽymę(int minutes) => minutes switch
        {
            _ when minutes % 10 == 1 && minutes % 100 != 11 => "minutė",
            _ when minutes % 10 >= 2 && minutes % 10 <= 9 && (minutes % 100 < 11 || minutes % 100 > 19) => "minutės",
            _ => "minučių"
        };

    }
}