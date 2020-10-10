using Kickoff.Constants.Media;
using Kickoff.Models.Media;
using Kickoff.Services.Definitions.Media;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Kickoff.Services.Implementations.Media
{
    public class FileBuilder : BaseDocumentBuilder, IFileBuilder
    {
        public FileModel GetModel(IPublishedContent content)
        {
            var model = base.GetModel<FileModel>(content);

            model.FilePath = content.Url;

            model.Size = content.Value<int>(File.UmbracoBytes);

            model.Title = content.Value<string>(File.Title);

            model.Extension = content.Value<string>(File.umbracoExtension);

            return model;
        }
    }
}