namespace LibrarySystem.Items
{
    /// <summary>
    /// Its a Library Item : Book having some properties and behaviours 
    /// </summary>
    public class Book : LibraryItem, IReservable, INotifiable
    {
        //We are overriding this method bacause while call this method in for loop and magazine also have this method. that why we are overriding it
        public override void DisplayItemDetails()
        {
            Console.WriteLine("Item Type: Book");
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("Item ID: " + ItemID);
        }

        public override double CalculateLateFee(int days)   //Implementing runtime Polymorphism
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
        //Sending notification according to role of user.
        void INotifiable.SendNotification(UserRole role)
        {
            if (role == UserRole.Admin)
                Console.WriteLine("Admin Alert: System Update is Available and Maintenance required.");
            else
                Console.WriteLine("Member Notification: Your borrowed item need to be submit by tommorow.");
        }
    }
}
