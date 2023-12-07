namespace Adapter
{
    internal static class RandomDataHelper
    {
        private static readonly Random RNG = new Random();

        internal static string GetRandomString(params string[] options)
        {
            return options[RNG.Next(0, options.Length)];
        }
        internal static float GetRandomFloat()
        {
            double mantissa = (RNG.NextDouble() * 2.0) - 1.0;
            double exponent = Math.Pow(2.0, RNG.Next(-126, 128));
            return (float)(mantissa * exponent);
        }
    }
}
