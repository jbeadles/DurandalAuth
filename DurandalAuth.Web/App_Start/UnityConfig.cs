using System;
using System.Data.Entity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DurandalAuth.Web.SEO;
using DurandalAuth.Domain.UnitOfWork;
using DurandalAuth.Data.UnitOfWork;
using DurandalAuth.Domain.Model;
using DurandalAuth.Data;
using DurandalAuth.Web.Helpers;
using DurandalAuth.Web.Controllers;
using DurandalAuth.Domain.Validators;

namespace DurandalAuth.Web.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<ISnapshot, Snapshot>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IBreezeValidator, BreezeValidator>();

            // Identity Configuration
            container.RegisterType<IUserStore<UserProfile>, UserStore<UserProfile>>();
            container.RegisterType<UserManager<UserProfile>>();
            container.RegisterType<DbContext, DurandalAuthDbContext>();
            container.RegisterType<ApplicationUserManager>();
            //container.RegisterType<AccountController>(new InjectionConstructor());
        }
    }
}
