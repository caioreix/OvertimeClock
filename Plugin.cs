using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using UnityEngine;

namespace OvertimeClock;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]

public class Plugin : BasePlugin {
    public readonly static Harmony Harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
    private static MonoBehaviour _keybindingBehavior;

    public override void Load() {
        Settings.Config.Load(Config, Log, "Client");

        _keybindingBehavior = AddComponent<Behaviors.Keybinding>();

        Utils.Logger.Log.Trace("Patching harmony");
        Harmony.PatchAll();

        Utils.Logger.Log.Info($"Plugin {MyPluginInfo.PLUGIN_GUID} v{MyPluginInfo.PLUGIN_VERSION} loaded!");
    }

    public override bool Unload() {
        if (_keybindingBehavior != null) {
            Object.Destroy(_keybindingBehavior);
            _keybindingBehavior = null;
        }

        Utils.Logger.Log.Trace("Unpatching harmony");
        Harmony.UnpatchSelf();
        Utils.Logger.Log.Info($"Plugin {MyPluginInfo.PLUGIN_GUID} v{MyPluginInfo.PLUGIN_VERSION} unloaded!");
        return true;
    }
}
