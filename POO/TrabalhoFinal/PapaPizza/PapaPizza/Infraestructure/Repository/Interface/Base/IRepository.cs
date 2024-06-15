using PapaPizza.Infraestructure.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaPizza.Infraestructure.Repository.Interface.Base
{
    public interface IRepository<TEntity> : IDisposable where TEntity : EntityBase
    {
        IEnumerable<TEntity> FindAll();

        TEntity? FindByName(string name);

        TEntity? FindById(Guid id);

        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        bool Delete(string nome);

        bool Delete(Guid id);

        bool Exists(Guid id);
        TEntity? Parse(string objectString);
        string Parse(TEntity objectToParse);
    }
}
