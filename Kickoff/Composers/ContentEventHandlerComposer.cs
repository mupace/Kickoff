using Kickoff.Services.Definitions.Cache;
using System.Collections.Generic;
using Umbraco.Core.Composing;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Core.Services.Implement;

namespace Kickoff.Composers
{
    public class ContentEventHandlerComposer : ComponentComposer<ContentEventHandler>
    {
    }

    public class ContentEventHandler : IComponent
    {
        private readonly IMemoryCacheService _memoryCacheService;

        public ContentEventHandler(IMemoryCacheService memoryCacheService)
        {
            _memoryCacheService = memoryCacheService;
        }

        public void Initialize()
        {
            ContentService.Published += ContentPublished;
            ContentService.Unpublished += ContentUnpublished;
        }

        private void ContentPublished(IContentService sender, ContentPublishedEventArgs e)
        {
            InvalidateCache(e.PublishedEntities);
        }

        private void ContentUnpublished(IContentService sender, PublishEventArgs<IContent> e)
        {
            InvalidateCache(e.PublishedEntities);
        }

        private void InvalidateCache(IEnumerable<IContent> contents)
        {
            foreach (var item in contents)
            {
                _memoryCacheService.InvalidateByNodeAlias(item.ContentType.Alias, item.Id);
            }
        }

        public void Terminate()
        {
            //unsubscribe during shutdown
            ContentService.Published -= ContentPublished;
            ContentService.Unpublished -= ContentUnpublished;
        }
    }
}