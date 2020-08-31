using Kickoff.Services.Definitions.Media;
using Kickoff.Services.Definitions.Pages;
using Kickoff.Services.Implementations.Media;
using Kickoff.Services.Implementations.Pages;
using Umbraco.Core.Composing;

namespace Kickoff.Composers
{
    public class ServiceRegistrationComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {

            #region Service.Definitions.Media

            composition.RegisterFor<IImageBuilder, ImageBuilder>(Lifetime.Singleton);

            #endregion


            #region Services.Definitions.Pages

            composition.RegisterFor<IHomeBuilder, HomeBuilder>(Lifetime.Singleton);
            composition.RegisterFor<INavigationBuilder, NavigationBuilder>(Lifetime.Singleton);
            composition.RegisterFor<ISeoBaseBuilder, SeoBaseBuilder>(Lifetime.Singleton);

            #endregion
        }
    }
}