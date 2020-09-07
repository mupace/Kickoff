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
                    .Select(x => new LinkModel()
                    {
                        Name = x.Name,
                        LinkType = (int)x.Type,
                        Target = x.Target,
                        Udi = x.Udi.ToString(),
                        Url = x.Url
                    })
                    .ToList();
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