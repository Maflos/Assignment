using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccesLayer;

namespace BusinessLayer
{
    public class CrudRepository<TDataGateway, TEntity>
         where TDataGateway : GenericDataGateway<TEntity>, new()
         where TEntity : Entity
    {
        private TDataGateway myGateway;

        public CrudRepository()
        {
            this.myGateway = new TDataGateway();
        }

        public bool Insert(TEntity entity)
        {
            return myGateway.Insert(entity);
        }

        public bool Delete(int id)
        {
            return myGateway.Delete(id);
        }

        public bool Update(int id, TEntity entity)
        {
            return myGateway.Update(id, entity);
        }

        public Entity Find(int id)
        {
            return myGateway.Find(id);
        }

        public List<TEntity> FindAll()
        {
            return myGateway.FindAll();
        }
    }
}
