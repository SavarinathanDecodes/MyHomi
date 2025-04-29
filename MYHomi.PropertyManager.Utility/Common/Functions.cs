namespace MyHomi.PropertyManager.Utility.Common
{
    public static class Funtions
    {

        public static string StringToUpper(string value)
        {
            return value.ToUpper();
        }

        public static string StringToLower(string value)
        {
            return value.ToLower();
        }

        public static DateTime LocalDataTime()
        {
            return DateTime.Now;
        }

        public static DateTime UTCDataTime()
        {
            return DateTime.UtcNow;
        }

    }
}
