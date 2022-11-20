using AlquilerBD;
using AlquilerBD.Data.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlquilerTodo2Pesos.Server.Controllers
{
    [Route("api/Categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly BdContext context;

        public CategoriaController(BdContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get()
        {

            return await context.Categorias

                                       .Include(m => m.ProductosPublicados)
                                       .ToListAsync();


        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            var estado = await context.Categorias

                .Where(e => e.Id == id)
                .Include(m => m.ProductosPublicados)
               .FirstOrDefaultAsync();


            if (estado == null)

            {
                return NotFound($"No existe la Foto de Id= {id}");

            }

            return estado;

        }


        [HttpPost]
        public async Task<ActionResult<List<Categoria>>> Post(Categoria categoria)
        {
            try
            {

                context.Categorias.Add(categoria);
                await context.SaveChangesAsync();
                return Ok(categoria);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Categoria Categ)
        {


            if (id != Categ.Id)
            {
                return BadRequest("No existe el producto");
            }

            var est = context.Categorias.Where(e => e.Id == id).FirstOrDefault();
            var produ = context.ProductosPublicados.Where(e => e.Id == id).FirstOrDefault();


            if (est == null)
            {
                return NotFound("No existe el producto");
            }

            est.NombCategoria = Categ.NombCategoria;



            try
            {
                //throw(new Exception(""));
                context.Categorias.Update(est);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no han sido actualizados por: {e.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var est = context.Categorias.Where(x => x.Id == id).FirstOrDefault();

            if (est == null)
            {
                return NotFound($"El registro {id} no fue encontrado");
            }

            try
            {
                context.Categorias.Remove(est);
                context.SaveChanges();
                return Ok($"El registro de {est.NombCategoria} ha sido borrado.");
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no pudieron eliminarse por: {e.Message}");
            }

        }
    }
    }
