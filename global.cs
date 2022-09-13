using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7d2dCheat
{
    internal class global
    {
        public static bool dismemberment = true;
        public static bool espBones = true;
        public static bool espBox = false;
        public static bool infAmmo = true;
        public static bool infFood = true;
        public static bool infHealth = true;
        public static bool infStamina = true;
        public static bool infWater = true;
        public static bool recoil = true;
        public static bool showAnimalEsp = false;
        public static bool showZombieEsp = false;
        public static bool aim = true;

        public static bool isLoaded = GameManager.Instance.gameStateManager.IsGameStarted();

        public static List<Entity> Entities;
        public static GameManager gameManager;
        public static EntityPlayerLocal player;
        public static Inventory inventory;
        public static ItemActionAttack actionAttack;
        public static bool espName = false;

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
            if (player != null)
            {
                inventory = player.inventory;
            }
        }
    }
}