using BepInEx;
using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace _7d2dDev
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class loader : BaseUnityPlugin
    {
        #region plugin info

        private const string GUID = "chichi.7d2d.dev";
        private const string NAME = "Example Plugin (ChiChi)";
        private const string VERSION = "1.0.0";

        #endregion plugin info

        #region Variables

        public static GameObject mb = new GameObject(GUID);
        private Assembly assembly = Assembly.GetExecutingAssembly();
        private Harmony harmony = new Harmony(GUID);

        #endregion Variables

        private void OnDestroy()
        {
            harmony.UnpatchSelf();
            Destroy(mb);
        }

        private void Awake()
        {
            Harmony.CreateAndPatchAll(assembly);
        }

        private void Start()
        {
            mb.AddComponent<main>();
            mb.AddComponent<gui>();
            mb.AddComponent<esp>();
            DontDestroyOnLoad(mb);
        }

        private void Update()
        {
            if (global.IsWorldPresent())
            {
                global.UpdateGlobal();
            }
        }
    }
}