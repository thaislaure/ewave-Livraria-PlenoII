using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using BLL.Bussiness;
using BLL.Interfaces;
using DAL.Repository;
using Microsoft.AspNet.WebFormsDependencyInjection.Unity;
using Unity;


namespace UI
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {

            var container = this.AddUnity();
            container.RegisterType<ILivroRepository, LivroRepository>();
            container.RegisterType<IRepositoryBase, RepositoryBase>();
            container.RegisterType<IAutorRepository, AutorRepository>();
            container.RegisterType<IEditoraRepository, EditoraRepository>();
            container.RegisterType<ILivroBLL, LivroBLL>();
            
            // Código que é executado na inicialização do aplicativo
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}