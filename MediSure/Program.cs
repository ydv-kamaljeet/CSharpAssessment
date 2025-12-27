using System.Collections;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace MediSure
{
    public class Program
    {
        //static object for Storing Old Bill and flag value of HasOldBill
         static bool HasOldBill=false;
         static PatientBill OldBill;
        /// <summary>
        /// Main function of this project
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
           
            Helper helper= new Helper();
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
                        OldBill = helper.RegisterPatient();     //Now we have stored the created Bill in OldBill to list it later.
                        HasOldBill = true;  
                        break;
                    case 2:
                        if(HasOldBill)
                            helper.ViewLastBill(OldBill);   //Printing the Bill
                        else
                            Console.WriteLine("No Old Bill Available. First Create New Bill.");
                        break;
                    case 3:
                        helper.ClearLastBill(OldBill);  //clear the Old Bill 
                        HasOldBill=false;
                        break;
                    case 4:
                        Console.WriteLine("Exiting.");  //Exit from App
                        break;
                        
                    
                }

            }
        }
    }
}