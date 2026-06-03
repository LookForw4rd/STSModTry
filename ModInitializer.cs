using System.Reflection;
using HarmonyLib;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Modding;

namespace TestMod1_LookForward
{
    [ModInitializer(nameof(Initialize))]
    public static class ModInitializer 
    {
        public static void Initialize() {
            Godot.Bridge.ScriptManagerBridge.LookupScriptsInAssembly(Assembly.GetExecutingAssembly());
            Harmony harmony = new Harmony("com.fuyibo.testmod1_lookforward");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            Log.Info("TestMod1_LookForward - 加载成功!");
        }
    }
}