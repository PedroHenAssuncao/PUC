using PapaPizza.Infraestructure.Entity;
using PapaPizza.Infraestructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaPizza.Presentation
{
    public class IngredientCRUD
    {
        private IIngredientRepository _repository;

        public IngredientCRUD(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public void listAll()
        {
            Console.Write("\n\t+-----------------------+");
            Console.Write("\n\t| Exibindo Ingredientes |");
            Console.Write("\n\t+-----------------------+");

            var ingredientes = _repository.FindAll();

            foreach (var item in ingredientes)
            {
                Console.WriteLine(_repository.Parse(item));
            }
        }

        public void delete()
        {
            bool empty = true;


            empty = !_repository.FindAll().Any();

            if (!empty)
            {
                listAll();

                Console.Write("\n\t+-------------------------------------------+");
                Console.Write("\n\t| Digite o nome do ingrediente para excluir |");
                Console.Write("\n\t+-------------------------------------------+");
                Console.Write("-> ");
                string nome = Console.ReadLine();

                _repository.Delete(nome);
            }
            else
            {
                Console.Write("\n\t+---------------------+");
                Console.Write("\n\t| Não há ingredientes |");
                Console.Write("\n\t+---------------------+");
            }
        }

        public void create()
        {
            Console.Write("\n\t+--------------------------------------+");
            Console.Write("\n\t| Digite as informações do ingrediente |");
            Console.Write("\n\t+--------------------------------------+");

            IngredientEntity novoIngrediente = new IngredientEntity();

            var fields = novoIngrediente.GetType().GetFields();
            List<string> values = new List<string>();

            for (int i = 1; i < fields.Length; i++)
            {
                Console.WriteLine($"Digite o {fields[i].Name}");
                Console.Write("-> ");
                values.Add(Console.ReadLine());
            }

            try
            {
                novoIngrediente = _repository.Parse(novoIngrediente.Id.ToString() + ";" + string.Join(';', values));

                _repository.Create(novoIngrediente);
            }
            catch (Exception ex)
            {
                Console.Write("\n\t+---------------------------------------+");
                Console.Write("\n\t| Houve um erro ao salvar o ingrediente |");
                Console.Write("\n\t+---------------------------------------+");
            }
        }
    }
}
