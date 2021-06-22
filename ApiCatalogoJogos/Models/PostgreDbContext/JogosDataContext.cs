using ApiCatalogoJogos.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Models.PostgreDbContext
{
    public class JogosDataContext : DbContext
    {
        public JogosDataContext(DbContextOptions<JogosDataContext>options) : base(options)
        { }

        public DbSet<Jogo> tabelajogos { get; set; }
    }
}
