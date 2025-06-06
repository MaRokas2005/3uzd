﻿namespace _3uzd
{
    public class PardavėjasP1(int aptarnavimoTrukmė) : IPardavėjas
    {
        private static int skaitiklis = 0;
        public string Id { get; init; } = $"Pardavėjas P{++skaitiklis}";
        public KlientasP1? Klientas { get; private set; } = null;
        public int AptarnavimoLaikas { get; set; }
        public override string ToString() => $"|{$"        {Tag()}",-Protokolas.EILUTĖS_ILGIS + 2}|\n";
        public string Tag() => $"{Id} {(Klientas == null ? "laisvas" : $"aptarnauja klientą {Klientas.Id}, liko {aptarnavimoTrukmė - AptarnavimoLaikas} {Parduotuvė.GaukMinučiųŽymę(aptarnavimoTrukmė - AptarnavimoLaikas)} iš {aptarnavimoTrukmė} {(aptarnavimoTrukmė == 1 ? "minutės" : "minučių")}")}";
        public void PradėtiAptarnavimą(KlientasP1 klientas)
        {
            Klientas = klientas;
            AptarnavimoLaikas = 0;
        }
        public void BaigtiAptarnavimą()
        {
            Klientas = null;
            AptarnavimoLaikas = -1;
        }
        public static void NunulintiSkaitliuką() => skaitiklis = 0;
    }
}