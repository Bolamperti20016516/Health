using Health.Web.Models;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Health.Web.Controllers.Services
{
    public abstract class CrudController<TEntity, TId> : BaseController
        where TEntity : class, IHasId<TId>
    {
        [HttpGet]
        public async Task<IEnumerable<TEntity>> Get() => await Db.GetTable<TEntity>().ToListAsync();

        [HttpGet("{id}")]
        public async Task<TEntity> Get(TId id) => await Db.GetTable<TEntity>().FirstOrDefaultAsync(c => c.Id.Equals(id));

        [HttpPost]
        public async Task Post([FromBody]TEntity item) => await Db.InsertAsync(item);

        [HttpPut("{id}")]
        public async Task Put(TId id, [FromBody]TEntity item)
        {
            item.Id = id;

            await Db.UpdateAsync(item);
        }

        [HttpDelete("{id}")]
        public async Task Delete(TId id) => await Db.GetTable<TEntity>().Where(c => c.Id.Equals(id)).DeleteAsync();
    }
}
