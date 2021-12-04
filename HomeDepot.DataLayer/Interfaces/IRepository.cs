using System.Collections.Generic;

namespace HomeDepot.DataLayer.Interfaces
{
    public interface IRepository<Entity> where Entity: class
    {
        Entity Get(int id);
        List<Entity> GetAll();
        void Add(Entity entity);
        void Delete(Entity entity);
        void update(Entity entity);
    }
}
