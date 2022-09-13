using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static vp_Message;

namespace _7d2dCheat
{
    internal class gui : MonoBehaviour
    {
        #region Variables

        private Rect rMainWindow;
        private bool showingMainWindow = false;
        private Rect rProgressionWindow;
        private bool showingProgression = false;
        private Vector2 scrollPosition;

        public static gui Instance { get; private set; }

        #endregion Variables

        private void Start()
        {
            rMainWindow.x = 300;
            rMainWindow.y = 20;
            rProgressionWindow.x = 480;
            rProgressionWindow.y = 20;
        }

        private void MainWindow(int windowID)
        {
            GUI.DragWindow(new Rect(0, 0, 10000, 20));
            GUILayout.Label("ESP");
            global.espBox = GUILayout.Toggle(global.espBox, "ESP Box");
            global.espBones = GUILayout.Toggle(global.espBones, "ESP Bones");
            global.espName = GUILayout.Toggle(global.espName, "ESP Name");
            global.showZombieEsp = GUILayout.Toggle(global.showZombieEsp, "Zombie ESP");
            global.showAnimalEsp = GUILayout.Toggle(global.showAnimalEsp, "Animal ESP");
            GUILayout.Space(10);
            GUILayout.Label("Player");
            global.infStamina = GUILayout.Toggle(global.infStamina, "Infinite Stamina");
            global.infHealth = GUILayout.Toggle(global.infHealth, "Infinite Health");
            global.infFood = GUILayout.Toggle(global.infFood, "Infinite Food");
            global.infWater = GUILayout.Toggle(global.infWater, "Infinite Water");
            showingProgression = GUILayout.Toggle(showingProgression, "showingProgression");
            GUILayout.Space(10);
            GUILayout.Label("Weapons");
            global.recoil = GUILayout.Toggle(global.recoil, "No Recoil");
            global.infAmmo = GUILayout.Toggle(global.infAmmo, "Infinite Ammo");
        }

        private void ProgressionWindow(int windowID)
        {
            GUI.DragWindow(new Rect(0, 0, 10000, 20));
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(rMainWindow.width + 20), GUILayout.Height(rMainWindow.height));

            foreach (var a in global.player.Progression.ProgressionValues.Dict.ToArray())
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(a.Value.Name);
                GUILayout.FlexibleSpace();
                a.Value.Level = int.Parse(GUILayout.TextField(a.Value.Level.ToString()));
                GUILayout.EndHorizontal();
            }

            GUILayout.EndScrollView();
        }

        private void OnGUI()
        {
            if (showingMainWindow)
            {
                rMainWindow = GUILayout.Window(0, rMainWindow, MainWindow, "Main Menu");
                if (showingProgression)
                {
                    rProgressionWindow = GUILayout.Window(1, rProgressionWindow, ProgressionWindow, "Progression Menu");
                }
            }
            render.DrawCircle(new Vector2((float)Screen.width / 2, (float)Screen.height / 2), 150, Color.cyan, 3, 4);
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