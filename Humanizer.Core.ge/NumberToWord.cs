using System;
using System.Collections.Generic;
using System.Text;

namespace Humanizer.Core.ge
{
    public class NumberToWord
    {
        private static readonly string[] Aseuli = { "", "", "ორ", "სამ", "ოთხ", "ხუთ", "ექვს", "შვიდ", "რვა", "ცხრა", "ათ" };
        private static readonly string[] Ateuli = { "ი", "ერთი", "ორი", "სამი", "ოთხი", "ხუთი", "ექვსი", "შვიდი", "რვა", "ცხრა", "ათი", "თერთმეტი", "თორმეტი", "ცამეტი", "თოთხმეტი", "თხუთმეტი", "თექვსმეტი", "ჩვიდმეტი", "თვრამეტი", "ცხრამეტი" };
        private static readonly string[] Oceuli = { "", "ოც", "ორმოც", "სამოც", "ოთხმოც" };


        public static string AmountToWords(decimal amount)
        {
            return AmountToWords(Convert.ToDouble(amount));
        }

        public static string AmountToWords(int amount)
        {
            return AmountToWords(Convert.ToDouble(amount));
        }

        public static string AmountToWords(double amount)
        {
            if (Math.Abs(amount - 0) < 0.001)
                return "ნული ";
            string output = "";
            var d = new decimal(amount);
            if (d < 0)
            {
                output += "მინუს ";
                d = decimal.Negate(d);
            }
            long dm = decimal.ToInt64(decimal.Truncate(d));
            decimal dc = decimal.Truncate((d - dm) * 100);
            output += LongToGeoString(dm) + string.Format(" {0}", "");
            if (dc != 0) output += " მთელი " + LongToGeoString(Convert.ToInt64(dc));
            return output.Trim();
        }

        private static string LongToGeoString(long value)
        {
            string output = string.Empty;
            output += (value == 0) ? ("ნულ") : ("");
            if (value >= 1000000) output += "მილიონი";
            else if (value >= 1000)
            {
                long atasi = value / 1000;
                if (atasi > 0) output += Under1000(atasi) + " ";
                output += "ათას";
                long nashti = value % 1000;
                if (nashti > 0) output += " " + Under1000(nashti);
                else output += "ი";
            }
            else output += Under1000(value);
            output = output.Trim();
            return output;
        }

        private static string Under1000(long dm)
        {
            long asi = dm % 1000 / 100;
            string output = (asi > 0) ? (Aseuli[asi] + "ას") : ("");

            if (dm % 100 > 0) output += " ";
            long oci = dm % 100 / 20;
            if (oci > 0) output += Oceuli[oci];

            output += ((dm % 20 > 0 && oci > 0) ? ("მთელი") : ("")) + Ateuli[dm % 20];

            return output;
        }
    }
}
