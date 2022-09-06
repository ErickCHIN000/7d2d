using System;
using UnityEngine;

namespace _7d2dDev
{
    internal class main : MonoBehaviour
    {
        #region Variables
        public static bool debug = false;
        public static main Instance { get; private set; }
        public GameManager gameManager;
        public EntityPlayerLocal player;
        UILabel versionLabel;
        #endregion

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            try
            {
                #region change Version
                if (versionLabel == null)
                {
                    if (versionLabel = GameObject.Find("UIRoot/GUI(Menu)/NGUI Camera/AnchorCenterCenter/lblVersion").GetComponent<UILabel>())
                    {
                        versionLabel.text = "modded";
                        versionLabel.color = Color.red;
                    }
                }
                #endregion

                #region check if null
                if (gameManager == null)
                {
                    gameManager = GameManager.Instance;
                }
                if (player == null)
                {
                    player = gameManager.World.GetPrimaryPlayer();
                }
                #endregion

                #region basic cheats
                if (player)
                {
                    player.DebugDismembermentChance = true;
                }
                #endregion
            }
            catch (Exception Ex) 
            {
                if(debug) Debug.LogException(Ex);
            }
        }
    }
}
