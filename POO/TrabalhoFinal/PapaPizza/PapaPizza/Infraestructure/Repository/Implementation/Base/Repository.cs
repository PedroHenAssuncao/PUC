using PapaPizza.Infraestructure.Entity.Base;
using PapaPizza.Infraestructure.Repository.Interface.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PapaPizza.Infraestructure.Repository.Implementation.Base
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
    {
        private readonly string _basePath = "..\\..\\..\\Resources\\{0}.csv";

        private string _path = string.Empty;

        private string _classe;

        protected Repository()
        {
            TEntity aux = new TEntity();
            _classe = aux.GetType().Name;
            _path = string.Format( _basePath, _classe.Replace("Entity", "")) ;
        }

        public virtual TEntity Create(TEntity entity)
        {
            string parsedEntity = Parse(entity);

            using (StreamWriter dataBase = new StreamWriter(_path))
            {
                dataBase.WriteLine(parsedEntity);
                dataBase.Close();
            }

            return entity;
        }

        public virtual bool Delete(string name)
        {
            string[] data = readFromAssembly();
            List<string> updatedData = new List<string>();
            bool deleted = false;

            foreach (string line in data)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    var aux = line.Split(";");
                    if (!(aux[0].ToLower() == name.ToLower()))
                    {
                        updatedData.Add(line);
                    }
                    else
                    {
                        deleted = true;
                    }
                }
            }

            clearAllDataFromAssembly();
            writeInAssembly(updatedData);

            return deleted;
        }

        public virtual bool Delete(Guid id)
        {
            string[] data = readFromAssembly();
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

            clearAllDataFromAssembly();
            writeInAssembly(updatedData);

            return deleted;
        }

        public void Dispose()
        {
            
        }

        public virtual IEnumerable<TEntity> FindAll()
        {
            List<TEntity> entities = new List<TEntity>();

            string[] data = readFromAssembly();

            foreach (string line in data)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    entities.Add(Parse(line));
                }
            }

            return entities;
        }

        public virtual TEntity? FindByName(string name)
        {
            string[] data = readFromAssembly();

            foreach (string line in data)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    var aux = line.Split(";");

                    if (aux[0].ToLower() == name.ToLower())
                    {
                        return Parse(line);
                    }
                }
            }

            return null;
        }

        public virtual TEntity? FindById(Guid id)
        {
            string[] data = readFromAssembly();

            foreach (string line in data)
            {
                if (line.Contains(id.ToString()))
                {
                    return Parse(line);
                }
            }

            return null;
        }

        private string[] readFromAssembly()
        {
            string[] data = null;

            using (StreamReader reader = new StreamReader(_path))
            {
                data = reader.ReadToEnd().Trim().Split("\n");
                reader.Close();
            }

            return data;
        }

        private void clearAllDataFromAssembly()
        {
            using (StreamWriter stream = new StreamWriter(_path, false))
                stream.Write("");
                    
        }

        private void writeInAssembly(List<string> data)
        {

            using (StreamWriter writer = new StreamWriter(_path))
            {
                
                writer.WriteLine(string.Join(';', data));
                writer.Close();
            }
        }

        public abstract TEntity? Parse(string objectString);

        public abstract string Parse(TEntity objectToParse);
    }
}
