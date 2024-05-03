using Tecnofactory.Alimentos.DTO;

namespace Tecnofactory.Alimentos.BL.Interface
{
    public interface IFoodManagementService
    {
        List<Guid> AddElementCatalogue(List<FoodDto> foods);
        Guid UpdateElementCatalogue(FoodDto food);
        Guid DeleteElementCatalogue(FoodDto food);
        List<FoodDto> GetAllAvailableElementCatalogue();
    }
}
