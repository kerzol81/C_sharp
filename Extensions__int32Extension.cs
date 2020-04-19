namespace MoneyExtension
{
    public enum Currencies
    {
        HUF,
        USD,
        EUR
    }
    static class Int32Extension
    {
        public static string WithCurrency(this int originalObj, Currencies currency)
        {
            switch (currency)
            {
                case Currencies.USD:
                    return originalObj + " $";
                case Currencies.EUR:
                    return originalObj + " Eur";
                default:
                    return (originalObj + " Ft");
            }
        }
    }
}
