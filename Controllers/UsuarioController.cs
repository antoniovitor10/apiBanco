using Microsoft.AspNetCore.Mvc;

namespace apiBanco.Controllers;

[ApiController]
[Route("[controller]")]
 public class UsuarioController : ControllerBase
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        [HttpPost]
        public IActionResult PostUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { cpf = usuario.cpf }, usuario);
        }

        [HttpGet("{cpf}")]
        public IActionResult GetUsuario(int cpf)
        {
            var usuario = usuarios.FirstOrDefault(u => u.cpf == cpf);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }
    }
