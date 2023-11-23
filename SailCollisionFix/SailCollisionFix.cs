using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Reflection;

namespace SailCollisionFix
{

    public static class Patches
    {
        [HarmonyPatch(typeof(ShipyardSailColChecker), "IsCollidingWithSail")]
        public static class SailCollisionPatch
        {   
            [HarmonyPostfix]
            private static void Postfix(ShipyardSailColChecker __instance)
            {
                if (Main.enabled)
                {
                    if (Main.settings.IgnoreSailsCollision)
                    {
                        __instance.collisionsWithSails = 0;
                    }
                }
            }
        }
        [HarmonyPatch(typeof(ShipyardSailColChecker), "IsObstructed")]
        public static class SailObstructionPatch
        {
            [HarmonyPostfix]
            private static void Postfix(ShipyardSailColChecker __instance)
            {
                if (Main.enabled)
                {
                    if (Main.settings.IgnoreObstructed)
                    {
                        __instance.collisionsWithOther = 0;
                    }
                }
                return;
            }
        }

        [HarmonyPatch(typeof(ShipyardSailColChecker), "RunColCheck")]
        public static class SailAnglesPatch
        {
            [HarmonyPrefix]
            private static bool Prefix(ShipyardSailColChecker __instance)
            {
                if (Main.enabled)
                {
                    if (Main.settings.IgnoreAngleLimits)
                    {
                        __instance.colAngleMin = (float)__instance.startMinAngle;
                        __instance.colAngleMax = (float)__instance.startMaxAngle;
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
