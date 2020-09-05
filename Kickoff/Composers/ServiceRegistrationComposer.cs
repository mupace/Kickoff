using Kickoff.Services.Definitions.Media;
using Kickoff.Services.Definitions.Pages;
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

            #region Service.Definitions.Media

            composition.Register<IImageBuilder, ImageBuilder>(Lifetime.Singleton);

            #endregion


            #region Services.Definitions.Pages

            composition.Register<INavigationBuilder, NavigationBuilder>(Lifetime.Singleton);
            composition.Register<ISeoBaseBuilder, SeoBaseBuilder>(Lifetime.Singleton);
            composition.Register<IHomeBuilder, HomeBuilder>(Lifetime.Singleton);
            
            #endregion
        }
    }
}