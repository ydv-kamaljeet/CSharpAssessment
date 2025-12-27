namespace MediSure
{
    /// <summary>
    /// Class containing properties related to Patient Bill
    /// </summary>
    public class PatientBill
    {
        public string? BillId{get;set;}
        public string? PatientName{get;set;}
        public bool HasInsurance{get;set;}
        public double ConsultingFee{get;set;}
        public double LabCharges{get;set;}
        public double MedicineCharges{get;set;}

        public double GrossAmount;
        public double DiscountAmount;
        public double FinalPayable;
        
    }
}