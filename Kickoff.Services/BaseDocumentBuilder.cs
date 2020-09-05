using Kickoff.Models;

using Umbraco.Core.Models.PublishedContent;

namespace Kickoff.Services
{
    public class BaseDocumentBuilder
    {
        public virtual T GetModel<T>(IPublishedContent content) where T : BaseDocumentModel, new()
        {
            var model = new T();

            model.Id = content.Id;

            model.Name = content.Name;

            model.CreateDate = content.CreateDate;

            model.UpdateDate = content.UpdateDate;

            model.UniqueKey = content.Key;

            return model;
        }
    }
}
