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
                    __instance.collisionsWithSails = 0;
                }
                return;
            }
        }
        [HarmonyPatch(typeof(ShipyardSailColChecker), "IsObstructed")]
        public static class SailObstructionPatch
        {
            [HarmonyPrefix]
            private static void Prefix(ShipyardSailColChecker __instance)
            {
                if (Main.enabled)
                {
                    __instance.collisionsWithOther = 0;
                }
                return;
            }
        }
    }
}
