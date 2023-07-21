using App.InputModel.Usuario;
using AutoMapper;
using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioCadastroInputModel, Usuario>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(src => src.Email) );
                
        }
    }
}
