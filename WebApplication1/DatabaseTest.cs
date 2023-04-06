using projekt.Entities;
using projekt.Repositories;


namespace projekt;


class Program
{

    public static void Main(string[] args)
    {
        // vytvoreni instanci
        var commodityRepository = new CommodityRepository();


        var categories = new List<CategoryEntity>();
        var Category1 = new CategoryEntity()
        {
            Title = "emka"
        };
        var Category2 = new CategoryEntity()
        {
            Title = "kategorieX"
        };
        categories.Add(Category1);
        categories.Add(Category2);

        var manufacturers = new List<ManufacturerEntity>();
        var Manufacturer1 = new ManufacturerEntity()
        {
            Name = "Manu1",
            Description = "Manu..1 desc",
            Logo = "adresa_loga1",
            CountryOfOrigin = "CZ",
            //Commodities = Database.Instance.Commodities
        };
        var Manufacturer2 = new ManufacturerEntity()
        {
            Name = "Manu2",
            Description = "Manu..2 desc",
            Logo = "adresa_loga2",
            CountryOfOrigin = "CZ",
            //Commodities = Database.Instance.Commodities
        };
        manufacturers.Add(Manufacturer1);
        manufacturers.Add(Manufacturer2);

        var artikl1 = commodityRepository.Create(new CommodityEntity()
        {
            Name = "zbozicko",
            Picture = "adresa_obrazku1",
            Description = "jak z lacinky",
            Price = 10,
            Weight = 5,
            Quantity = 10,
            Category = categories[0],
            Manufacturer = manufacturers[0],
            Rating = new RatingEntity()
            {
                Stars = "*****",
                Title = "hodnoceni2",
                Description = "dobre to je taky"
            }
        }) ;

        var artikl2 = commodityRepository.Create(new CommodityEntity()
        {
            Name = "dalsi zbozicko",
            Picture = "adresa_obrazku2",
            Description = "uplne z lacinky",
            Price = 103432,
            Weight = 23,
            Quantity = 100,
            Category = categories[0],
            Manufacturer = manufacturers[1],
            Rating = new RatingEntity()
            {
                Stars = "****",
                Title = "hodnoceni3",
                Description = "dobre to je"
            }
        });

    var artikl3 = commodityRepository.Create(new CommodityEntity()
        {
            Name = "zbozicko3",
            Picture = "adresa_obrazku3",
            Description = "jak z lacinky taky",
            Price = 103,
            Weight = 52,
            Quantity = 10,
            Category = categories[1],
            Manufacturer = manufacturers[0],
            Rating = new RatingEntity()
            {
                Stars = "***",
                Title = "hodnoceni",
                Description = "dobre to je"
            }
    });

        // vypis na konzoli

        Database.Instance.ShowData();

        // Get zbozicko by Id
        Console.WriteLine("\nOPERATION: commodityRepository.GetById(id1)");
        var zbozicko1 = commodityRepository.GetById(artikl1);
        Console.WriteLine(zbozicko1);


        // update zbozicko
        Console.WriteLine("\nOPERATION: commodityRepository.Update(zbozicko1 with { Description = '2 roky prosle' })");
        commodityRepository.Update(zbozicko1 with { Description = "2 roky prosle" });
        Console.WriteLine(commodityRepository.GetById(artikl1));

        // update zbozicko
        Console.WriteLine("\nOPERATION: commodityRepository.Update(zbozicko1 with { Manufacturer = manufacturers[1]  })");
        commodityRepository.Update(zbozicko1 with { Manufacturer = manufacturers[1] });
        Console.WriteLine(commodityRepository.GetById(artikl1));


        //maze zbozicko
        Console.WriteLine("\nOPERATION: commodityRepository.Delete(artikl2)");
        commodityRepository.Delete(artikl2);

        Database.Instance.ShowData();



    }
}




