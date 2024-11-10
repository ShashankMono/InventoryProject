using InventoryProject.Controllers;
using InventoryProject.Exceptions;
using InventoryProject.Models;
using InventoryProject.TypeOfTransaction;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Presentation
{
    internal class PresentInventory
    {
        public static ProductController productController = new ProductController();
        public static void DisplayMainMenu()
        {
            while (true)
            {
                Console.WriteLine($"Welcome to the Inventory Management System\n" +
                    $"1. Product Management\n" +
                    $"2. Supplier Management\n" +
                    $"3. Transaction Management\n" +
                    $"4. Generate Report\n" +
                    $"5. Exit\n");

                int choice = int.Parse(Console.ReadLine());
                ExcuteMainMenu(choice);
            }

        }

        public static void ExcuteMainMenu(int choice) { 
            switch (choice)
            {
                case 1:
                    DisplayProductMenu();
                    break;
                case 2:
                    DisplaySupplierMenu();
                    break;
                case 3:
                    DisplayTransactionMenu();
                    break;
                case 4:
                    GetReport();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please choose correct option");
                    break;

            }
        }

        public static void DisplayProductMenu()
        {
            while (true) { 
                Console.WriteLine($"What do you wish to do!\n" +
                $"1 Add Product\n" +
                $"2 Update Product\n" +
                $"3 Delete Product\n" +
                $"4 View Product's Details\n" +
                $"5 View All Products\n" +
                $"6 Go Back Main Menu\n");
                int choice = int.Parse(Console.ReadLine());
                ExcuteProductMenu(choice);
            }
             
        }

        public static int ShowInventory()
        {
            Console.WriteLine("1. Mumbai\n" +
                "2. Lucknow\n" +
                "3. Utar Pradesh\n" +
                "4. Delhi\n");
            Console.WriteLine("Enter Inventory Id: ");
            int inventoryId = int.Parse(Console.ReadLine());
            if(inventoryId <= 0 || inventoryId > 4)
            {
                throw new InvalidInventoryIdException("Invalid Inventory Id!");
            }
            return inventoryId;
        }

        public static void ExcuteProductMenu(int choice)
        {

            switch (choice)
            {
                case 1:
                    AddNewProduct();
                    break;
                case 2:
                    UpdateProductDetails();
                    break;
                case 3:
                    Delete(productController);
                    break;
                case 4:
                    GetDetail(productController);
                    break;
                case 5:
                    GetAllDetail(productController);
                    break;
                case 6:
                    DisplayMainMenu();
                    break ;
                default:
                    Console.WriteLine("Please choose correct option");
                    break;
            }
        }

        public static (string,string,double,int) TakeDetailsOfProduct()
        {
            try
            {
                Console.WriteLine("Enter Name of the Product: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Description of the Product: ");
                string description = Console.ReadLine();
                Console.WriteLine("Enter price per unit of product: ");
                double price = double.Parse(Console.ReadLine());
                int inventoryId = ShowInventory();
                return (name, description, price, inventoryId);
            }
            catch (Exception e) {
                Console.WriteLine($"{e.Message}");
                return TakeDetailsOfProduct();
            }
        }

        public static void AddNewProduct()
        {  
            try
            {
                (string name, string description, double price,int inventoryId) = TakeDetailsOfProduct();
                Console.WriteLine("Enter quantity : ");
                int quatity = int.Parse(Console.ReadLine());
                productController.AddNewProduct(name,description,quatity,price,inventoryId);
                Console.WriteLine("Product Added successfully!");
            }catch (Exception ex) { 
                Console.WriteLine(ex.Message); 
            }
        } 

        public static void UpdateProductDetails()
        {
            Console.WriteLine("Enter Id of the product detail to be update:");
            int id = int.Parse(Console.ReadLine()) ;
            try
            {
                Product product = productController.GetProduct(id);
                (string name, string description, double price,int inventoryId) = TakeDetailsOfProduct();
                productController.UpdateDetails(product, name, description, price,inventoryId);
                Console.WriteLine("Detail Updated succefully!");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DisplaySupplierMenu()
        {
            while (true)
            {
                Console.WriteLine($"What do you wish to do!\n" +
                $"1 Add Supplier\n" +
                $"2 Update Supplier\n" +
                $"3 Delete Supplier\n" +
                $"4 View Supplier's Details\n" +
                $"5 View All Suppliers\n" +
                $"6 Go Back Main Menu\n");
                int choice = int.Parse(Console.ReadLine());
                ExcuteSupplierMenu(choice);
            }
        }

        public static void ExcuteSupplierMenu(int choice)
        {
            SupplierController controller = new SupplierController();
            switch (choice)
            {
                case 1:
                    AddNewSupplier(controller);
                    break;
                case 2:
                    UpdateSupplierDetails(controller);
                    break;
                case 3:
                    Delete(controller);
                    break;
                case 4:
                    GetDetail(controller);
                    break;
                case 5:
                    GetAllDetail(controller);
                    break;
                case 6:
                    DisplayMainMenu();
                    break;
                default:
                    Console.WriteLine("Please choose correct option");
                    break;
            }
        }

        public static (string,string,int) TakeDetailsOfSupplier()
        {
            string name = "";string ContactNumber = "";int inventoryId = 0;
            try
            {
                Console.WriteLine("Enter Name of the Supplier: ");
                name = Console.ReadLine();
                Console.WriteLine("Enter contact number of Supplier: ");
                ContactNumber = Console.ReadLine();
                inventoryId = ShowInventory();

                return (name, ContactNumber, inventoryId);
            }
            catch (Exception e) {
                Console.WriteLine($"{e.Message}");
                return TakeDetailsOfSupplier();
            }
        }

        public static void AddNewSupplier(SupplierController controller)
        {
            (string name, string ContactNumber, int inventoryId) = TakeDetailsOfSupplier();

            try
            {
                controller.AddNewSupplier(name, ContactNumber,inventoryId);
                Console.WriteLine("Supplier Added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateSupplierDetails(SupplierController Controller)
        {
            Console.WriteLine("Enter Id of the Supplier detail to be update:");
            int id = int.Parse(Console.ReadLine());
            try
            {
                Supplier supplier = Controller.Getsupplier(id);
                (string name, string ContactNumber, int inventoryId) = TakeDetailsOfSupplier();
                Controller.UpdateDetails(supplier, name,ContactNumber,inventoryId);
                Console.WriteLine("Detail Updated succefully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Delete(Controller controller) {
            try
            {
                Console.WriteLine("Enter Id: ");
                int id = int.Parse(Console.ReadLine());
                controller.Delete(id);
                Console.WriteLine("Deleted successfully!");
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
        }

        public static void GetDetail(Controller controller)
        {
            try
            {
                Console.WriteLine("Enter Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine(controller.GetDetails(id));

            }
            catch (Exception ex) { 
                Console.WriteLine($"{ex.Message}");
            }
        }
        public static void GetAllDetail(Controller controller)
        {
            Console.WriteLine(controller.GetAllDetails());
        }

        public static void DisplayTransactionMenu()
        {
            while (true)
            {
                Console.WriteLine("What do you wish to do!\n" +
                    "1. Add Stock\n" +
                    "2. Remove Stock\n" +
                    "3. View All transaction\n" +
                    "4. Go back to main memory\n");
                int choice = int.Parse(Console.ReadLine()) ;
            }
        }

        public static void ExcuteTransactionMenu(int choice)
        {
            TransactionController controller = new TransactionController();
            switch (choice)
            {
                case 1:
                    Stock(controller,TypeOfTransactions.Add);
                    break;
                case 2:
                    Stock(controller,TypeOfTransactions.Remove);
                    break;
                case 3:
                    Console.WriteLine(controller.GetAllTransaction());
                    break;
                case 4:
                    DisplayMainMenu();
                    break;
                default:
                    Console.WriteLine("Please choose correct option");
                    break;
            }
        }

        public static void Stock(TransactionController controller,TypeOfTransactions type)
        {
            try
            {
                Console.WriteLine("Enter product Id: ");
                int id = int.Parse(Console.ReadLine());
                Product product = productController.GetProduct(id);
                Console.WriteLine("Enter Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                controller.ChangeStock(product,quantity,type);
                Console.WriteLine($"Stock Update : {type.ToString()}");
            }catch (Exception ex) { 
                Console.WriteLine(ex.ToString()); 
            }
        }

        public static void GetReport()
        {
            InventoryController inventoryController = new InventoryController();
            Console.WriteLine(inventoryController.GetAllReport());
        }

    }
}
