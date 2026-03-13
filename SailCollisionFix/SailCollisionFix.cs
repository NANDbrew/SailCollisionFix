using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Reflection;

namespace SailCollisionFix
{  
    [HarmonyPatch(typeof(ShipyardSailColChecker))]
    static class Patches
    {
        [HarmonyPostfix]
        [HarmonyPatch("IsCollidingWithSail")]
        private static void SailsCollisionPatch(ref bool __result)
        {
            if (Main.ignoreSailsCollision.Value)
            {
                __result = false;
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("IsObstructed")]
        private static void SailObstructionPatch(ref bool __result)
        {
            if (Main.ignoreObstructed.Value)
            {
                __result = false;
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("OnTriggerEnter")]
        private static void SailAnglesPatch(ShipyardSailColChecker __instance)
        {
            if (Main.ignoreAngleLimits.Value)
            {
                __instance.colAngleMin = __instance.startMinAngle;
                __instance.colAngleMax = __instance.startMaxAngle;
            }
        }

#if DEBUG
        [HarmonyPrefix]
        [HarmonyPatch("OnTriggerEnter")]
        private static bool EverythingPatch()
        {
            if (Main.ignoreAll.Value) return false;

            return true;
        }
#endif

    }
}
