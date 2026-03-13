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
        public const string VERSION = "1.1.3";

        internal static Main instance;

        internal static ManualLogSource logSource;

        internal static ConfigEntry<bool> ignoreSailsCollision;
        internal static ConfigEntry<bool> ignoreObstructed;
        internal static ConfigEntry<bool> ignoreAngleLimits;
        internal static ConfigEntry<bool> ignoreAll;


        private void Awake()
        {
            instance = this;
            logSource = Logger;
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), GUID);

            ignoreSailsCollision = Config.Bind("Options", "Ignore sail collision", true, new ConfigDescription("Enable this if you can't install a sail because the game says (SAILS COLLISION). (this might be cheating)"));
            ignoreObstructed = Config.Bind("Options", "Ignore obstructions", false, new ConfigDescription("Enable this if you can't install a sail because the game says (OBSTRUCTED). (this is probably cheating)"));
            ignoreAngleLimits = Config.Bind("Options", "Ignore angle limits", false, new ConfigDescription("Enable this if you CAN install a sail but its' rotation angles are terrible. (this is definitely cheating)"));
#if DEBUG
            ignoreAll = Config.Bind("Options", "Ignore all limits", false, new ConfigDescription("Brute force combining all three other options"));
#endif

        }
    }
}

