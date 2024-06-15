using PapaPizza.Infraestructure.Entity.Base;
using PapaPizza.Infraestructure.Repository.Interface.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaPizza.Infraestructure.Repository.Implementation.Base
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
    {
        private readonly string _basePath = "PapaPizza.Resources.{0}.csv";

        private string _path = string.Empty;

        private string _classe;

        protected Repository()
        {
            TEntity aux = new TEntity();
            _classe = aux.GetType().Name;
            _path = string.Format(_basePath, _classe.Replace("Entity",""));
        }

        public virtual TEntity Create(TEntity entity)
        {
            string parsedEntity = Parse(entity);

            using (StreamWriter dataBase = new StreamWriter(_path))
            {
                dataBase.WriteLine(parsedEntity);
            }

            return entity;
        }

        public virtual bool Delete(string name)
        {
            string[] data = File.ReadAllLines(_path);
            List<string> updatedData = new List<string>();
            bool deleted = false;

            foreach (string line in data)
            {
                if (!line.Contains(name))
                {
                    updatedData.Add(line);
                }
                else
                {
                    deleted = true;
                }
            }

            File.WriteAllLines(_path, updatedData);

            return deleted;
        }

        public virtual bool Delete(Guid id)
        {
            string[] data = File.ReadAllLines(_path);
            List<string> updatedData = new List<string>();
            bool deleted = false;

            foreach (string line in data)
            {
                if (!line.Contains(id.ToString()))
                {
                    updatedData.Add(line);
                }
                else
                {
                    deleted = true;
                }
            }

            File.WriteAllLines(_path, updatedData);

            return deleted;
        }

        public void Dispose()
        {
            
        }

        public virtual bool Exists(Guid id)
        {
            string[] data = File.ReadAllLines(_path);

            bool exist = false;

            foreach (string line in data)
            {
                if (line.Contains(id.ToString()))
                {
                    exist = true;
                }
            }

            return exist;
        }

        public virtual IEnumerable<TEntity> FindAll()
        {
            List<TEntity> entities = new List<TEntity>();

            string[] data = File.ReadAllLines(_path);

            foreach (string line in data)
            {
                entities.Add(Parse(line));
            }

            return entities;
        }

        public virtual TEntity? FindByName(string name)
        {
            string[] data = File.ReadAllLines(_path);

            foreach (string line in data)
            {
                if (line.Contains(name))
                {
                    return Parse(line);
                }
            }

            return null;
        }

        public virtual TEntity? FindById(Guid id)
        {
            string[] data = File.ReadAllLines(_path);

            foreach (string line in data)
            {
                if (line.Contains(id.ToString()))
                {
                    return Parse(line);
                }
            }

            return null;
        }

        public virtual TEntity Update(TEntity entity)
        {
            string[] data = File.ReadAllLines(_path);
            List<string> updatedData = new List<string>();

            foreach (string line in data)
            {
                if (line.Contains(entity.Id.ToString()))
                {
                    updatedData.Add(Parse(entity));
                }
                else
                {
                    updatedData.Add(line);
                }
            }

            return entity;
        }

        public abstract TEntity? Parse(string objectString);

        public abstract string Parse(TEntity objectToParse);
    }
}
