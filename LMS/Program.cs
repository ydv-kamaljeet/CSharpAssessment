using LibrarySystem;
using LibrarySystem.Users;
using ItemAlias = LibrarySystem.Items;      //Task 5
namespace LMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("--Task 1--");
            #region //Task 1 : Create Object of Book and Magazine class and call it's DisplayDetail mehtod.
            var b = new ItemAlias.Book{Title="C# complete Guide",Author="Kamaljeet",ItemID=101};    //Task 5 : Using Alias
            b.DisplayItemDetails();
            Console.WriteLine("Late Fee for 3 days: " + b.CalculateLateFee(3));
            var mg = new ItemAlias.Magazine{Title="Stranger Things",Author="Igloo",ItemID=102};
            mg.DisplayItemDetails();
            Console.WriteLine("Late Fee for 3 days: " + mg.CalculateLateFee(3));

            Console.WriteLine();
            #endregion

            Console.WriteLine("--Task 2 and Task 4--");
            #region //Task 2 and Task 4 : Implement the Ireservable and Inotifyable interfaces to Book class and implement all its methods and call it
            IReservable reservable = b;
            INotifiable notifiable = b;
            reservable.Reserve();
            notifiable.Notify("Your reserved book is ready for pickup.");

            Console.WriteLine("\nExplaination: Direct access to the method is restricted to avoid the confusion.\nLike compiler will not recognized whose interface method should i call? Thats why we are explicitly implementing methods");
            Console.WriteLine();
            #endregion

            Console.WriteLine("--Task 3--");
            #region // Task 3: Polymorphism
            var items = new List<ItemAlias.LibraryItem>();  //Task 5 : Using Alias
            items.Add(b);   //object of class Book is added in items
            items.Add(mg);  //object of magazine class is added in items list. 
            foreach (var item in items)
            {
                item.DisplayItemDetails();   //Runtime Polymorphism : "Method selection happens at runtime." {Method Overriding}
            }

            //Explaination :
            Console.WriteLine("\nExplaination : DisplayItemDetails() method is available in multiple object {i.e. Book class object , Magazine class object}.So which objects methods will be called is purely depends on runtime.\nWhen item{reference variable} is pointing to book class object, it will call its mehtod and when it points to magazine class object it will to magazine's method");
            Console.WriteLine();
            #endregion
            
            #region Task 5:
            Console.WriteLine("\nTask 5 Explaination : Nested namespaces in C# are useful \nbecause they organize code hierarchically, making large projects easier to manage, avoid name conflicts, and group related functionality logically.");
            Console.WriteLine();
            #endregion

            Console.WriteLine("--Task 6--");
            #region // Task 6 static + partial
            LibraryAnalytics.TotalBorrowedItems = 5;
            LibraryAnalytics.DisplayAnalytics();
            LibraryAnalytics.TotalBorrowedItems++;
            LibraryAnalytics.DisplayAnalytics();
            Console.WriteLine("\nExplaination: Static members are associated to class itself not object. \nSo it remains in the memory till the application ends. So we can access that static member without creating object");
            Console.WriteLine();
            #endregion

            Console.WriteLine("--Task 7--");
            #region // Task 7 enums
            Member member = new Member{Name = "Amit", Role = UserRole.Librarian};
            ItemStatus status = ItemStatus.Borrowed;
            Console.WriteLine("User Role: " + member.Role);
            Console.WriteLine("Item Status: " + status);
            Console.WriteLine();
            #endregion

            Console.WriteLine("--Bonus Task--");
            #region //Bonus Task
            notifiable.SendNotification(member.Role);   //Sending the notification according to role.
            var ebook = new ItemAlias.eBook{Title = "Digital C#", Author = "E Author", ItemID = 301}; 
            ebook.Download();
            ebook.Open();
            #endregion
            
        }
    }
}