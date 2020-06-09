using System;

namespace Humanizer.Core.ge
{
    public static class NumberToWords
    {
        private static readonly string[] Aseuli = { "", "", "ორ", "სამ", "ოთხ", "ხუთ", "ექვს", "შვიდ", "რვა", "ცხრა", "ათ" };
        private static readonly string[] Ateuli = { "ი", "ერთი", "ორი", "სამი", "ოთხი", "ხუთი", "ექვსი", "შვიდი", "რვა", "ცხრა", "ათი", "თერთმეტი", "თორმეტი", "ცამეტი", "თოთხმეტი", "თხუთმეტი", "თექვსმეტი", "ჩვიდმეტი", "თვრამეტი", "ცხრამეტი" };
        private static readonly string[] Oceuli = { "", "ოც", "ორმოც", "სამოც", "ოთხმოც" };


        public static string ToWords(this int number)
        {
            string output = default;

            if (number < 0)
            {
                output += "მინუს ";
                number *= -1;
            }

            output += IntToGeoString(number);

            return output.Trim();
        }

        public static string ToWords(this double number)
        {
            string output = default;

            string[] splited = number.ToString().Split('.');

            output += Convert.ToInt32(splited[0]).ToWords();


            if (splited.Length == 2 && Convert.ToInt32(splited[1]) > 0)
            {
                output += " მთელი ";
                output += Convert.ToInt32(splited[1]).ToWords();

                output +=
                splited[1].Length switch
                {
                    int len when len > 8 => " მემილიარდედი",
                    int len when len > 7 => " მეასიმილიონედი",
                    int len when len > 6 => " მეათიმილიონედი",
                    int len when len > 5 => " მემილიონედი",
                    int len when len > 4 => " მეასიათასედი",
                    int len when len > 3 => " მეათიათასედი",
                    int len when len > 2 => " მეათასედი",
                    int len when len > 1 => " მეასედი",
                    int len when len > 0 => " მეათედი",
                    _ => default
                };
            }

            return output.Trim();
        }


        private static string IntToGeoString(int value)
        {
            if (value == 0) return "ნული";

            string output = default;

            if (value >= 1_000_000_000)
            {
                output += "მილიარდი";
                // todo: გასაკეთებელია
            }
            else if (value >= 1_000_000)
            {
                output += "მილიონი";
                // todo: გასაკეთებელია
            }
            else if (value >= 1_000)
            {
                int atasi = value / 1000;
                if (atasi > 0) output += Under1000(atasi) + " ";
                output += "ათას";

                int nashti = value % 1000;
                if (nashti > 0) output += " " + Under1000(nashti);
                else output += "ი";
            }
            else output += Under1000(value);

            return output.Trim();
        }

        private static string Under1000(int value)
        {
            int asi = value % 1000 / 100;
            string output = (asi > 0) ? (Aseuli[asi] + "ას") : ("");

            if (value % 100 > 0) output += " ";
            int oci = value % 100 / 20;
            if (oci > 0) output += Oceuli[oci];

            output += ((value % 20 > 0 && oci > 0) ? ("და") : ("")) + Ateuli[value % 20];

            return output;
        }
    }
}
