using System.Collections.Generic;
using UnityEngine;

namespace _7d2dDev
{
    internal class global : MonoBehaviour
    {
        public static global Instance { get; private set; }

        public static bool infStamina = true;
        public static bool infHealth = false;
        public static bool infFood = false;
        public static bool infWater = false;
        public static bool dismemberment = true;

        public static bool showZombieEsp = false;
        public static bool showAnimalEsp = false;

        public static List<Entity> Entities;
        public static GameManager gameManager = GameManager.Instance;
        public static EntityPlayerLocal player;

        public static bool WorldLoaded()
        {
            if (gameManager.World != null) return true;
            return false;
        }

        private void Update()
        {
            if (WorldLoaded())
            {
                Entities = GameManager.Instance.World.Entities.list;
                player = gameManager.World.GetPrimaryPlayer();
            }
        }
    }
}