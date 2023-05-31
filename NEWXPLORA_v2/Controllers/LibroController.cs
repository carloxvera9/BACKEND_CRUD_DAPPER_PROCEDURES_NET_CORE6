using Dominio.Entidad.Entity;
using Dominio.Interface.Interface;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NEWXPLORA_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        // Me dara acceso al repositorio
        private readonly IUnitOfWork _unitOfWork;
        public LibroController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("lista/")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _unitOfWork.Libros.ListTodoAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _unitOfWork.Libros.ListaByIdAsycn(id);
          
            return Ok(data);
        }

        [HttpPost("inserta/")]
        public async Task<IActionResult> Add(Libros libros)
        {
            var data = await _unitOfWork.Libros.NewLibroAsync(libros);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _unitOfWork.Libros.DeleteLibroAsycn(id);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Libros libros)
        {
            var data = await _unitOfWork.Libros.ActualizarLibroAsycn(libros);
            return Ok(data);
        }
    }
}
