namespace LibrarySystem.Items
{
    public class Book : LibraryItem, IReservable, INotifiable
    {
        public override void DisplayItemDetails()
        {
            Console.WriteLine("Item Type: Book");
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("Item ID: " + ItemID);
        }

        public override double CalculateLateFee(int days)
        {
            return days * 1;
        }

        // Explicit interface implementation
        void IReservable.Reserve()
        {
            Console.WriteLine("Book reserved successfully.");
        }

        void INotifiable.Notify(string message)
        {
            Console.WriteLine("Notification sent: " + message);
        }
    }
}
