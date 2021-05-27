namespace RaindropsLib
{
    public static class Raindrop
    {
        public static string Input(int number)
        {
            string output = "";
            if (number % 3 == 0)
                output += "Pling";
            if (number % 5 == 0)
                output += "Plang";
            if (number % 7 == 0)
                output += "Plong";
            if (output == "")
                return number.ToString();
            else
                return output;
        }
    }
}