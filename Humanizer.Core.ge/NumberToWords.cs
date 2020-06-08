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
            string output = string.Empty;

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
            string output = string.Empty;
            string[] bumbers = number.ToString().Split('.');

            output += Convert.ToInt32(bumbers[0]).ToWords();

            if (Convert.ToInt32(bumbers[1]) > 0)
            {
                output += " მთელი ";
                output += Convert.ToInt32(bumbers[1]).ToWords();
            }

            return output.Trim();
        }


        private static string IntToGeoString(int value)
        {
            string output = (value == 0) ? ("ნულ") : ("");

            if (value >= 1000000)
            {
                output += "მილიონი";
                // todo: გასაკეთებელია
            }
            else if (value >= 1000)
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

        private static string Under1000(int dm)
        {
            int asi = dm % 1000 / 100;
            string output = (asi > 0) ? (Aseuli[asi] + "ას") : ("");

            if (dm % 100 > 0) output += " ";
            int oci = dm % 100 / 20;
            if (oci > 0) output += Oceuli[oci];

            output += ((dm % 20 > 0 && oci > 0) ? ("და") : ("")) + Ateuli[dm % 20];

            return output;
        }
    }
}
