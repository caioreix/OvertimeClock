
using System;
using OvertimeClock.Settings;
using UnityEngine;
using Utils.Logger;

namespace OvertimeClock.Behaviors;

public class Keybinding : MonoBehaviour {
    public void Update() {
        if (Input.GetKeyDown(ENV.ReloadSettingsKey.Value)) {
            Utils.Settings.Config.Reload();
            Log.Info("Settings reloaded!");
        }
    }
}
