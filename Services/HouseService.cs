using chaincue_real_estate_aspnet.Data;
using chaincue_real_estate_aspnet.Exceptions;
using chaincue_real_estate_aspnet.Models;
using chaincue_real_estate_aspnet.Utilities;
using Microsoft.EntityFrameworkCore;

namespace chaincue_real_estate_aspnet.Services
{
    public class HouseService: HouseServiceI
    {
        private readonly ApplicationDbContext _dbContext;
        public HouseService(ApplicationDbContext dbContext) { 
            this._dbContext = dbContext;
        }

        public House Save(House.HouseTypesEnum houseTypes)
        {
            var houseImage = House.Create(houseTypes, AweS3Urls.URLFrontImage1);
            _dbContext.Houses.Add(houseImage);
            _dbContext.SaveChanges();
            return houseImage;
        }

        public House FindById(String id)
        {
            var house = _dbContext.Houses
                .Include(h => h.Broker)
                .Include(h => h.Images)
                .FirstOrDefault(h => h.Id == Guid.Parse(id));
            if (house == null)
            {
                throw new HouseNotFoundException(id.ToString());
            }
            return house;
        }

        public List<House> FindAll()
        {
            return _dbContext.Houses.ToList();
        }
    }
}
