using chaincue_real_estate_aspnet.Models;

namespace chaincue_real_estate_aspnet.Services
{
    public interface HouseServiceI
    {
        House Save(House.HouseTypesEnum houseTypes);
        House FindById(string id);
        List<House> FindAll();
    }
}
