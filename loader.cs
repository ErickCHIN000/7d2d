using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
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
        #endregion

        #region Variables
        private GameObject mb;
        #endregion

        private void Start()
        {
            mb = new GameObject(GUID);
            mb.AddComponent<main>();
            mb.AddComponent<gui>();
            mb.AddComponent<esp>();
            DontDestroyOnLoad(mb);
        }

        private void OnDestroy()
        {
            Destroy(mb);
        }

        /*private void OnGUI()
        {
            GUILayout.Label("ASDFGHJKL");
        }*/
    }
}
