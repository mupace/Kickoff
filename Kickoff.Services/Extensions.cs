using Kickoff.Models.Common;
using Kickoff.Models.Shared;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Kickoff.Services
{
    public static class Extensions
    {
        public static List<LinkModel> UmbracoLinksToLinkModel(this IEnumerable<Link> links)
        {
            if (links == null)
                return null;

            return links
                    .Select(x => x.UmbracoLinkToLinkModel())
                    .ToList();
        }

        public static LinkModel UmbracoLinkToLinkModel(this Link link)
        {
            return new LinkModel()
            {
                Name = link.Name,
                LinkType = (int)link.Type,
                Target = link.Target,
                Udi = link.Udi.ToString(),
                Url = link.Url
            };
        }

        public static NavigationItemModel UmbracoNodeToNavigationItem(this IPublishedContent page, string titlePropertyAlias)
        {
            var model = new NavigationItemModel();

            model.Id = page.Id;

            model.Title = page.Value<string>(titlePropertyAlias);

            model.Url = page.Url;

            return model;
        }
    }
}