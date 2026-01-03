namespace LibrarySystem.Items
{
    /// <summary>
    /// Its also a Library Item : Magazine
    /// child class of LibraryItem
    /// </summary>
    public class Magazine : LibraryItem
    {
        public override void DisplayItemDetails()
        {
            Console.WriteLine("Item Type: Magazine");
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("Item ID: " + ItemID);
        }

        public override double CalculateLateFee(int days)
        {
            return days * 0.5;
        }
    }
}
