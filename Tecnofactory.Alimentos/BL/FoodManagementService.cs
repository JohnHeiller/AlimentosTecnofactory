using AutoMapper;
using Tecnofactory.Alimentos.BL.Interface;
using Tecnofactory.Alimentos.DAL.Entity;
using Tecnofactory.Alimentos.DAL.Repository.Interface;
using Tecnofactory.Alimentos.DTO;

namespace Tecnofactory.Alimentos.BL
{
    public class FoodManagementService : IFoodManagementService
    {
        private readonly ICatalogueRepository _catalogueRepository;
        private readonly IMapper _mapper;
        public FoodManagementService(ICatalogueRepository catalogueRepository, IMapper mapper)
        {
            _catalogueRepository = catalogueRepository;
            _mapper = mapper;
        }

        public List<Guid> AddElementCatalogue(List<FoodDto> foods)
        {
            List<Guid> guids = new();
            List<Catalogue> catalogues = _mapper.Map<List<Catalogue>>(foods);
            foreach (Catalogue catalogue in catalogues)
            {
                guids.Add(_catalogueRepository.Create(catalogue));
            }
            return guids;
        }

        public Guid UpdateElementCatalogue(FoodDto food)
        {
            Catalogue catalogue = _mapper.Map<Catalogue>(food);
            _catalogueRepository.Update(catalogue);
            return catalogue.Id;
        }

        public Guid DeleteElementCatalogue(FoodDto food)
        {
            Catalogue catalogue = _mapper.Map<Catalogue>(food);
            _catalogueRepository.Delete(catalogue);
            return catalogue.Id;
        }

        public List<FoodDto> GetAllAvailableElementCatalogue()
        {
            List<Catalogue> catalogues = _catalogueRepository.Get(x => x.Quantity > 0);
            return _mapper.Map<List<FoodDto>>(catalogues);
        }
    }
}
