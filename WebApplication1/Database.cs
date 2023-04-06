using projekt.Entities;

namespace projekt;

public class Database
{
    private static readonly Lazy<Database> LazyDatabase =
        new Lazy<Database>(() => new Database());
    
    public static Database Instance => LazyDatabase.Value;

    private Database()
    {
    }
    
    public ICollection<CommodityEntity> Commodities { get; } = new List<CommodityEntity>();
    public ICollection<CategoryEntity> Categories { get; } = new List<CategoryEntity>();
    public ICollection<ManufacturerEntity> Manufacturers { get; } = new List<ManufacturerEntity>();
    public ICollection<RatingEntity> Ratings { get; } = new List<RatingEntity>();

    public void ShowData()
    {
        Console.WriteLine("--------------------------");
        
        Console.WriteLine("# Zbozi:");
        foreach (var c in Commodities)
        {
            Console.WriteLine(c);
        }
        
        Console.WriteLine("# Categories:");
        foreach (var c in Categories)
        {
            Console.WriteLine(c);
        }
        
        Console.WriteLine("# Manufacturers:");
        foreach (var e in Manufacturers)
        {
            Console.WriteLine(e);
        }
        
        Console.WriteLine("# Ratings:");
        foreach (var s in Ratings)
        {
            Console.WriteLine(s);
        }
        
        Console.WriteLine("--------------------------");
    }
}