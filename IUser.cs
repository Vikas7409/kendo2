using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vikasApplication.Models;
using vikasApplication.Repositiory.Services;

namespace vikasApplication.Repositiory.Interfaces
{
    public interface IUser 
    {
        List<UsersModel> IndexPost();
        public bool Check(TableDetailsModel tableDetailsModel);
        public bool Login(UsersModel model);
    }
}
