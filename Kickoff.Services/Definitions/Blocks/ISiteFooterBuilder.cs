using Kickoff.Models.Block;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kickoff.Services.Definitions.Blocks
{
    public interface ISiteFooterBuilder
    {
        SiteFooterModel GetModel();
    }
}
