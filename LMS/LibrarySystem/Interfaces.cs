namespace LibrarySystem
{
    public interface IReservable
    {
        void Reserve();
    }

    public interface INotifiable
    {
        void Notify(string message);
    }
}
