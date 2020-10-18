using Kickoff.Models.Common;
using System.Collections.Generic;

namespace Kickoff.Models.Block
{
    public class CTABlockModel : BaseDocumentModel
    {
        public string Title { get; set; }

        public string Subtext { get; set; }

        public List<LinkModel> LinkInfoList { get; set; }
    }
}