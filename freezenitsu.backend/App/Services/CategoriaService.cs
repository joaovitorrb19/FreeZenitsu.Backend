using App.InputModel.Categoria;
using App.Services.Interfaces;
using App.ViewModel.Categoria;
using AutoMapper;
using Core.Entidades;
using Core.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;
        private readonly IMapper _mapper;
        public CategoriaService(ICategoriaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Create(CategoriaInputModel categoria)
        {
            var categoriaMapeada = _mapper.Map<Categoria>(categoria);

            if (_repository.GetByName(categoriaMapeada.Nome) != null)
                throw new Exception("Categoria já cadastrada");

            _repository.Create(categoriaMapeada);
        }

        public void Delete(CategoriaInputModel categoria)
        {
            var categoriaMapeada = _mapper.Map<Categoria>(categoria);

            _repository.Delete(categoriaMapeada);
        }

        public List<CategoriaViewModel> Get()
        {
            var listasMapeadas = _mapper.Map<List<CategoriaViewModel>>(_repository.Get());
            return listasMapeadas;
        }

        public CategoriaViewModel Get(int id)
        {
           var categoriaNaoMapeada = _repository.GetById(id);

             if(categoriaNaoMapeada == null)
               throw new Exception("Categoria não existente");

           var categoriaMapeada = _mapper.Map<CategoriaViewModel>(categoriaNaoMapeada);

           return categoriaMapeada;
        }

        public CategoriaViewModel Get(string nome)
        {
            var categoriaNaoMapeada = _repository.GetByName(nome);

            if (categoriaNaoMapeada == null)
                throw new Exception("Categoria");

            var categoriaMapeada = _mapper.Map<CategoriaViewModel>(categoriaNaoMapeada);

            return categoriaMapeada;
        }

        public void Put(CategoriaInputModel categoria)
        {
            var categoriaMapeada = _mapper.Map<Categoria>(categoria);

            _repository.Put(categoriaMapeada);
        }
    }
}
