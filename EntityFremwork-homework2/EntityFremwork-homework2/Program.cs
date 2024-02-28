

using EntityFremwork_homework2;
using EntityFremwork_homework2.Models;
using Microsoft.EntityFrameworkCore;

AppDbContext appDbContext = new AppDbContext();

string opt;
do
{

    Console.WriteLine("\n\n");
    Console.WriteLine("1 Brand Add :");
    Console.WriteLine("2 Delete by id Brand :");
    Console.WriteLine("3 GetAll Brands :");
    Console.WriteLine("4 Get by id Brand");
    Console.WriteLine("5 Update Brand :");
    Console.WriteLine("\n \a =======================================\n");
    Console.WriteLine("6 Product Add :");
    Console.WriteLine("7 Delete Product :");
    Console.WriteLine("8 GetAll Product And brand :");
    Console.WriteLine("9 Get by id Product :");
    Console.WriteLine("10 Update Product :");
    opt = Console.ReadLine();


    switch (opt)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("Name:");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name bos ola bilmez");
                break;
            }

            Brand brand = new Brand()
            {
                Name = name
            };

            appDbContext.Brands.Add(brand);
            appDbContext.SaveChanges();
            break;
        case "2":
            Console.Clear();
            Console.WriteLine("Id :");
            string idopt = Console.ReadLine();

            int id;
            if (!int.TryParse(idopt, out id))
            {
                Console.WriteLine("Duzgun id daxil edin");
                break;
            }


            var findid = appDbContext.Brands.Find(id);
            try
            {
                appDbContext.Brands.Remove(findid);
            }
            catch
            {

                Console.WriteLine("id tapilmadi");
                break;
            }
            appDbContext.SaveChanges();
            break;
        case "3":
            Console.Clear();
            var brands = appDbContext.Brands.ToList();

            foreach (var item in brands)
            {
                Console.WriteLine(item);
            }
            break;
        case "4":
            Console.Clear();
            Console.WriteLine("Id :");
            idopt = Console.ReadLine();
             
            if (!int.TryParse(idopt,out id))
            {
                Console.WriteLine("Duzgun id daxil edin");
                break;
            }

            var brandid = appDbContext.Brands.Find(id);

            Console.WriteLine(brandid);
            break;
        case "5":
            Console.Clear();
            Console.WriteLine("Id :");
            idopt = Console.ReadLine();
            if (!int.TryParse(idopt,out id))
            {
                Console.WriteLine("Duzgun id daxil edin");
                break;
            }
            brandid = appDbContext.Brands.Find(id);

            Console.WriteLine("Name :");

            name = Console.ReadLine();
            brandid.Name = name;
            appDbContext.SaveChanges();
            break;
        case "6":
            Console.Clear();
            Console.WriteLine("Name :");
            name = Console.ReadLine();

            Console.WriteLine("Price :");
            string priceopt = Console.ReadLine();
            double price;
            if (!double.TryParse(priceopt,out price))
            {
                Console.WriteLine("Duzgun qiymet daxil edin");
                break;
            }

            Console.WriteLine("Date :");
            string dateopt = Console.ReadLine();
            DateTime date;
            if (!DateTime.TryParse(dateopt,out date))
            {
                Console.WriteLine("Duzgun date daxil edin");
                break;
            }

            foreach (var item in appDbContext.Brands.ToList())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("BrandId :");
            idopt = Console.ReadLine();
            if (!int.TryParse(idopt,out id))
            {
                Console.WriteLine("Duzgun brandid daxil edin");
                break;
            }
            Product product = new Product()
            {
                Name = name,
                Price = price,
                Date = date,
                BrandId = id
            };
            appDbContext.Products.Add(product);
            appDbContext.SaveChanges();
            break;
        case "7":
            Console.Clear();
            Console.WriteLine("Id :");
            idopt = Console.ReadLine();
            
            if (!int.TryParse(idopt, out id))
            {
                Console.WriteLine("Duzgun id daxil edin");
                break;
            }
            var findidProducts = appDbContext.Products.Find(id);
            try
            {
                appDbContext.Products.Remove(findidProducts);
            }
            catch
            {

                Console.WriteLine("id tapilmadi");
                break;
            }
            appDbContext.SaveChanges();
            break;
        case "8":
            Console.Clear();
            var productgetall = appDbContext.Products.Include(x=>x.Brand).ToList();
            foreach (var item in productgetall)
            {
                Console.WriteLine(item +" - "+"Brand name: "+item.Brand.Name);
            }
            break;
        case "9":
            Console.Clear();
            Console.WriteLine("Id :");
            idopt = Console.ReadLine();
            if (!int.TryParse(idopt,out id))
            {
                Console.WriteLine("Duzgun id daxil edin");
                break;
            }
            findidProducts = appDbContext.Products.Find(id);
            Console.WriteLine(findidProducts);
            break;
        case "10":
            Console.Clear();
            Console.WriteLine("Id :");
            idopt = Console.ReadLine();
            if (!int.TryParse(idopt, out id))
            {
                Console.WriteLine("Duzgun id daxil edin");
                break;
            }
            findidProducts = appDbContext.Products.Find(id);
            
            Console.WriteLine("Name :");
            name = Console.ReadLine();

            Console.WriteLine("Price :");
            priceopt = Console.ReadLine();
            if (!double.TryParse(priceopt, out price))
            {
                Console.WriteLine("Duzgun qiymet daxil edin");
                break;
            }

            Console.WriteLine("Date :");
            dateopt = Console.ReadLine();
            if (!DateTime.TryParse(dateopt, out date))
            {
                Console.WriteLine("Duzgun date daxil edin");
                break;
            }

            findidProducts.Name = name;
            findidProducts.Price = price;
            findidProducts.Date = date;
            appDbContext.SaveChanges();
            break;
        default:
            Console.WriteLine("Duzgun opt daxil edin");
            break;
    }
} while (opt != "0");