using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiComputadoras.Entitys;


namespace WebApiComputadoras.Controllers
{
    [ApiController]
    [Route("api/complementos")]
    public class ComplementosController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public ComplementosController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet("lista")]
        public async Task<ActionResult<List<Complementos>>> GetAll()
        {
            return await dbContext.Complementos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Complementos>> GetById(int id)
        {
            return await dbContext.Complementos.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Complementos complementos)
        {
            dbContext.Add(complementos);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Complementos complementos, int id)
        {
            var exist = await dbContext.Complementos.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("El complemento especificado no existe. ");
            }

            if (complementos.Id != id)
            {
                return BadRequest("El ID del complemento no coincide con el establecido en la URL. ");
            }

            dbContext.Update(complementos);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Complementos.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El recurso no fue encontrado. ");
            }

            dbContext.Remove(new Complementos { Id = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
