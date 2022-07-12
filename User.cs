using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vikasApplication.Models;
using vikasApplication.Repositiory.Interfaces;

namespace vikasApplication.Repositiory.Services
{
    public class User : IUser
    {
        private readonly UsersDbContext context;

        public User(UsersDbContext context)
        {
            this.context = context;
        }


        public List<UsersModel> IndexPost()
        {
            var result = context.users.ToList();
            return result;
        }
        [HttpPost]
        public bool Check(TableDetailsModel tableDetailsModel)
        {
            if (tableDetailsModel != null)
            {
                
                context.TableDetails.Add(tableDetailsModel);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Login(UsersModel model)
        {
            var vik = context.users.Where(e => e.Email == model.Email && e.Password == model.Password).FirstOrDefault();

            if (vik != null){ 
                return true;
                }
            else
            {
                return false;
            }
        }
    }
}
