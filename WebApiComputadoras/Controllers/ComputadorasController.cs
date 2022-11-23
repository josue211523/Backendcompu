using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiComputadoras.DTOs;
using WebApiComputadoras.Entitys;
using WebApiComputadoras.Services;

namespace WebApiComputadoras.Controllers
{
    [ApiController]
    [Route("api/computadoras")]
    public class ComputadorasController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> userManager;

        public ComputadorasController(ApplicationDbContext context, IMapper mapper)
        {
            this.dbContext = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetComputadorasDTO>>> Get()
        {
            var compus = await dbContext.Computadoras.ToListAsync();
            return mapper.Map<List<GetComputadorasDTO>>(compus);
        }


        [HttpGet("{id:int}")] 
        public async Task<ActionResult<GetComputadorasDTO>> Get(int id)
        {
            var compu = await dbContext.Computadoras.FirstOrDefaultAsync(compuBD => compuBD.Id == id);

            if (compu == null)
            {
                return NotFound();
            }

            return mapper.Map<GetComputadorasDTO>(compu);

        }

        [HttpGet("{marca}")]
        public async Task<ActionResult<List<GetComputadorasDTO>>> Get([FromRoute] string marca)
        {
            var compu = await dbContext.Computadoras.Where(alumnoBD => alumnoBD.Marca.Contains(marca)).ToListAsync();

            EscribirArchivos ea = new EscribirArchivos();
            foreach(var computadoras in compu)
            {
                ea.DoWork_Get(computadoras.Marca);
            }

            return mapper.Map<List<GetComputadorasDTO>>(compu);

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] ComputadorasDTO compuDto)
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();

            var email = emailClaim.Value;

            var usuario = await userManager.FindByEmailAsync(email);
            var usuarioId = usuario.Id;

            var existe = await dbContext.Computadoras.AnyAsync(x => x.Marca == compuDto.Marca);

            if (existe)
            {
                return BadRequest("Empresa existente");
            }

            var computadora = mapper.Map<Computadoras>(compuDto);
            dbContext.Add(computadora);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Computadoras compu, int id)
        {
            var exist = await dbContext.Computadoras.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }

            if (compu.Id != id)
            {
                return BadRequest("El id de la computadora no coincide con el establecido en la url.");
            }

            dbContext.Update(compu);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Computadoras.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El Recurso no fue encontrado.");
            }

            dbContext.Remove(new Computadoras()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
