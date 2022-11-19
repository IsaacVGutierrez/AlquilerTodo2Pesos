using AlquilerBD;
using AlquilerBD.Data.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlquilerTodo2Pesos.Server.Controllers
{
    [Route("api/ProductoPublicado")]
    [ApiController]
    public class ProductoPublicadoController : ControllerBase
    {

        private readonly BdContext context;

        public ProductoPublicadoController(BdContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public async Task<ActionResult<List<ProductoPublicado>>> Post(ProductoPublicado producto)
        {
            try
            {

                context.ProductsoPublicados.Add(producto);
                await context.SaveChangesAsync();
                return Ok(producto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
