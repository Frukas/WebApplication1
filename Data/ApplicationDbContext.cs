using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext<OperatorModel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebApplication1.Models.ActivitiesModel> ActivitiesModel { get; set; }
        public DbSet<WebApplication1.Models.ClientModel> clientModels { get; set; }
        public DbSet<WebApplication1.Models.TaskListModel> taskListModels { get; set; }
        public DbSet<WebApplication1.Models.GroupModel> groupModels { get; set; }

    }
}