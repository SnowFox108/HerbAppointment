using AnyaSpa.Dal.Models;

namespace AnyaSpa.Main.StaticDataCache
{
    public interface IStaticDataService
    {
        SystemSettingDto GetSystemSetting();
    }
}
