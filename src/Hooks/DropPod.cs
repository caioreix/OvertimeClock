using System;
using HarmonyLib;
using OvertimeClock.Settings;
using Utils.Logger;

namespace OvertimeClock.Hooks;

[Harmony]

public class DropPodPatch {
    [HarmonyPatch(typeof(DropPod), nameof(DropPod.Awake))]
    public static class Awake {
        private static void Prefix(DropPod __instance) {
            try {
                if (ENV.OverrideDropPodTimeout.Value) {
                    __instance.secondsToTimeOut = ENV.DropPodTimeoutInSeconds.Value;
                } else {
                    __instance.secondsToTimeOut += ENV.DropPodTimeoutInSeconds.Value;
                }
            } catch (Exception e) { Log.Fatal(e); }
        }
    }
}
