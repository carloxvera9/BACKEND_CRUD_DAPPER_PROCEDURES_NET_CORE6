using Dominio.Entidad.Entity;
using Dominio.Interface.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Infraestructura.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
     
       private readonly IConfiguration _configuration;

        public ILibrosRepository Libros { get; }

        public UnitOfWork(IConfiguration configuration)
        {
            _configuration = configuration;
            Libros = new LibrosRepository(_configuration);
        }

        

        
    }
}
