using AutoMapper;
using MetarApi.Contracts;
using MetarApi.Data;
using MetarApi.Entities;
using MetarSharp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using System.Runtime;

namespace MetarApi.Controllers
{
    public class MetarController : BaseController
    {
        private readonly IMetarService _metarService;
        private readonly IMapper _mapper;
        private readonly MetarDbContext _dbContext;

        public MetarController(IMetarService metarService, IMapper mapper, MetarDbContext dbContext)
        {

            _mapper = mapper;
            _metarService = metarService;
            _dbContext = dbContext;
        }
        [Route("{GetAll}")]
        [HttpGet]

        public async Task<IList<MetarEntity>> GetAllAsync(CancellationToken ct)
        {
            return await _dbContext.Set<MetarEntity>().AsNoTracking().ToListAsync();
        }


        [Route("{id}")]
        [HttpGet]

        public async Task<IList<MetarEntity>> FindByCondition(Expression<Func<MetarEntity, bool>> expression, CancellationToken ct)
        {
            return await _dbContext.Set<MetarEntity>().Where(expression).AsNoTracking().ToListAsync();
        }


        [Route("{Delete}")]
        [HttpDelete]

        public async Task<bool> DeleteAsync(MetarEntity entity, CancellationToken ct)
        {
            _dbContext.Set<MetarEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync(ct);
            return true;
        }



        [Route("{Add}")]
        [HttpPost]
        public async Task<bool> AddAsync(MetarEntity entity, CancellationToken ct)
        {
            var metar = ParseMetar.FromString("EDDF 182320Z AUTO 26006KT 200V290 CAVOK 09/06 Q1016 NOSIG");
            entity = MetarEntity.Create(metar);
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync(ct);
            return true;
        }

        [Route("{Update}")]
        [HttpPut]

        public async Task<bool> UpdateAsync(MetarEntity entity, CancellationToken ct)
        {
            _dbContext.Set<MetarEntity>().Update(entity);
            await _dbContext.SaveChangesAsync(ct);
            return true;
        }





    }
}

