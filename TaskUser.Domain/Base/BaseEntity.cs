using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskUser.Domain.Base
{
    public interface IBaseEntity
    {
        Guid Id { get; }
    }

    public abstract class BaseEntity : IBaseEntity
    {
        private Guid _id;

        protected BaseEntity()
        {

        }

        protected BaseEntity(Guid id)
        {
            Id = id;
        }

        public Guid Id
        {
            get => _id;
            set
            {
                _id = value;
            }
        }
    }
}
