using LeviPlast.Core.DTOs;
using LeviPlast.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeviPlast.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> Get();
        Task<UsuarioResponseDTO> GetId(int id);
    }
}
