using System.Security.Cryptography.X509Certificates;

namespace MediSure
{
    public class Helper
    {
        static PatientBill LastBill;
        /// <summary>
        /// Member function to Print the Menu.
        /// </summary>
        #region Print Menu
        public void PrintMenu()
        {
            Console.WriteLine("Select any one option :");
            Console.WriteLine("1. Create New Bill\n2. View Last Bill\n3. Clear Last Bill\n4. Exit");
            Console.WriteLine("");//To Make the menu look clean
        }
        #endregion
        
        /// <summary>
        /// Member function to Register the details of Patient and create a bill
        /// </summary>
        /// <returns></returns>
        #region  Bill Creation/ Patient Registeration
        public void RegisterPatient()
        {
            
            Console.WriteLine("Enter BillId : ");
            string? id = Console.ReadLine();

            //id validation
            if(string.IsNullOrEmpty(id))
            {
                Console.WriteLine("Enter valid Bill Id.");
                return;
            }

            Console.WriteLine("Enter Patient Name : ");
            string? name = Console.ReadLine();

            Console.WriteLine("Do you have Insurance?\ntrue = Yes\nfalse=No");
            string? insurance= Console.ReadLine();
            bool.TryParse(insurance,out bool hasInsurance);

            Console.WriteLine("Enter Consultation Fees : ");
            string? consultation = Console.ReadLine();
            double.TryParse(consultation,out double consultationFee);

            Console.WriteLine("Enter Lab charges : ");
            string? lab = Console.ReadLine();
            double.TryParse(lab,out double labCharges);

            Console.WriteLine("Enter Medicine charges : ");
            string? med = Console.ReadLine();
            double.TryParse(med,out double medCharges);

            // validating fees 
            if(consultationFee <= 0)
            {
                Console.WriteLine("Enter Valid consultation Fee.");
                return;
            }
            if(labCharges+medCharges < 0)
            {
                Console.WriteLine("Enter Valid Lab and Medicine Charges.");
                return;
            }

            //Calculating gross charges
            double grossAmount = consultationFee+labCharges+medCharges;
            double discountAmount=0;
            if(hasInsurance) discountAmount = grossAmount*0.10;
            double finalAmount=grossAmount-discountAmount;
            
            LastBill = new PatientBill(){BillId=id,PatientName=name,HasInsurance=hasInsurance,ConsultingFee=consultationFee,LabCharges=labCharges,MedicineCharges=medCharges,GrossAmount=grossAmount,DiscountAmount=discountAmount,FinalPayable=finalAmount};
            
            Console.WriteLine("Bill Created Successfully.");
        }
        #endregion

        /// <summary>
        /// Member function to Print the Bill
        /// </summary>
        /// <param name="pb"></param>
        #region View Last Bill
        public void ViewLastBill()
        {
            try{
                if (LastBill == null)   //In case we have cleared the bill
                {
                    Console.WriteLine("Bill is not created successfully, so create the Bill first by giving valid input");
                }else{
                Console.WriteLine($"Bill Id : {LastBill.BillId}\nPatient Name : {LastBill.PatientName}");
                Console.WriteLine($"Insured : {LastBill.HasInsurance}\nConsultation Fees : {LastBill.ConsultingFee}");
                Console.WriteLine($"Lab Charges : {LastBill.LabCharges}\nMedicine Charges : {LastBill.MedicineCharges}");
                Console.WriteLine($"Gross Amount : {LastBill.GrossAmount}\nDiscount : {LastBill.DiscountAmount}\nFinal Payable Amount : {LastBill.FinalPayable}");
                }
            }
            catch (NullReferenceException)  //after clearing bill , LastBill is pointing to null, to handle that null reference exception
            {
                Console.WriteLine("You are not giving valid input thats why last bill was not created.");
            }
        }
        #endregion
        
        //Member function to clear the Old Bill
        #region  Clear Previous Bill
        public void ClearLastBill()
        {
            LastBill=null;
            Console.WriteLine("Bill Cleared.");

        }
        #endregion

    }
}