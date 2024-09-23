using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using server_ext.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace server_ext.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class BaseApiController<TEntity, TEntityDto> : ControllerBase
        where TEntity: class     
        where TEntityDto : class
    {
        public readonly BaseAppDbContext _context;
        public readonly IMapper _mapper;


        public BaseApiController(
            BaseAppDbContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<IEnumerable<TEntityDto>> GetAll()
        {
            var dbSet = _context.GetDbSet<TEntity>();
            var entities = await dbSet.ToListAsync();
            var result = _mapper.Map<IEnumerable<TEntityDto>>(entities);

            return result;
        }

        [HttpGet("{id}")]
        public virtual async Task<TEntityDto> GetById(int id)
        {
            var dbSet = _context.GetDbSet<TEntity>();
            var entity = await dbSet.FindAsync(id);
            var result = _mapper.Map<TEntityDto>(entity);

            return result;

        }

        [HttpPost]
        public virtual async Task<TEntityDto> Create(TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            var dbSet = _context.GetDbSet<TEntity>();
            dbSet.Add(entity);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<TEntityDto>(entity);

            return result;
        }

        [HttpPut("{id}")]
        public virtual async Task<TEntityDto> Update(int id, TEntityDto entityDto)
        {
            var dbSet = _context.GetDbSet<TEntity>();
            var entity = await dbSet.FindAsync(id);
            _mapper.Map(entityDto, entity);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<TEntityDto>(entity);

            return result;
        }

        [HttpDelete("{id}")]
        public virtual async Task Delete(int id)
        {
            var dbSet = _context.GetDbSet<TEntity>();
            var entity = await dbSet.FindAsync(id);

            if(entity == null)
            {
                Log.Error($"Entity {typeof(TEntity).Name} not found");
                throw new Exception($"Entity {typeof(TEntity).Name} not found");
            }
                

            dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
