using System.Linq.Expressions;
using Tecnofactory.Alimentos.DAL.Entity;

namespace Tecnofactory.Alimentos.DAL.Repository.Interface
{
    public interface ICatalogueRepository
    {
        Guid Create(Catalogue catalogue);
        List<Catalogue> Get();
        List<Catalogue> Get(Expression<Func<Catalogue, bool>> predicate);
        Catalogue GetById(Guid id);
        void Update(Catalogue catalogue);
        void Delete(Catalogue catalogue);
    }
}
