using LLIntroducingEntityFramework.Data;
using LLIntroducingEntityFramework.Models;
using System;
using System.Linq;

namespace LLIntroducingEntityFramework
{
	class Program
	{
		static void Main(string[] args)
		{
			// using declaration ensures that the contosopets objet is
			// disposed properly when we're done using it.
			using ContosoPetsContext context = new ContosoPetsContext();

			// DELETING & SELECTING
			var squeakyBone = context.Products
				.Where(p => p.Name == "Squeaky Dog Bone")
				.FirstOrDefault();

			if (squeakyBone is Product)
			{
				context.Remove(squeakyBone);
			}

			context.SaveChanges();

			// using linq
			var products = from product in context.Products
						   where product.Price > 5.00m
						   orderby product.Name
						   select product;

			foreach (Product p in products)
			{
				Console.WriteLine($"Id:      {p.Id}");
				Console.WriteLine($"Name:    {p.Name}");
				Console.WriteLine($"Price:   {p.Price}");
				Console.WriteLine(new string('-', 20));
			}

			/* UPDATING & SELECTING
			var squeakyBone = context.Products
				.Where(p => p.Name == "Squeaky Dog Bone")
				.FirstOrDefault();

			if (squeakyBone is Product)
			{
				squeakyBone.Price = 7.99m;
			}

			context.SaveChanges();

			// using linq
			var products = from product in context.Products
						   where product.Price > 5.00m
						   orderby product.Name
						   select product;

			foreach (Product p in products)
			{
				Console.WriteLine($"Id:      {p.Id}");
				Console.WriteLine($"Name:    {p.Name}");
				Console.WriteLine($"Price:   {p.Price}");
				Console.WriteLine(new string('-', 20));
			}*/

			/** SELECTING
			 * 
			 //using fluent api
			var products = context.Products
				.Where(p => p.Price >= 5.00m)
				.OrderBy(p => p.Name);

			foreach (Product p in products)
			{
				Console.WriteLine($"Id:      {p.Id}");
				Console.WriteLine($"Name:    {p.Name}");
				Console.WriteLine($"Price:   {p.Price}");
				Console.WriteLine(new string('-', 20));
			}*/

			/*
			 * 
			 * INSERTING
			Product squeakyBone = new Product()
			{
				Name = "Squeaky Dog Bone",
				Price = 4.99M
			};

			context.Products.Add(squeakyBone);

			Product tennisBalls = new Product()
			{
				Name = "Tennis Ball 3-Pack",
				Price = 9.99M
			};

			// Didn't added to the context.Products bevause
			// EF knows it is a Product
			context.Add(tennisBalls);

			context.SaveChanges();
			*/
		}
	}
}
