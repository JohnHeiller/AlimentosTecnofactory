using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tecnofactory.Alimentos.DAL.Entity;
using Tecnofactory.Alimentos.DAL.Repository.Interface;

namespace Tecnofactory.Alimentos.DAL.Repository
{
    public class CatalogueRepository : ICatalogueRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CatalogueRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Guid Create(Catalogue catalogue)
        {
            _dbContext.Catalogues.Add(catalogue);
            _dbContext.SaveChanges();
            return catalogue.Id;
        }

        public List<Catalogue> Get()
        {
            return _dbContext.Catalogues
                .AsNoTracking()
                .ToList();
        }

        public List<Catalogue> Get(Expression<Func<Catalogue, bool>> predicate)
        {
            return _dbContext.Catalogues
                .Where(predicate)
                .AsNoTracking()
                .ToList();
        }

        public Catalogue GetById(Guid id)
        {
            return _dbContext.Catalogues
                .Where(x => x.Id == id)
                .FirstOrDefault()!;
        }

        public void Update(Catalogue catalogue)
        {
            _dbContext.Entry(catalogue).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(Catalogue catalogue)
        {
            _dbContext.Catalogues.Remove(catalogue);
            _dbContext.SaveChanges();
        }
    }
}
