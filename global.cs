using System.Collections.Generic;
using UnityEngine;

namespace _7d2dDev
{
    internal class global
    {
        public static bool infStamina = true;
        public static bool infHealth = true;
        public static bool infFood = true;
        public static bool infWater = true;
        public static bool dismemberment = true;
        public static bool recoil = true;
        public static bool showZombieEsp = true;
        public static bool showAnimalEsp = true;

        public static List<Entity> Entities;
        public static GameManager gameManager;
        public static EntityPlayerLocal player;

        public static bool IsWorldPresent()
        {
            if (GameManager.Instance == null)
            {
                return false;
            }
            if (GameManager.Instance.World == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void UpdateGlobal()
        {
            gameManager = GameManager.Instance;
            Entities = GameManager.Instance.World.Entities.list;
            player = GameManager.Instance.World.GetPrimaryPlayer();
        }
    }
}