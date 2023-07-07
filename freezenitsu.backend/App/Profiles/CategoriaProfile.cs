using App.InputModel.Categoria;
using App.ViewModel.Categoria;
using AutoMapper;
using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<CategoriaInputModel, Categoria>();
            CreateMap<Categoria, CategoriaViewModel>();
        
        }

    }
}
