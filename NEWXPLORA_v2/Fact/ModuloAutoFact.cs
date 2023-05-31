using Autofac;
using Dominio.Infraestructura.Repositories;
using Dominio.Interface.Interface;

namespace NEWXPLORA_v2.Fact
{
    public class ModuloAutoFact : Autofac.Module
    {
        private readonly IConfiguration _configuration;
        public ModuloAutoFact(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

       
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(build => new UnitOfWork(_configuration)).As<IUnitOfWork>();
        }


    }
}
