using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7d2dCheat
{
    internal class patches
    {
        /*/
         * Patch for anti recoil
         * Class name: EntityPlayerLocal
         * Method name: OnFired
        /*/

        [HarmonyPatch(typeof(EntityPlayerLocal), nameof(EntityPlayerLocal.OnFired))]
        private static class EntityPlayerLocal_OnFired
        {
            [HarmonyPrefix]
            private static bool Prefix(EntityPlayerLocal __instance)
            {
                if (global.recoil)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}