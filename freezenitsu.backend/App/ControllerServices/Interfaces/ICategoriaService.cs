using App.InputModel.Categoria;
using App.ViewModel.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Interfaces
{
    public interface ICategoriaService
    {
        public void Create(CategoriaInputModel categoria);
        public List<CategoriaViewModel> Get();
        public CategoriaViewModel Get(int id);
        public CategoriaViewModel Get(string nome);
        public void Delete(CategoriaInputModel categoria);
        public void Put(CategoriaInputModel categoria);

    }
}
