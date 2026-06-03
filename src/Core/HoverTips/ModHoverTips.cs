using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization;

namespace TestMod1_LookForward.Core.HoverTips
{
    public static class ModHoverTips
    {
        public static IHoverTip FanLevel => new HoverTip(
            new LocString("cards", "FAN_LEVEL.title"),
            new LocString("cards", "FAN_LEVEL.description")
        );
    }
}