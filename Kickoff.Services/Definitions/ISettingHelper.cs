using Kickoff.Models.Common;
using System.Collections.Generic;

namespace Kickoff.Services.Definitions
{
    public interface ISettingHelper
    {
        SettingModel GetSetting(string key);

        List<SettingModel> GetSettings();
    }
}