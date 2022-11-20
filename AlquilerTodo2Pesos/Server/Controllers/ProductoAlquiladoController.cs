using AlquilerBD;
using AlquilerBD.Data.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlquilerTodo2Pesos.Server.Controllers
{
    [Route("api/ProductosAlquilados")]
    [ApiController]
    public class ProductoAlquiladoController : ControllerBase
    {
        private readonly BdContext context;

        public ProductoAlquiladoController(BdContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<ProductoAlquilado>>> Get()
        {
            return await context.ProductosAlquilados


                                         .Include(m => m.Estado)
                                          .Include(m => m.Persona)
                                             .ToListAsync();

          
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductoAlquilado>> Get(int id)
        {
            var venta = await context.ProductosAlquilados
                                         .Where(e => e.Id == id)
                                         
                                         .Include(m => m.Estado)
                                          .Include(m => m.Persona)
                                         .FirstOrDefaultAsync();

            if (venta == null)
            {
                return NotFound($"No existe Producto de id: {id}");
            }
            return venta;
        }


        [HttpPost]
        public async Task<ActionResult<List<ProductoAlquilado>>> Post(ProductoAlquilado producto)
        {
            try
            {

                context.ProductosAlquilados.Add(producto);
                await context.SaveChangesAsync();
                return Ok(producto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] ProductoAlquilado producto)
        {


            if (id != producto.Id)
            {
                return BadRequest("No existe el Producto");
            }

            var produ = context.ProductosAlquilados.Where(e => e.Id == id).FirstOrDefault();
           
            

            if (produ == null)
            {
                return NotFound("No existe el Producto");
            }

            produ.NombreProducto = producto.NombreProducto;
            produ.PrecioProducto = producto.PrecioProducto;
            produ.DetallesProducto = producto.DetallesProducto;
            produ.foto = producto.foto;
            produ.EstadoId = producto.EstadoId;

            try
            {
                //throw(new Exception("Cualquier Verdura"));
                context.ProductosAlquilados.Update(produ);
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
            var produ = context.ProductosAlquilados.Where(x => x.Id == id).FirstOrDefault();

            if (produ == null)
            {
                return NotFound($"El registro {id} no fue encontrado");
            }

            try
            {
                context.ProductosAlquilados.Remove(produ);
                context.SaveChanges();
                return Ok($"El registro de {produ.NombreProducto} ha sido borrado.");
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no pudieron eliminarse por: {e.Message}");
            }
        }
    }
}