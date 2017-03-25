using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccesLayer
{
    public abstract class GenericDataGateway<TEntity> where TEntity : Entity
    {
        public abstract void Insert(TEntity entity);

        public abstract void Delete(TEntity entity);
    }
}
