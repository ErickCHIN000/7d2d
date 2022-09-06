using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace _7d2dDev
{
    internal class gui : MonoBehaviour
    {
        #region Variables
        public static gui Instance { get; private set; }
        private Rect rMainWindow = new Rect(20,20,Screen.width / 5,Screen.height / 2);
        bool showingMainWindow = false;
        #endregion



        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Insert))
            {
                showingMainWindow = !showingMainWindow;
            }
        }

        private void OnGUI()
        {
            if (showingMainWindow)
            {
                rMainWindow = GUILayout.Window(0, rMainWindow, MainWindow, "Main Menu");
            }
        }

        private void MainWindow(int windowID)
        {
            if (main.Instance.gameManager.World != null)
            {
                GUI.DragWindow(new Rect(0, 0, 10000, 20));
                GUILayout.Label("Example Label!!!");
                /*foreach (GameObject enemy in main.Instance.enemies)
                {
                    GUILayout.Label($"Name: {enemy.name}\nPosition: {enemy.transform.position}");
                    GUILayout.Label($"Position: {enemy.transform.position}");
                    GUILayout.Space(20f);
                }*/
            }
        } // this is causing the problem

    }
}
