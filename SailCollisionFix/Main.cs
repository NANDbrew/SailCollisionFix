using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityEngine;
using UnityModManagerNet;

namespace SailCollisionFix
{
    public class Main
    {
        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            new Harmony(modEntry.Info.Id).PatchAll(Assembly.GetExecutingAssembly());

            mod = modEntry;

            settings = SailCollisionFixSettings.Load<SailCollisionFixSettings>(modEntry);

            modEntry.OnToggle = OnToggle;
            modEntry.OnGUI = OnGUI;
            modEntry.OnSaveGUI = OnSaveGUI;

            return true;
        }

        public static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            enabled = value;
            return true;
        }

        public static void OnGUI(UnityModManager.ModEntry modEntry)
        {        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Ignore sail collisions: ", GUILayout.ExpandWidth(false));
            settings.IgnoreSailsCollision = GUILayout.Toggle(settings.IgnoreSailsCollision, "", GUILayout.ExpandWidth(false));
            GUILayout.EndHorizontal();


            GUILayout.BeginHorizontal();
            GUILayout.Label("Ignore Obstructions: ", GUILayout.ExpandWidth(false));
            settings.IgnoreObstructed = GUILayout.Toggle(settings.IgnoreObstructed, "", GUILayout.ExpandWidth(false));
            GUILayout.EndHorizontal();


            GUILayout.BeginHorizontal();
            GUILayout.Label("Ignore angle limits: ", GUILayout.ExpandWidth(false));
            settings.IgnoreAngleLimits = GUILayout.Toggle(settings.IgnoreAngleLimits, "", GUILayout.ExpandWidth(false));
            GUILayout.EndHorizontal();
        }

        public static void OnSaveGUI(UnityModManager.ModEntry modEntry)
        {
            settings.Save(modEntry);
        }

        public static bool enabled;
        public static UnityModManager.ModEntry mod;
        public static SailCollisionFixSettings settings;
    }
}
