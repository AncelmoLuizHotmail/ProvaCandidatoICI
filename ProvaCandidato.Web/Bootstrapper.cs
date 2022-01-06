using Microsoft.Practices.Unity;
using ProvaCandidato.Data.Repositories;
using ProvaCandidato.Data.Repositories.Interface;
using System.Web.Mvc;
using Unity.Mvc3;

namespace ProvaCandidato
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<ICidadeRepository, CidadeRepository>();
            container.RegisterType<IClienteRepository, ClienteRepository>();

            return container;
        }
    }
}