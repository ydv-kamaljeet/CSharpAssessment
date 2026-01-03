namespace LibrarySystem.Items
{
    public class eBook : LibraryItem
    {
        public override void DisplayItemDetails()
        {
            Console.WriteLine("Item Type: eBook");
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("Item ID: " + ItemID);
        }

        public override double CalculateLateFee(int days)
        {
            return 0;
        }

        public void Download()
        {
            Console.WriteLine("eBook downloaded successfully.");
        }
        public void Open()
        {
            Console.WriteLine("eBook opened successfully.");   
        }
    }
}
