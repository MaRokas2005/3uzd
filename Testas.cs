namespace _3uzd
{
    class Testas
    {
        private static int testųSkaičius = 0;
        Parduotuvė parduotuvė;
        Protokolas protokolas;
        public Testas()
        {
            int simuliavimoTrukmė, tikimybėAteitiKlientui;
            int pardavėjosP1, pardavėjosP2, kasininkėsP2;
            int pilnaiAptarnautiP1, surašytiPrekesP2, sumokėtiKasininkeiP2, gautiPrekesP2;
            Console.WriteLine("Testas Nr. {0}", ++testųSkaičius);
            do
            {
                Console.Write("Įveskite simuliavimo trukmę, minutėmis (> 0): ");
            } while (!int.TryParse(Console.ReadLine(), out simuliavimoTrukmė) || !(simuliavimoTrukmė > 0));
            Console.WriteLine(simuliavimoTrukmė);
            do
            {
                Console.Write("Įveskitę tikimybę ateiti klientui (0-100%): ");
            } while (!int.TryParse(Console.ReadLine(), out tikimybėAteitiKlientui) || !(tikimybėAteitiKlientui >= 0 && tikimybėAteitiKlientui <= 100));
            Console.WriteLine("Procesas1:"); 
            do
            {
                Console.Write("Pardavėjų skaičius (> 0): ");
            } while (!int.TryParse(Console.ReadLine(), out pardavėjosP1) || !(pardavėjosP1 > 0));
            do
            {
                Console.Write("Trukmė pilnai aptarnauti pirkėją, minutėmis (> 0): ");
            } while (!int.TryParse(Console.ReadLine(), out pilnaiAptarnautiP1) || !(pilnaiAptarnautiP1 > 0));
            Console.WriteLine("Procesas2:");
            do
            {
                Console.Write("Pardavėjų skaičius (> 0): ");
            } while (!int.TryParse(Console.ReadLine(), out pardavėjosP2) || !(pardavėjosP2 > 0));
            do
            {
                Console.Write("Kasininkių skaičius (> 0): ");
            } while (!int.TryParse(Console.ReadLine(), out kasininkėsP2) || !(kasininkėsP2 > 0));
            do
            {
                Console.Write("Trukmė surašyti prekes pas pardavėją, minutėmis (> 0): ");
            } while (!int.TryParse(Console.ReadLine(), out surašytiPrekesP2) || !(surašytiPrekesP2 > 0));
            do
            {
                Console.Write("Trukmė sumokėti už prekes, minutėmis (> 0): ");
            } while (!int.TryParse(Console.ReadLine(), out sumokėtiKasininkeiP2) || !(sumokėtiKasininkeiP2 > 0));
            do
            {
                Console.Write("Trukmė gauti prekes iš pardavėjos, minutėmis (> 0): ");
            } while (!int.TryParse(Console.ReadLine(), out gautiPrekesP2) || !(gautiPrekesP2 > 0));

            parduotuvė = new Parduotuvė(
                simuliavimoTrukmė, tikimybėAteitiKlientui,
                pardavėjosP1, pilnaiAptarnautiP1,
                pardavėjosP2, kasininkėsP2, surašytiPrekesP2, sumokėtiKasininkeiP2, gautiPrekesP2);
            protokolas = new Protokolas(testųSkaičius);
        }
        public void PaleistiTestą()
        {
            DateTime start = DateTime.Now;
            try
            {
                protokolas.Įrašyti(parduotuvė.PradiniaiDuomenys());
                protokolas.Įrašyti("ANTRA DALIS. Vykdymas\n");
                protokolas.Įrašyti(parduotuvė.VykdytiProcesą1());
                protokolas.Įrašyti(parduotuvė.VykdytiProcesą2());
                protokolas.Įrašyti(parduotuvė.AtspausdintiAnalizę());
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            protokolas.Dispose();
            DateTime end = DateTime.Now;
            Console.WriteLine($"Testas užtruko {(end - start).Milliseconds} milisekundžių.");
        }
    }
}