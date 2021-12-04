using System.Collections.Generic;

namespace HomeDepot.DataLayer.Interfaces
{
    public interface IRepository<Entity> where Entity: class
    {
        Entity Get(int id);
        List<Entity> GetAll();
        Entity Add(Entity entity);
        Entity Delete(Entity entity);
        Entity update(Entity entity);
    }
}
