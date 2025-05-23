using UnityEngine;
using Utils.Settings;

namespace OvertimeClock.Settings;

public static class ENV {
    // Mission_General
    private readonly static string settings = "0.⚙️ Settings";
    public static ConfigElement<bool> OverrideDropPodTimeout;
    public static ConfigElement<int> DropPodTimeoutInSeconds;
    public static ConfigElement<KeyCode> ReloadSettingsKey;

    public static class Settings {
        public static void Setup() {
            Utils.Settings.Config.AddConfigActions(load);
        }

        // Load the plugin config variables.
        private static void load() {
            OverrideDropPodTimeout = Utils.Settings.Config.Bind(
                settings,
                nameof(OverrideDropPodTimeout),
                true,
                $"Override the default drop pod timeout. if disable the timeout will be increased by {nameof(DropPodTimeoutInSeconds)} instead override."
            );

            DropPodTimeoutInSeconds = Utils.Settings.Config.Bind(
                settings,
                nameof(DropPodTimeoutInSeconds),
                180,
                "The countdown duration in seconds."
            );

            ReloadSettingsKey = Utils.Settings.Config.Bind(
                settings,
                nameof(ReloadSettingsKey),
                KeyCode.F5,
                "The key to reload the settings."
            );

            Utils.Settings.Config.Save();
        }
    }
}
