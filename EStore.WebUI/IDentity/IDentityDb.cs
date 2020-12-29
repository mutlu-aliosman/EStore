using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.WebUI.IDentity
{
    public class IDentityDb:IdentityDbContext<User>
    {
        public IDentityDb(DbContextOptions<IDentityDb>options)
            :base(options)
        {

        }
    }
}
