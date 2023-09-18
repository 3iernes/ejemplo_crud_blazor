using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBlazorDocsLP.Server.Data;
using WebBlazorDocsLP.Shared;

namespace WebBlazorDocsLP.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemaController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public SistemaController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<SistemasDists>>> GetSistemas()
        {

            var sistemas = await _dataContext.Sistemas.ToListAsync();

            return Ok(sistemas);
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<List<SistemasDists>>> GetSistema(int id)
		{

			var sistema = await _dataContext.Sistemas.FindAsync(id);

            if(sistema == null)
                return BadRequest("No se encontró el sistema");

			return Ok(sistema);
		}

		[HttpPost]
        public async Task<ActionResult<List<SistemasDists>>> CrearSistema(SistemasDists sistema)
        {
            _dataContext.Add(sistema);
            await _dataContext.SaveChangesAsync();

            return await GetSistemas();
        }

		[HttpPut("{id}")]
		public async Task<ActionResult<List<SistemasDists>>> ModSistema(int Id,SistemasDists SistemaEditar)
		{
            var sistema = await _dataContext.Sistemas.FindAsync(Id);
            if (sistema is null)
                return BadRequest("No se encontro el sistema que quiere editar");

            sistema.Nombre = SistemaEditar.Nombre;

            await _dataContext.SaveChangesAsync();

			return await GetSistemas();
		}

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarSistema(int Id)
        {
			var sistema = await _dataContext.Sistemas.FindAsync(Id);
			if (sistema is null)
				return BadRequest("No se encontro el sistema que quiere eliminar");

            _dataContext.Sistemas.Remove(sistema);
            await _dataContext.SaveChangesAsync();

            return Ok("Sistema eliminado con exito :'(");
		}
	}
}
