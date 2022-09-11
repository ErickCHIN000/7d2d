using HarmonyLib;

namespace _7d2dDev
{
    internal class patches
    {
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

        /*[HarmonyPatch(typeof(EntityPlayerLocal), "shakeCamera")]
        private static class EntityPlayerLocal_shakeCamera
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
        }*/
    }
}