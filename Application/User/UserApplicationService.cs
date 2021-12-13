using Application.User.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User
{
    public class UserApplicationService: IUserApplicationService
    {
        public UserApplicationService()
        {
        }

        public IEnumerable<UserEntity> Create()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> Delete()
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<UserEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> GetByGroupId(int groupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> Login()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> Update()
        {
            throw new NotImplementedException();
        }
    }
}
