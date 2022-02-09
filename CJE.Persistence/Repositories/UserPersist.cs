﻿using CJE.Domain.Entities.Identity;
using CJE.Persistence.Interfaces;
using CJE.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJE.Persistence.Repositories
{
    public class UserPersist : BasePersist<User>, IUserPersist
    {
        public UserPersist(CjEventsContext context) : base(context){}

        public async Task<User> GetUserByIdAsync(int id)
        {
            IQueryable<User> query = _context.Users
              .Include(e => e.UserRoles)
              .ThenInclude(e=> e.Role);

            query = query.Where(q => q.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            IQueryable<User> query = _context.Users
              .Include(e => e.UserRoles)
              .ThenInclude(e => e.Role);

            query = query.Where(q => q.NormalizedUserName == username.ToUpper());

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            IQueryable<User> query = _context.Users
              .Include(e => e.UserRoles)
              .ThenInclude(e => e.Role);

            query = query.OrderBy(e => e.Id);

            return await query.ToListAsync();
        }
    }
}
