using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace _7d2dCheat
{
    internal class main : MonoBehaviour
    {
        #region Variables

        public static main Instance { get; private set; }

        #endregion Variables

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            #region basic cheats

            if (global.IsWorldPresent() && global.player != null)
            {
                global.player.DebugDismembermentChance = global.dismemberment;
                if (global.infHealth)
                {
                    global.player.Stats.Health.Value = global.player.Stats.Health.Max;
                }
                if (global.infStamina)
                {
                    global.player.Stats.Stamina.Value = global.player.Stats.Health.Max;
                }
                if (global.infFood)
                {
                    global.player.Stats.Food.Value = global.player.Stats.Food.Max;
                }
                if (global.infWater)
                {
                    global.player.Stats.Water.Value = global.player.Stats.Water.Max;
                }
                global.actionAttack = global.inventory.GetHoldingGun();
                if (global.actionAttack != null)
                {
                    global.actionAttack.InfiniteAmmo = global.infAmmo;
                }
            }

            #endregion basic cheats
        }
    }
}