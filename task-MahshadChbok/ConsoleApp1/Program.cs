using System;
using System.Collections.Generic;
using System.Linq;


// i use this site :https://www.c-sharpcorner.com/article/linq-methods/
namespace LinqTask
{
class Product
{
    // properties
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public int Price { get; set; }
}

class TaskQuery
{
  static void Main()
    {

        // this is our data storage
        List<Product> allProducts = new List<Product>{
            new Product { Id = 1, Name = "Product A", Category = "Category 1", Price = 100 },
            new Product { Id = 2, Name = "Product B", Category = "Category 2", Price = 150 },
            new Product { Id = 3, Name = "Product C", Category = "Category 1", Price = 120 },
            new Product { Id = 4, Name = "Product D", Category = "Category 3", Price = 200 },
            new Product { Id = 5, Name = "Product E", Category = "Category 2", Price = 80 }
        };
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------");


       // we check the list and find all products with Category=="Category 1
        var q1 = from p in allProducts
                  where p.Category=="Category 1"
                  select p;
        Console.Write("All products ids with Category 1 are: ");
        string s = "";
        foreach(Product p in q1){
           s=s+p.Id+" ,";
        }
        s=s.Remove(s.Length - 1);
        Console.WriteLine(s);
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------");


       // we check the list and find  product with greatest price (we order the list depent on price and return the first elememt )
        var q2 = (from p in allProducts orderby p.Price descending select p).FirstOrDefault();
        if (q2 !=null){
           Console.Write("Product id with max price : "); 
           Console.WriteLine(q2.Id);
        }
        else{
            Console.WriteLine("List is empty");
        }
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
      

       //we check the list and calculate summation of price of products (we sum the price of all products)
        var q3 = (from p in allProducts select p.Price).Sum();
        Console.Write("Sum of all products is : ");
        Console.WriteLine(q3);
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------");


        // we group all products by their category(ToLookup==groupby)
         var q4 =(from p in allProducts select p).ToLookup(x =>x.Category );
         foreach(var grp in q4)
		{
			Console.WriteLine($"{grp.Key} : \n   count of products in this category is : {grp.Count()}");
            
				foreach (var item in grp)
                {
					Console.WriteLine($"   Name: {item.Name} => Id: {item.Id} ");
				}
                
		}
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------");


        //we average from  price of all products in list.
        var q5 = (from p in allProducts select p.Price).Average();
        Console.Write("Average of price of  products is : ");
        Console.WriteLine(q5);
    }
}
}