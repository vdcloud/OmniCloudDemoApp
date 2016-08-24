
namespace Capgemini.Demo.App.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    public partial class RACEPortalDBEntities : DbContext
    {
        public RACEPortalDBEntities()
            : base("name=RACEPortalDBEntities")
        {
        }
        public virtual DbSet<User> Users { get; set; }
    }
    }