using System;
using System.CodeDom;
using System.Text;
using Harmony;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Feria.Modules
{

    static class gamestartpatch1
    {
        static void Postfix(MainMenuScript __instance, bool ___hasFinishedSettingResolution)
        {
            try
            {
                var flag = true;
                if (!__instance.mainPanel.activeInHierarchy || __instance.disconnectedPanel.activeSelf ||
                    __instance.warningPanel.activeSelf || __instance.steamFailedPanel.activeSelf ||
                    __instance.quitPanel.activeSelf || __instance.demoUpgradePanel.activeSelf ||
                    __instance.itemRewardPanel.activeSelf || __instance.statsPanel.activeSelf ||
                    __instance.challengesPanel.activeSelf || __instance.couponCodePanel.activeSelf ||
                    __instance.firstTimePanel.activeSelf || __instance.rerollDailiesPanel.activeSelf ||
                    __instance.itemTradeUpDuplicatesPanel.activeSelf)
                {
                    flag = false;
                }
                if (flag && ___hasFinishedSettingResolution && __instance.playButton.interactable && GuiMenu.FollowBot)
                {
                    Console.WriteLine("Play Clicked.");
                    __instance.OnPlayClicked();
                    //__instance.GetType().GetMethod("PerformPlay", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(__instance, null);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}