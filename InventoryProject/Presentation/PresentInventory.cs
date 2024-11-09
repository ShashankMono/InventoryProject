using InventoryProject.Controllers;
using InventoryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Presentation
{
    internal class PresentInventory
    {
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

        public static void ExcuteProductMenu(int choice)
        {
            ProductController controller = new ProductController();
            switch (choice)
            {
                case 1:
                    AddNewProduct(controller);
                    break;
                case 2:
                    UpdateProductDetails(controller);
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
                    return;
            }
        }

        public static void AddNewProduct(ProductController controller)
        {
            Console.WriteLine("Enter Name of the Product: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Description of the Product: ");
            string description = Console.ReadLine();
            Console.WriteLine("Enter quantity : ");
            int quatity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter price per unit of product: ");
            double price = double.Parse(Console.ReadLine());

            try
            {
                controller.AddNewProduct(name,description,quatity,price);
                Console.WriteLine("Product Added successfully!");
            }catch (Exception ex) { 
                Console.WriteLine(ex.Message); 
            }
        } 

        public static void UpdateProductDetails(ProductController Controller)
        {
            Console.WriteLine("Enter Id of the product detail to be update:");
            int id = int.Parse(Console.ReadLine()) ;
            try
            {
                Product product = Controller.GetProduct(id);
                Console.WriteLine("Enter Name of the Product: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Description of the Product: ");
                string description = Console.ReadLine();
                Console.WriteLine("Enter price per unit of product: ");
                double price = double.Parse(Console.ReadLine());
                Controller.UpdateDetails(product, name, description, price);
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
                    return;
            }
        }

        public static void AddNewSupplier(SupplierController controller)
        {
            Console.WriteLine("Enter Name of the Supplier: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter contact number of Supplier: ");
            string ContactNumber = Console.ReadLine();

            try
            {
                controller.AddNewSupplier(name, ContactNumber);
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
                Console.WriteLine("Enter Name of the Product: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter contactNumber of the Product: ");
                string ContactNumber = Console.ReadLine();
                Console.WriteLine("Enter price per unit of product: ");
                Controller.UpdateDetails(supplier, name,ContactNumber);
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
    }
}
