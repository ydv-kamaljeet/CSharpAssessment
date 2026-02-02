namespace Meeting;
public class Program
{
    public static void Main()
    {
        Child c = new Child();
        c.PrintGFather();
        c.PrintFather();
        c.PrintChild();
    }
}

public class GrandFather
{
    public void PrintGFather(){
        Console.WriteLine("Hello grand father");
    }
}
public class Father : GrandFather
{
     public void PrintFather(){
        Console.WriteLine("Hello father");
    }
}

public class Child : Father
{   
    public void PrintChild(){
        Console.WriteLine("Hello child");
    }
    
}