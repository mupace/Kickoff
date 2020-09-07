using Kickoff.Services.Definitions.Blocks;
using Kickoff.Services.Definitions.Cache;
using Kickoff.Services.Definitions.Media;
using Kickoff.Services.Definitions.Pages;
using Kickoff.Services.Implementations.Block;
using Kickoff.Services.Implementations.Cache;
using Kickoff.Services.Implementations.Media;
using Kickoff.Services.Implementations.Pages;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Kickoff.Composers
{
    public class ServiceRegistrationComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            #region Service.Definitions.Blocks

            composition.Register<ISiteFooterBuilder, SiteFooterBuilder>(Lifetime.Singleton);
            composition.Register<ISiteHeaderBuilder, SiteHeaderBuilder>(Lifetime.Singleton);

            #endregion

            #region Service.Definitions.Cache

            composition.Register<IMemoryCacheService, MemoryCacheService>(Lifetime.Singleton);

            #endregion

            #region Service.Definitions.Media

            composition.Register<IImageBuilder, ImageBuilder>(Lifetime.Singleton);

            #endregion

            #region Services.Definitions.Pages
            
            composition.Register<IHomeBuilder, HomeBuilder>(Lifetime.Singleton);
            composition.Register<INavigationBuilder, NavigationBuilder>(Lifetime.Singleton);
            composition.Register<ISeoBaseBuilder, SeoBaseBuilder>(Lifetime.Singleton);
            composition.Register<IStandardPageBuilder, StandardPageBuilder>(Lifetime.Singleton);

            #endregion
        }
    }
}