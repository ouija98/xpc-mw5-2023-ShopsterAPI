using projekt.Entities;

namespace projekt.Repositories
{
    public class CommodityRepository : IRepository<CommodityEntity>
    {

        // vytvori nove zbozi
        public Guid Create(CommodityEntity? entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.Id = Guid.NewGuid();
            entity.Rating.Id = Guid.NewGuid();

            Database.Instance.Ratings.Add(entity.Rating);
            Database.Instance.Commodities.Add(entity);


            return entity.Id;

        }

        //vrati specificke zbozi podle id
        public CommodityEntity GetById(Guid id)
        {
            return Database.Instance.Commodities.Single(s => s.Id == id);
        }   

        //modifikuje existujici zbozi
        public CommodityEntity Update(CommodityEntity? entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            var existingCommodity = Database.Instance.Commodities.Single(s => s.Id == entity.Id);
            existingCommodity.Name = entity.Name;
            existingCommodity.Description = entity.Description;
            existingCommodity.Price = entity.Price;
            existingCommodity.Weight = entity.Weight;
            existingCommodity.Quantity = entity.Quantity;
            existingCommodity.Category = entity.Category;
            existingCommodity.Manufacturer = entity.Manufacturer;
            existingCommodity.Rating = entity.Rating;

            return existingCommodity;

        }

        //smaze zbozicko podle id
        public void Delete(Guid id)
        {
            var commodity = Database.Instance.Commodities.Single(s => s.Id == id);
            //Database.Instance.Categories.Remove(commodity.Category);
            //kategorii smazat akorat kdyz uz nebude dalsi zbozi v te kategorii?
            Database.Instance.Ratings.Remove(commodity.Rating);
            Database.Instance.Commodities.Remove(commodity);
        }




    }
}
