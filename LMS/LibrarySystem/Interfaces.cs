namespace LibrarySystem
{
    //Interface for Setting methods for reservering a Library Item
    public interface IReservable
    {
        void Reserve();
    }

    //Interface have declaration of ways of sending notification
    public interface INotifiable
    {
        void Notify(string message);
        void SendNotification(UserRole role);

        
    }
}
