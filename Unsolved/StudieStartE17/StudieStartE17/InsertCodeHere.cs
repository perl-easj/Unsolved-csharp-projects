using System;

namespace StudieStartE17
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // Skattesatser
            int skatLimit = 50000;
            int skatProcentUnderLimit = 80;
            int skatProcentOverLimit = 150;
            int skatRabatPrKmOverBenzinLimit = 4000;
            int benzinLimit = 16;

            // Det kan i opgaveløsningen antages, at
            // 1) Alle biler har en nettopris, som er højere end skatLimit
            // 2) Alle biler kører mindst 16 km på literen

            // Skal afprøves med disse cases:
            // A) nettoPris = 60000, 19.5 km/liter  -> Total pris 101.000 kr.
            // A) nettoPris = 110000, 25.0 km/liter -> Total pris 204.000 kr. 
            // A) nettoPris = 170000, 17.5 km/liter -> Total pris 384.000 kr.

            // Oplysninger om bilen
            int nettoPris = 60000;
            double kmPrLiter = 19.5;
            double totalPris = 0;

            // Her skal du indsætte kode, som beregner den korrekte værdi af totalPris

            Console.WriteLine($"Total pris for bilen : {totalPris} kr.");

            // The LAST line of code should be ABOVE this line
        }
    }
}