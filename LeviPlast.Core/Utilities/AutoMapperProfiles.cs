using AutoMapper;
using LeviPlast.Core.DTOs;
using LeviPlast.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeviPlast.Core.Utilities
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Usuario,UsuarioResponseDTO>();
            CreateMap<UsuarioResponseDTO,Usuario>();
        }
    }
}
