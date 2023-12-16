using HarmonyLib;
using System.Reflection;
using UnityEngine;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;

namespace SailCollisionFix
{
    [BepInPlugin(GUID, NAME, VERSION)]
    internal class Main : BaseUnityPlugin
    {
        public const string GUID = "com.nandbrew.sailcollisionfix";
        public const string NAME = "Sail Collision Fix";
        public const string VERSION = "1.1.2";

        internal static Main instance;

        internal static ManualLogSource logSource;

        internal static ConfigEntry<bool> ignoreSailsCollision;
        internal static ConfigEntry<bool> ignoreObstructed;
        internal static ConfigEntry<bool> ignoreAngleLimits;


        private void Awake()
        {
            instance = this;
            logSource = Logger;
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), GUID);

            ignoreSailsCollision = Config.Bind("Options", "Ignore sail collision", true);
            ignoreObstructed = Config.Bind("Options", "Ignore obstructions", false);
            ignoreAngleLimits = Config.Bind("Options", "Ignore angle limits", false);

        }
    }
}

