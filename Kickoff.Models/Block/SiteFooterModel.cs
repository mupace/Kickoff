using Kickoff.Models.Common;
using System.Collections.Generic;

namespace Kickoff.Models.Block
{
    public class SiteFooterModel : BaseDocumentModel
    {
        public string Title { get; set; }

        public List<LinkModel> Links { get; set; }

        public string FacebookUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string GithubUrl { get; set; }

        public string CopyrightText { get; set; }

        public bool UseHomepageStyle { get; set; }
    }
}