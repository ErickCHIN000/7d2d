using UnityEngine;

namespace _7d2dDev
{
    internal class gui : MonoBehaviour
    {
        #region Variables

        private Rect rMainWindow;
        private bool showingMainWindow = false;
        public static gui Instance { get; private set; }

        #endregion Variables

        private void Start()
        {
            rMainWindow.x = 20;
            rMainWindow.y = 200;
        }

        private void MainWindow(int windowID)
        {
            if (global.WorldLoaded())
            {
                GUI.DragWindow(new Rect(0, 0, 10000, 20));
                GUILayout.Label("ESP");
                if (GUILayout.Button($"Zombie ESP: {global.showZombieEsp}"))
                {
                    global.showZombieEsp = !global.showZombieEsp;
                }
                if (GUILayout.Button($"Animal ESP: {global.showAnimalEsp}"))
                {
                    global.showAnimalEsp = !global.showAnimalEsp;
                }
                GUILayout.Space(10);
                GUILayout.Label("Player");
                if (GUILayout.Button($"Inf Health: {global.infHealth}"))
                {
                    global.infHealth = !global.infHealth;
                }
                if (GUILayout.Button($"Inf Stamina: {global.infStamina}"))
                {
                    global.infStamina = !global.infStamina;
                }
                if (GUILayout.Button($"Inf Food: {global.infFood}"))
                {
                    global.infFood = !global.infFood;
                }
                if (GUILayout.Button($"Inf Water: {global.infWater}"))
                {
                    global.infWater = !global.infWater;
                }
                if (GUILayout.Button($"Dismemberment: {global.dismemberment}"))
                {
                    global.dismemberment = !global.dismemberment;
                }
            }
        }

        private void OnGUI()
        {
            if (showingMainWindow)
            {
                rMainWindow = GUILayout.Window(0, rMainWindow, MainWindow, "Main Menu");
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                showingMainWindow = !showingMainWindow;
            }
        }
    }
}