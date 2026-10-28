namespace Wospp.QOLStuff
{
    public static class WosppsQOLStuff
    {
        public static bool Within(this double value, double min, double max)
        {
            if (value >= min && value <= max)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
    }
}
