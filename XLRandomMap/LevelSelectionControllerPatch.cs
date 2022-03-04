using System;
using HarmonyLib;

namespace XLRandomMap
{
    public static class LevelSelectionControllerPatch
    {
        [HarmonyPatch(typeof(LevelSelectionController), "Update")]
        public static class UpdatePatch
        {
            static void Postfix(LevelSelectionController __instance)
            {
                var player = PlayerController.Instance.inputController.player;

                if (!player.GetButtonDown("X")) return;

                var random = new Random();
                var index = random.Next(LevelManager.Instance.ModLevels.Count);

                LevelManager.Instance.PlayLevel(LevelManager.Instance.ModLevels[index]);
            }
        }
    }
}
