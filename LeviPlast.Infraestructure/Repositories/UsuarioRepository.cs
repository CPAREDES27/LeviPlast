using AutoMapper;
using LeviPlast.Core.DTOs;
using LeviPlast.Core.Entities;
using LeviPlast.Core.Interfaces;
using LeviPlast.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeviPlast.Infraestructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UsuarioRepository(ApplicationDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Usuario>> Get()
        {
            var result = await _context.Usuario.ToListAsync();
            return result;
        }

        public async Task<UsuarioResponseDTO> GetId(int id)
        {
            var result = await _context.Usuario.FindAsync(id);

            var dtoUser = _mapper.Map<UsuarioResponseDTO>(result);
            
            return dtoUser;
        }
    }
}
