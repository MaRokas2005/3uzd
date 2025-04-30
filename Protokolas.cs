using System.Text;

namespace _3uzd
{
    public class Protokolas : IDisposable
    {
        public const int EILUTĖS_ILGIS = 100;
        StreamWriter writer;
        static string pradžia =
            $"{new string('=', EILUTĖS_ILGIS)                                                                              }\n" +
            $"|{"3 užduotis, 7 variantas. R. Braidokas, Programų sistemų 1 kursas, 2 grupė, 1 pogrupis",-EILUTĖS_ILGIS + 2 }|\n" +
            $"|{new string('-', EILUTĖS_ILGIS - 2)                                                                         }|\n" +
            $"|{"Sąlyga:",-EILUTĖS_ILGIS + 2                                                                               }|\n" +
            $"|{"    Simuliuoti nesavitarnos parduotuvės veiklą.",-EILUTĖS_ILGIS + 2                                       }|\n" +
            $"|{"    Patyrinėti abu procesus, tiek klientų pasitenkinimo požiūriu (laukimo laiku),",-EILUTĖS_ILGIS + 2     }|\n" +
            $"|{"    tiek ekonominiu požiūriu (kasų užimtumu).",-EILUTĖS_ILGIS + 2                                         }|\n" +
            $"|{new string('-', EILUTĖS_ILGIS - 2)                                                                         }|\n" +
            $"|{"Procesas1:",-EILUTĖS_ILGIS + 2                                                                            }|\n" +
            $"|{"    Pardavėjas pilnai aptarnauja klientą: paduoda prekes, išmuša čekį, paima pinigus.",-EILUTĖS_ILGIS + 2 }|\n" +
            $"|{new string('-', EILUTĖS_ILGIS - 2)                                                                         }|\n" +
            $"|{"Procesas2:",-EILUTĖS_ILGIS + 2                                                                            }|\n" +
            $"|{"    Pardavėjas surašo pirkėjo pageidaujamas prekes popieriaus lapelio, su šiuo lapeliu",-EILUTĖS_ILGIS + 2}|\n" +
            $"|{"    klientas eina sumokėti prie kasininko, kuris išmuša čekį ir paima pinigus,",-EILUTĖS_ILGIS + 2        }|\n" +
            $"|{"    su šiuo čekiu pirkėjas grįžta prie jį aptarnavusio pardavėjo ir, šiam baigus",-EILUTĖS_ILGIS + 2      }|\n" +
            $"|{"    aptarnauti eilinį pirkėją, be eilės gauna savo prekes.",-EILUTĖS_ILGIS + 2                            }|\n" +
            $"{new string('=', EILUTĖS_ILGIS)                                                                              }\n\n\n";
        public Protokolas(int numeris)
        {
            string name = $"./../../../Protokolai/3uzd-07var-protokolas{numeris}-Braidokas.txt";
            if (File.Exists(name))
                File.Delete(name);
            writer = new StreamWriter(name, true, Encoding.UTF8, 4096);
            writer.WriteLine(pradžia);
        }

        public void Įrašyti(string content)
        {
            writer.Write(content);
        }
        public void Dispose()
        {
            writer?.Flush();
            writer?.Dispose();
        }
    }
}