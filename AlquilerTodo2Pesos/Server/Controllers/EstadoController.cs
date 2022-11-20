using AlquilerBD;
using AlquilerBD.Data.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlquilerTodo2Pesos.Server.Controllers
{
    [Route("api/Estado")]
    [ApiController]
    public class EstadoController : ControllerBase
    {

        private readonly BdContext context;

        public EstadoController(BdContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Estado>>> Get()
        {

            return await context.Estados

                                       .Include(m => m.ProductosPublicados)
                                       .ToListAsync();


        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Estado>> Get(int id)
        {
            var estado = await context.Estados

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
        public async Task<ActionResult<List<Estado>>> Post(Estado estado)
        {
            try
            {

                context.Estados.Add(estado);
                await context.SaveChangesAsync();
                return Ok(estado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Estado Estad)
        {


            if (id != Estad.Id)
            {
                return BadRequest("No existe el Estado");
            }

            var est = context.Estados.Where(e => e.Id == id).FirstOrDefault();
            var produ = context.ProductosPublicados.Where(e => e.Id == id).FirstOrDefault();


            if (est == null)
            {
                return NotFound("No existe el Estado");
            }

            est.Estados = Estad.Estados;



            try
            {
                //throw(new Exception(""));
                context.Estados.Update(est);
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
            var est = context.Estados.Where(x => x.Id == id).FirstOrDefault();

            if (est == null)
            {
                return NotFound($"El registro {id} no fue encontrado");
            }

            try
            {
                context.Estados.Remove(est);
                context.SaveChanges();
                return Ok($"El registro de {est.Estados} ha sido borrado.");
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no pudieron eliminarse por: {e.Message}");
            }

        }
    }
    }
