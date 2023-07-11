using App.InputModel.Produto;
using App.ViewModel.Produto;
using AutoMapper;
using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<ProdutoInputModel, Produto>();
            
        }

    }
}
