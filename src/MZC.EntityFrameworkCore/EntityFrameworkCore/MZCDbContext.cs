using Abp.Zero.EntityFrameworkCore;
using MZC.Authorization.Roles;
using MZC.Authorization.Users;
using MZC.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using MZC.Blog.Notes;
using MZC.Count;

namespace MZC.EntityFrameworkCore
{
    public class MZCDbContext : AbpZeroDbContext<Tenant, Role, User, MZCDbContext>
    {
        /* Define an IDbSet for each entity of the application */
        
        public MZCDbContext(DbContextOptions<MZCDbContext> options)
            : base(options)
        {

        }
        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteBook> NoteBooks { get; set; }
        public DbSet<NoteToNoteBook> NoteToNoteBooks { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillType> BillTypes { get; set; }

    }
}
