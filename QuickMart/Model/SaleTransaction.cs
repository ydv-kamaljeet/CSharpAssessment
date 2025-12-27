namespace QuickMart
{
    public  class SaleTransaction
    {
        // Attributes declaration
        public string? invoiceId{get; set;}
        public string? customerName{get; set;}
        public string? itemName{get; set;}
        public int qty{get; set;}
        public float buyPrice{get; set;}
        public float sellPrice{get; set;}

        // Constructor Declaration
        public SaleTransaction(string invoice, string customer, string item, int quantity, float purchase, float selling)
        {
            invoiceId = invoice;
            customerName = customer;
            itemName = item;
            qty = quantity;
            buyPrice = purchase;
            sellPrice = selling;
        }


    }
}