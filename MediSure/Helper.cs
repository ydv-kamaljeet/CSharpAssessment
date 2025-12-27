using System.Security.Cryptography.X509Certificates;

namespace MediSure
{
    public class Helper
    {
        
        /// <summary>
        /// Member function to Print the Menu.
        /// </summary>
        public void PrintMenu()
        {
            Console.WriteLine("Select any one option :");
            Console.WriteLine("1. Create New Bill\n2. View Last Bill\n3. Clear Last Bill\n4. Exit");
            Console.WriteLine("");//To Make the menu look clean
        }

        /// <summary>
        /// Member function to Register the details of Patient and create a bill
        /// </summary>
        /// <returns></returns>
        public PatientBill RegisterPatient()
        {
            
            Console.WriteLine("Enter BillId : ");
            string? id = Console.ReadLine();

            //id validation
            if(id == null || id == "")
            {
                Console.WriteLine("Enter valid Bill Id.");
                
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
                
            }
            if(labCharges+medCharges < 0)
            {
                Console.WriteLine("Enter Valid Lab and Medicine Charges.");
                
            }

            //Calculating gross charges
            double grossAmount = consultationFee+labCharges+medCharges;
            double discountAmount=0;
            if(hasInsurance) discountAmount = grossAmount*0.10;
            double finalAmount=grossAmount-discountAmount;
            
            PatientBill pb = new PatientBill(){BillId=id,PatientName=name,HasInsurance=hasInsurance,ConsultingFee=consultationFee,LabCharges=labCharges,MedicineCharges=medCharges,GrossAmount=grossAmount,DiscountAmount=discountAmount,FinalPayable=finalAmount};
            
           return pb;
        }

        /// <summary>
        /// Member function to Print the Bil
        /// </summary>
        /// <param name="pb"></param>
        public void ViewLastBill(PatientBill pb)
        {
            if (pb == null)
            {
                Console.WriteLine("Bill is not created successfully, so create the Bill first by giving valid input");
            }
            Console.WriteLine($"Bill Id : {pb.BillId}\nPatient Name : {pb.PatientName}");
            Console.WriteLine($"Insured : {pb.HasInsurance}\nConsultation Fees : {pb.ConsultingFee}");
            Console.WriteLine($"Lab Charges : {pb.LabCharges}\nMedicine Charges : {pb.MedicineCharges}");
            Console.WriteLine($"Gross Amount : {pb.GrossAmount}\nDiscount : {pb.DiscountAmount}\nFinal Payable Amount : {pb.FinalPayable}");
        }

        //Member function to clear the Old Bill
        public void ClearLastBill(PatientBill pb)
        {
            pb=null;
            Console.WriteLine("Bill Cleared");

        }

    }
}