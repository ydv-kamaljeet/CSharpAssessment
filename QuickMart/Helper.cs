namespace QuickMart
{
    class DataBank
    {
        private static SaleTransaction lastSale;

        public void MakeSale() // Sale is void function which will print the results
        {
            int choice;
            
            do
            {
                // Taking Inputs from Users To Choose the Create, View , Calculate, Exit
                Console.WriteLine("1. Create New Transaction (Enter Purchase & Selling Details)");
                Console.WriteLine("2. View Last Transaction");
                Console.WriteLine("3. Calculate Profit/Loss");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                
                // Taking Input 
                string? input = Console.ReadLine();
                // Type Conversion string -> int
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                // Using Switch to perform Operations 
                switch (choice)
                {
                    case 1:
                        addTransaction();
                        break;
                    case 2:
                        viewTransaction();
                        break;
                    case 3:
                        calcProfit();
                        break;
                    case 4:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 4);
        }

        // Function to Create new Transaction
        private static void addTransaction()
        {
            // Taking the Inputs 
            Console.WriteLine("Enter Invoice No");
            string? invoiceNo = Console.ReadLine();
            Console.WriteLine("Enter Customer Name");
            string? custName = Console.ReadLine();
            Console.WriteLine("Enter Item Name");
            string? product = Console.ReadLine();
            Console.WriteLine("Enter Item Quantity");
            string? quantity = Console.ReadLine();
            Console.WriteLine("Enter Purchase Amount");
            string? buyAmt = Console.ReadLine();
            Console.WriteLine("Enter Selling Amount");
            string? sellAmt = Console.ReadLine();
            //validating Invoice Number
            if (string.IsNullOrEmpty(invoiceNo))
            {
                Console.WriteLine("Enter Valid Invoice Number.");
                return;
            }

            if (!int.TryParse(quantity, out int qty) || 
                !float.TryParse(buyAmt, out float purchasePrice) || 
                !float.TryParse(sellAmt, out float sellingPrice))
            {
                Console.WriteLine("Invalid numeric input. Transaction not created.");
                return;
            }
            //validating quantity
            if(qty <=0)
            {
                Console.WriteLine("Quantity must be greater than 0");
                return;
            }

            if(purchasePrice <=0)
            {
                Console.WriteLine("Purchase Amount must be greater than 0");
                return;
            }
            if(sellingPrice <0)
            {
                Console.WriteLine("SellingPrice  must be greater than equal to 0");
                return;
            }
           

            lastSale = new SaleTransaction(invoiceNo, custName, product, qty, purchasePrice, sellingPrice);
            Console.WriteLine("Transaction created successfully!");
        }

        // Function for viewing the LastTransaction
        private static void viewTransaction()
        {
            if (lastSale == null)
            {
                Console.WriteLine("No transaction found. Please create a transaction first.");
                return;
            }

            Console.WriteLine("Invoice No: " + lastSale.invoiceId);
            Console.WriteLine("Customer Name: " + lastSale.customerName);
            Console.WriteLine("Item Name: " + lastSale.itemName);
            Console.WriteLine("Item Quantity: " + lastSale.qty);
            Console.WriteLine("Purchase Amount: " + lastSale.buyPrice);
            Console.WriteLine("Selling Amount: " + lastSale.sellPrice);
            Console.WriteLine();    //Extra Line Space to make it looks clean
        }
        // Function for Calcualting 
        private static void calcProfit()
        {
            if (lastSale == null)
            {
                Console.WriteLine("No transaction found. Please create a transaction first.");
                return;
            }

            float profitLoss = lastSale.sellPrice - lastSale.buyPrice;
            string status;
            
            if (profitLoss > 0)
            {
                status = "PROFIT";
            }
            else if (profitLoss < 0)
            {
                status = "LOSS";
            }
            else
            {
                status = "BREAK-EVEN";
            }
            
            float margin = profitLoss / lastSale.buyPrice * 100;
            Console.WriteLine("Profit/Loss amount: " + profitLoss);
            Console.WriteLine("ProfitMarginPercent = " + margin);
            Console.WriteLine("ProfitOrLossStatus = " + status);
        }
    }
}