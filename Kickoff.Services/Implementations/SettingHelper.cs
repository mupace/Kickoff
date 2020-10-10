using Kickoff.Constants;
using Kickoff.Constants.Settings;
using Kickoff.Models.Common;
using Kickoff.Services.Definitions;
using Kickoff.Services.Definitions.Cache;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Kickoff.Services.Implementations
{
    public class SettingHelper : ISettingHelper
    {
        private readonly IMemoryCacheService _memoryCacheService;

        private readonly IUmbracoContextFactory _umbracoContextFactory;

        public SettingHelper(IMemoryCacheService memoryCacheService, IUmbracoContextFactory umbracoContextFactory)
        {
            _memoryCacheService = memoryCacheService;
            _umbracoContextFactory = umbracoContextFactory;
        }

        public SettingModel GetSetting(string key)
        {
            return GetSettings().FirstOrDefault();
        }

        public List<SettingModel> GetSettings()
        {
            return _memoryCacheService.AddOrGet(ContentCacheKeys.SettingCacheKey, GetAllSettings);
        }

        private List<SettingModel> GetAllSettings()
        {
            using (var cref = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var settingRoot = cref.UmbracoContext.Content.GetSingleByXPath($"//{SettingsRoot.DocumentTypeAlias}");

                if (settingRoot != null)
                {
                    return settingRoot.Children.Select(ParseSetting).ToList();
                }
            }

            return null;
        }

        private SettingModel ParseSetting(IPublishedContent setting)
        {
            var model = new SettingModel();

            model.Id = setting.Id;

            model.Key = setting.Value<string>(Setting.Key);

            model.Value = setting.Value<string>(Setting.Value);

            return model;
        }
    }
}