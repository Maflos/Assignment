using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccesLayer;

namespace BusinessLayer
{
    public class Repository<TDataGateway, TEntity>
         where TDataGateway : GenericDataGateway<TEntity>, new()
         where TEntity : Entity
    {
        private TDataGateway myGateway;

        public Repository()
        {
            this.myGateway = new TDataGateway();
        }

        public void Insert(TEntity entity)
        {
            myGateway.Insert(entity);
        }

        public void Delete(TEntity entity)
        {
            myGateway.Delete(entity);
        }

    }
}
