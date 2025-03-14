using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.DB;
using PruebaTecnica.Dtos;
using PruebaTecnica.Entities;

namespace PruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/stores")]
    [Authorize]
    public class StoreController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public StoreController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<StoreDto>> Get()
        {
            var stores = await context.Stores.ToListAsync();
            var storesDTO = mapper.Map<IEnumerable<StoreDto>>(stores);
            return storesDTO;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StoreDto>> Get(int id)
        {
            var store = await context.Stores.FirstOrDefaultAsync(x => x.Id == id);
            if (store is null)
            {
                return NotFound();
            }
            var storeDTO = mapper.Map<StoreDto>(store);
            return storeDTO;
        }

        [HttpPost]
        public async Task<ActionResult<Store>> Post(Store store)
        {
            context.Add(store);
            await context.SaveChangesAsync();
            return Ok(store);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Store>> Put(int id, Store store)
        {
            if (id != store.Id)
            {
                return BadRequest("Los Ids no son iguales");
            }
            context.Update(store);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Store>> Delete(int id)
        {
            var registroBorrado = await context.MaintenanceTasks.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (registroBorrado == 0)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
