namespace QuickMart
{
    public class Program
    {
        /// <summary>
        /// Main Function : Entry Point of this project
        /// It will create object of Helper class and then helper class will do the remaining task.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Helper hp = new Helper();   //Creating object of DataBank Class having all the necessary functionality.
            hp.MakeSale();
        }
    }
}