using System.Collections;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace MediSure
{
    /// <summary>
    /// Program Class : Entry Point of this project
    /// Need to make a Menu system to have some options like generate and clear bill , view last bill ,exit
    /// </summary>
    public class Program
    {
        //static object for Storing Old Bill and flag value of HasOldBill
         static bool HasOldBill=false;
        /// <summary>
        /// Main function of this project
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
           
            Helper helper= new Helper();
            
            #region User Input and related Action
            int choice=0;
            //Will take input from user until user enter "4" as input.    
            while (choice != 4)
            {
                helper.PrintMenu();     //to print the menu repeatedly.
                
                string? input = Console.ReadLine();
                if(!int.TryParse(input, out choice))
                    Console.WriteLine("Enter Valid Choice.");
                switch(choice){
                    case 1:
                        helper.RegisterPatient();     //Now we have stored the created Bill in OldBill to list it later.
                        HasOldBill = true;  
                        break;
                    case 2:
                        if(HasOldBill)
                            helper.ViewLastBill();   //Printing the Bill
                        else
                            Console.WriteLine("No Old Bill Available. First Create New Bill.");
                        break;
                    case 3:
                        helper.ClearLastBill();  //clear the Old Bill 
                        HasOldBill=false;
                        break;
                    case 4:
                        Console.WriteLine("Exiting.");  //Exiting from App
                        break;
                        
                    
                }

            }
            #endregion
        
        }
    }
}