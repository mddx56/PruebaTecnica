using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.DB;
using PruebaTecnica.Dtos;
using PruebaTecnica.Entities;

namespace PruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TaskController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet(Name = "Listar Tareas")]
        public async Task<IEnumerable<MaintenanceTaskDto>> Get()
        {
            var tasks = await context.MaintenanceTasks
                .ToListAsync();
            var taskDto = mapper.Map<IEnumerable<MaintenanceTaskDto>>(tasks);
            return taskDto;
        }

        [HttpGet("{id:int}", Name = "Obtener Tarea")]
        public async Task<ActionResult<MaintenanceTaskDto>> Get(int id)
        {
            var task = await context.MaintenanceTasks
                .FirstOrDefaultAsync(x => x.Id == id);
            if (task is null)
            {
                return NotFound();
            }
            var taskDto = mapper.Map<MaintenanceTaskDto>(task);
            return taskDto;
        }

        [HttpPost]
        public async Task<ActionResult> Post(MaintenanceTaskCreateDto taskCreation)
        {
            var task = mapper.Map<MaintenanceTask>(taskCreation);
            context.Add(task);
            await context.SaveChangesAsync();
            var taskDto = mapper.Map<MaintenanceTaskDto>(task);
            return Ok(taskDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<MaintenanceTask>> Put(int id, MaintenanceTaskCreateDto taskCreation)
        {
            var task = mapper.Map<MaintenanceTask>(taskCreation);
            task.Id = id;
            context.Update(task);
            await context.SaveChangesAsync();
            var taskDto = mapper.Map<MaintenanceTaskDto>(task);
            return Ok(taskDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<MaintenanceTaskDto>> Delete(int id)
        {
            var deleted = await context.MaintenanceTasks.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (deleted == 0)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
