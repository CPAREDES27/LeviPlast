using LeviPlast.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeviPlast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        
        [HttpGet("ObtenerUsuarios")]
        public async Task<ActionResult> GetUsuarios()
        {
            var resultado = await _usuarioRepository.Get();
            return Ok(resultado);
        }

        [HttpGet("ObtenerUsuarioId/{id:int}")]
        public async Task<ActionResult> GetUsuario(int id)
        {
            var resultado = await _usuarioRepository.GetId(id);
            if(resultado == null)
            {
                return NotFound();
            }
            return Ok(resultado);
        }


    }
}
