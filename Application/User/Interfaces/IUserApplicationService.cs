using System.Collections.Generic;
using EntityClass = Application.User.UserEntity;

namespace Application.User.Interfaces
{
    public interface IUserApplicationService
    {
        public IEnumerable<EntityClass> GetAll();
        public IEnumerable<EntityClass> GetById(int id);
        public IEnumerable<EntityClass> GetByGroupId(int groupId);
        public IEnumerable<EntityClass> Create();
        public IEnumerable<EntityClass> Login();
        public IEnumerable<EntityClass> Update();
        public IEnumerable<EntityClass> Delete();
    }
}
