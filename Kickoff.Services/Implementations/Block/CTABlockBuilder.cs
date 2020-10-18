using Kickoff.Constants.Blocks;
using Kickoff.Models.Block;
using Kickoff.Services.Definitions.Blocks;
using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Kickoff.Services.Implementations.Block
{
    public class CTABlockBuilder : BaseDocumentBuilder, ICTABlockBuilder
    {
        public CTABlockModel GetModel(IPublishedContent content)
        {
            var model = base.GetModel<CTABlockModel>(content);

            model.Title = content.Value<string>(CTABlock.Title);

            model.Subtext = content.Value<string>(CTABlock.SubText);

            model.LinkInfoList = content.Value<List<Link>>(CTABlock.LinkInfo).UmbracoLinksToLinkModel();

            return model;
        }
    }
}