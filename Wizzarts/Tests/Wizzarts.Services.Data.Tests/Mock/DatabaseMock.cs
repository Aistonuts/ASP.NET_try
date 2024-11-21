﻿using Microsoft.AspNetCore.Identity;
using Wizzarts.Data.Models;

namespace Wizzarts.Services.Data.Tests.Mock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Moq;
    using Wizzarts.Data;

    public class DatabaseMock
    {
        public static ApplicationDbContext MockDatabase()
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder
                         = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("ApplicationDbContextDb"
                    + DateTime.Now.Ticks.ToString());

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}