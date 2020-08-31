﻿using Kickoff.Models.Pages;
using Kickoff.Services.Definitions.Pages;
using Umbraco.Core.Models.PublishedContent;

namespace Kickoff.Services.Implementations.Pages
{
    public class PageBaseBuilder : BaseDocumentBuilder
    {
        protected readonly INavigationBuilder _navigationBuilder;

        protected readonly ISeoBaseBuilder _seoBaseBuilder;

        public PageBaseBuilder(INavigationBuilder navigationBuilder, ISeoBaseBuilder seoBaseBuilder)
        {
            _navigationBuilder = navigationBuilder;
            _seoBaseBuilder = seoBaseBuilder;
        }

        public PageBaseModel GetModel(IPublishedContent content)
        {
            var model = base.GetModel<PageBaseModel>(content);

            model.Navigation = _navigationBuilder.GetModel(content);

            model.SeoBase = _seoBaseBuilder.GetModel(content);

            return model;
        }

    }
}