namespace QuickMart
{
    public class Program
    {
        /// <summary>
        /// Main Function : Entry Point of this project
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Helper hp = new Helper();   //Creating object of DataBank Class having all the necessary functionality.
            hp.MakeSale();
        }
    }
}