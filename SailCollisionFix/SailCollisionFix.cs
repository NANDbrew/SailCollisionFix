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
            [HarmonyPrefix]
            private static void Prefix(ShipyardSailColChecker __instance)
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

            }
        }

        [HarmonyPatch(typeof(ShipyardSailColChecker), "OnTriggerEnter")]
        public static class SailAnglesPatch
        {
            [HarmonyPostfix]
            private static void Postfix(ShipyardSailColChecker __instance)
            {
                if (Main.enabled)
                {
                    if (Main.settings.IgnoreAngleLimits)
                    {
                        __instance.colAngleMin = (float)__instance.startMinAngle;
                        __instance.colAngleMax = (float)__instance.startMaxAngle;
                    }
                }
            }
        }
    }
}
