using System;
using System.Linq;
using HarmonyLib;

namespace XLRandomMap
{
    public static class LevelSelectionControllerPatch
    {
        [HarmonyPatch(typeof(LevelSelectionController), "Update")]
        public static class UpdatePatch
        {
            static void Postfix()
            {
                var player = PlayerController.Instance.inputController.player;

                if (!player.GetButtonDown("X")) return;

                var easyDayLevels = LevelManager.Instance.CommunityLevels.Concat(LevelManager.Instance.Levels);
                var levels = LevelManager.Instance.ModLevels.Concat(easyDayLevels).ToList();

                var index = new Random().Next(levels.Count);

                UISounds.Instance?.PlayOneShotSelectMajor();
                LevelManager.Instance.PlayLevel(levels[index]);
            }
        }
    }
}
