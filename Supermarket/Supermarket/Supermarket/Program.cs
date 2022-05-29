using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Numerics;
using Supermarket.Model;
using Supermarket.Repository;

namespace Supermarket
{
	class Program
	{
		private ProductRepository productRepository;
		public Program()
        {
			productRepository = new ProductRepository();
			int menu = -1;
			do {
				Console.Clear();
				Console.WriteLine("Supermarket System");
				Console.WriteLine("==================");
				Console.WriteLine("1. Login as User");
				Console.WriteLine("2. Login as Admin");
				Console.WriteLine("3. Exit");

				do
				{
					Console.Write("Choice: ");
					menu = int.Parse(Console.ReadLine());

				} while (menu > 3 || menu < 1);
                switch (menu)
                {
					case 1:
						UserPage();
						break;
					case 2:
						AdminPage();
						break;
					case 3:
						break;
                }
			} while (menu != 3);
        }

		private void UserPage()
        {

			int userChoice = -1;
			do
			{
				Console.Clear();
				Console.WriteLine("USER");
				Console.WriteLine("====");
				Console.WriteLine("1. View Product");
				Console.WriteLine("2. Buy Product");
				Console.WriteLine("3. Exit");

				do
				{
					Console.Write("Choice: ");
					userChoice = int.Parse(Console.ReadLine());
					Console.WriteLine("");
				} while (userChoice > 3 || userChoice < 1);
                switch (userChoice)
                {
					case 1:
						View();
						break;
					case 2:
						break;
					case 3:
						break;
                }
			} while (userChoice != 3);
        }

		private void AdminPage()
        {
			Console.Clear();
			int adminChoice = -1;
			do
			{
				
				Console.WriteLine("ADMIN");
				Console.WriteLine("=====");
				Console.WriteLine("1. Insert Product");
				Console.WriteLine("2. Update Product");
				Console.WriteLine("3. Delete Product");
				Console.WriteLine("4. View Prodcut");
				Console.WriteLine("5. View Transaction");
				Console.WriteLine("6. Exit");

				do
				{
					Console.Write("Choice: ");
					adminChoice = int.Parse(Console.ReadLine());
					Console.WriteLine("");

				} while (adminChoice > 6 || adminChoice < 1);
                switch (adminChoice)
                {
					case 1:
						Insert();
						break;
					case 2:
						Update();
						break;
					case 3:
						Delete();
						break;
					case 4:
						View();
						break;
					case 5:
						break;
					case 6:
						break;
                }
			} while (adminChoice != 6);
        }

		private void Insert()
        {
			string name = "";
			BigInteger price = 0;
			int qty = 0;
			Console.Clear();
			do
			{
				Console.WriteLine("Insert Product Name [Length between 5-20]: ");
				name = Console.ReadLine();
			} while (name.Equals(""));
			do
			{
				Console.WriteLine("Insert Quantity [1-1000]: ");
				qty = int.Parse(Console.ReadLine());
			} while (qty < 1 || qty > 1000);
			do
			{
				Console.WriteLine("Insert Price [1000-1000000]: ");
				price  = int.Parse(Console.ReadLine());
			} while (price < 1000 || price > 1000000);

			Product product = new Product();
			product.ProductName = name;
            product.Price = (int)price;
            product.Quantity = qty;

			productRepository.Insert(product);
			Console.WriteLine("The product has been successfully inserted!");
			Console.WriteLine("Press enter to continue...");
			Console.ReadLine();
			Console.WriteLine("");
		}

		private void View()
        {
			
            List<Product> productList = productRepository.GetAll();
			if (productList.Count == 0)
            {
				Console.WriteLine("");
				Console.WriteLine("No product available!");
				Console.WriteLine("");
            }
            else
            {
				int i = 1;
				Console.Clear();
				Console.WriteLine("View Product");
				Console.WriteLine("============");
				foreach (Product product in productList)
                {
					
					Console.WriteLine("Product ID       : {0}", i++);
					Console.WriteLine("Product Name     : " + product.ProductName);
					Console.WriteLine("Product Quantity : " + product.Quantity);
					Console.WriteLine("Price            : Rp " + product.Price);
					Console.WriteLine("Press enter to continue...");
					Console.ReadLine();
					Console.WriteLine("");
                }
            }
        }

		private void Update()
        {
			Console.Clear();
			string UPname = "";
			int UPprice = 0;
			int UPqty = 0;
			int UpID = 0;
			Console.WriteLine("Update Product");
			Console.WriteLine("==============");
			do
			{
				Console.WriteLine("Input Product ID[1 - 10]: ");
				UpID = int.Parse(Console.ReadLine());
			} while (UpID > 10 || UpID < 1);
			do
			{
				Console.WriteLine("Insert Product Name [Length between 5-20]: ");
				UPname = Console.ReadLine();
			} while (UPname.Equals(""));
            do
			{
				Console.WriteLine("Insert Price [1000-1000000]: ");
				UPprice = int.Parse(Console.ReadLine());
			} while (UPprice < 1000 || UPprice > 1000000);
			do
			{
				Console.WriteLine("Insert Quantity [1-1000]: ");
				UPqty = int.Parse(Console.ReadLine());
			} while (UPqty < 1 || UPqty > 1000);

			Product product = new Product();
			product.ProductID = UpID;
			product.ProductName = UPname;
			product.Price = (int)UPprice;
			product.Quantity = UPqty;

			productRepository.Update(product);
			Console.WriteLine("The product has been successfully updated!");
			Console.WriteLine("Press enter to continue...");
			Console.ReadLine();
			Console.WriteLine("");
		}
		private void Delete()
        {
			Console.Clear();
			List<Product> productList = productRepository.GetAll();
			int deleteID = 0;
			string delChoice = "";
			do
			{
				Console.WriteLine("Input Product ID [1-10]: ");
				deleteID = int.Parse(Console.ReadLine());
			} while (deleteID < 1 || deleteID > 10);

			Product product = new Product();
			product.ProductID = deleteID;


			Console.WriteLine("Are you sure you want to delete this product? [Yes|No]: ");
			delChoice = Console.ReadLine();
				if (delChoice.Equals("Yes"))
				{
					productRepository.Delete(product);
					Console.WriteLine("The product has been successfully deleted!");
					Console.WriteLine("Press enter to continue...");
				    Console.WriteLine("");
				}
				else if (delChoice.Equals("No"))
				{
					Console.WriteLine("Press enter to continue...");
					Console.ReadLine();
				    Console.WriteLine("");
            }
            else
            {
				Console.WriteLine("Unknown choice");
				Console.WriteLine("Press enter to continue...");
				Console.ReadLine();
				Console.WriteLine("");
			}






		}

		static void Main(string[] args)
		{
			new Program();
		}
	}
}
