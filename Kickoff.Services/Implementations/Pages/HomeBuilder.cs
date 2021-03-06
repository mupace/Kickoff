﻿using Kickoff.Constants.Pages;
using Kickoff.Models.Pages;
using Kickoff.Services.Definitions.Pages;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Kickoff.Services.Implementations.Pages
{
    public class HomeBuilder : PageBaseBuilder, IHomeBuilder
    {
        public HomeBuilder(INavigationBuilder navigationBuilder, ISeoBaseBuilder seoBaseBuilder) : base(navigationBuilder, seoBaseBuilder)
        {
        }

        public HomeModel GetModel(IPublishedContent content)
        {
            var model = base.GetModel<HomeModel>(content);

            model.BannerCTA = content.Value<Link>(Home.BannerCTA)?.UmbracoLinkToLinkModel();

            model.UnderMaintenance = content.Value<bool>(Home.UnderMaintenance);

            return model;
        }
    }
}