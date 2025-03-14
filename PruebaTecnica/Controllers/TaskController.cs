using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.DB;
using PruebaTecnica.Dtos;
using PruebaTecnica.Entities;
using PruebaTecnica.Services;
using PruebaTecnica.Utils;

namespace PruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IServiceUser servicesUsers;

        public TaskController(ApplicationDbContext context, IMapper mapper, IServiceUser servicesUsers)
        {
            this.context = context;
            this.mapper = mapper;
            this.servicesUsers = servicesUsers;
        }

        [HttpGet(Name = "Listar Todas Tareas")]
        [Authorize(Policy = "isadmin")]
        public async Task<IEnumerable<MaintenanceTaskDto>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = context.MaintenanceTasks.AsQueryable();
            await HttpContext.InsertPaginationHeader(queryable);
            var tasks = await queryable.OrderBy(x => x.Id).Paginate(paginationDTO).ToListAsync();
            var taskDto = mapper.Map<IEnumerable<MaintenanceTaskDto>>(tasks);
            return taskDto;
        }

        [HttpGet("me",Name = "Obtener Tareas de usuario")]
        public async Task<IEnumerable<MaintenanceTaskDto>> Get()
        {
            var usuario = await servicesUsers.ObtenerUsuario();
            if (usuario is null)
            {
                return [];
            }
            var tasks = await context.MaintenanceTasks
            .Where(x => x.UserId == usuario.Id)
            .ToListAsync();
            var tasksDto = mapper.Map<IEnumerable<MaintenanceTaskDto>>(tasks);
            return tasksDto;
        }

        [HttpPost]
        //[Authorize(Policy = "isadmin")]
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
