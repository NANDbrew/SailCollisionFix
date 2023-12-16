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
        [HarmonyPrefix]
        [HarmonyPatch("IsCollidingWithSail")]
        private static void SailsCollisionPatch(ShipyardSailColChecker __instance)
        {
            if (Main.ignoreSailsCollision.Value)
            {
                __instance.collisionsWithSails = 0;
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("IsObstructed")]
        private static void SailObstructionPatch(ShipyardSailColChecker __instance)
        {
            if (Main.ignoreObstructed.Value)
            {
                __instance.collisionsWithOther = 0;
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
    }
}
