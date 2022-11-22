﻿using AlquilerTodo2Pesos.Server.Models;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AlquilerTodo2Pesos.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options ,
            IOptions<OperationalStoreOptions>  operationalStoreOptions) : base(options , operationalStoreOptions )
        {
        }
    }
}