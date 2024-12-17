using chaincue_real_estate_aspnet.Models;

namespace chaincue_real_estate_aspnet.Services.DTOBuilderHelpers
{
    public class HouseHelper
    {
        private readonly HouseService _houseService;

        public HouseHelper(HouseService houseService)
        {
            _houseService = houseService;
        }

        public Func<B, B> UpdateDTOBuilderWithHouseByHouse<B>(Func<B, House> getHouse, Action<B, House> setHouse)
        {
            return dtoBuilder =>
            {
                var house = _houseService.FindById(getHouse(dtoBuilder).Id.ToString());
                setHouse(dtoBuilder, house);
                return dtoBuilder;
            };
        }

        public Func<B, B> UpdateDTOBuilderWithHouses<B>(Action<B, List<House>> setHouses)
        {
            return dtoBuilder =>
            {
                var houses = _houseService.FindAll();
                setHouses(dtoBuilder, houses);
                return dtoBuilder;
            };
        }

        public Func<B, B> UpdateDTOBuilderWithHouseByHouseId<B>(string houseId, Action<B, House> setHouse)
        {
            return dtoBuilder =>
            {
                var house = _houseService.FindById(houseId);
                setHouse(dtoBuilder, house);
                return dtoBuilder;
            };
        }
    }
}
