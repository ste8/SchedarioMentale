namespace SchedarioMentale.WinForms
{
    public static class MathHelper
    {
        public static double Round(double value)
        {
            return Round(value, 5);
        }

        public static double Round(double value, int decimals)
        {
            double result = Math.Round(value, decimals, MidpointRounding.AwayFromZero);
            return result;
        }

        public static decimal? Round(decimal? value, int decimals)
        {
            if (value == null) return null;
            return Round(value.Value, decimals);
        }

        public static decimal Round(decimal value, int decimals)
        {
            decimal result = Math.Round(value, decimals, MidpointRounding.AwayFromZero);
            return result;
        }
    }
}
