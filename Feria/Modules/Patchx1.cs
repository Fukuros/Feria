using System.Collections.Generic;
using System.Linq;
using System.Text;
using Harmony;
using UnityEngine;
using UnityEngine.UI;

namespace Feria.Modules
{
    class Patchx1
    {

        [HarmonyPatch(typeof(GameScript), "GameServerSentChatMessage")]
        public static class chatpatch
        {
          

            // Token: 0x0600008D RID: 141 RVA: 0x00007738 File Offset: 0x00005938
            private static bool Prefix(short playerID, string message, bool wasTeam, bool isAction, bool wasAntiSpamWarning, bool wasRoll ,GameScript __instance, StringBuilder ___stringBuilderForChatMessage, Dictionary<short,GameObject> ___allPlayerSprites,List<string> ___chatFeedStrings,Text ___textChatFeed, float ___chatFeedClearTime)
            {
                
             if (!___allPlayerSprites.ContainsKey(playerID))
                {
                    return false;
                }
                if (!wasAntiSpamWarning)
                {
                    if (!wasTeam)
                    {
                        if (PlayerPrefs.HasKey("SHOW_CHAT") && PlayerPrefs.GetInt("SHOW_CHAT") == 0)
                        {
                            return false;
                        }
                    }
                    else if (PlayerPrefs.HasKey("SHOW_TEAM_CHAT") && PlayerPrefs.GetInt("SHOW_TEAM_CHAT") == 0)
                    {
                        return false;
                    }
              
                }
                string text = message;
                if (message.Length >= 30 && (!wasAntiSpamWarning || (wasAntiSpamWarning && wasRoll)))
                {
                    int num = -1;
                    if (message.Contains(' '))
                    {
                        for (int i = 0; i < message.Length; i++)
                        {
                            if (message[i].Equals(' '))
                            {
                                num = i;
                            }
                            if (i >= 30)
                            {
                                break;
                            }
                        }
                    }
                   ___stringBuilderForChatMessage.Length = 0;
                   ___stringBuilderForChatMessage.Capacity = 0;
                    if (num >= 0)
                    {
                        ___stringBuilderForChatMessage.Append(message.Substring(0, num + 1));
                        ___stringBuilderForChatMessage.Append('\n');
                        ___stringBuilderForChatMessage.Append(message.Substring(num + 1, message.Length - (num + 1)));
                        text = ___stringBuilderForChatMessage.ToString();
                    }
                    else
                    {
                        ___stringBuilderForChatMessage.Append(message.Substring(0, 30));
                        ___stringBuilderForChatMessage.Append('\n');
                        ___stringBuilderForChatMessage.Append(message.Substring(30, message.Length - 30));
                        text = ___stringBuilderForChatMessage.ToString();
                    }
                }
                GameObject gameObject = ___allPlayerSprites[playerID];
                GamePlayerNetworked component = gameObject.GetComponent<GamePlayerNetworked>();
                if (!component.playerIsDead && !component.inFlight && !isAction && (!wasAntiSpamWarning || (wasAntiSpamWarning && wasRoll)))
                {
                    GameObject gameObject2 = component.chatBubble;
                    GameObject original = ResourceLoadManager.preloadedAssets["Prefabs/PlayerChatText"] as GameObject;
                    Color color = new Color(0.17f, 0.2f, 0.19f, 0.9f);
                    Color color2 = new Color(1f, 1f, 1f, 0.88f);
                    Color color3 = new Color(0.21f, 0.21f, 0.21f, 1f);
                    if (gameObject2 == null)
                    {
                        gameObject2 = UnityEngine.Object.Instantiate<GameObject>(original);
                        component.chatBubble = gameObject2;
                        Renderer component2 = gameObject2.GetComponent<Renderer>();
                        component2.sortingLayerName = "Chat";
                        component2.sortingOrder = 1;
                        GameObject chatBubbleBG = UnityEngine.Object.Instantiate<GameObject>(ResourceLoadManager.preloadedAssets["Prefabs/PlayerChatBG"] as GameObject);
                        component.chatBubbleBG = chatBubbleBG;
                    }
                    else if ((wasTeam && component.chatBubbleBG.GetComponent<SpriteRenderer>().color.a >= 0.9f) || (!wasTeam && component.chatBubbleBG.GetComponent<SpriteRenderer>().color.a < 0.9f))
                    {
                        string text2 = gameObject2.GetComponent<TextMesh>().text;
                        int num2 = text2.Count((char f) => f == '\n');
                        if (num2 <= 1)
                        {
                            ___stringBuilderForChatMessage.Length = 0;
                            ___stringBuilderForChatMessage.Capacity = 0;
                            ___stringBuilderForChatMessage.Append(text2).Append('\n').Append(text);
                            text = ___stringBuilderForChatMessage.ToString();
                        }
                    }
                    TextMesh component3 = gameObject2.GetComponent<TextMesh>();
                    if (wasTeam)
                    {
                        component.chatBubbleBG.GetComponent<SpriteRenderer>().color = color;
                        component.chatBubbleBG.transform.GetChild(0).GetComponent<SpriteRenderer>().color = color;
                        component3.color = new Color(0.41f, 0.93f, 0.86f, 1f) ;
                    }
                    else
                    {
                        component.chatBubbleBG.GetComponent<SpriteRenderer>().color = color2;
                        component.chatBubbleBG.transform.GetChild(0).GetComponent<SpriteRenderer>().color = color2;
                        component3.color = new Color(0.21f, 0.21f, 0.21f, 1f); 
                    }
                    component3.text = text;
                    component.timeUntilChatBubbleIsRemoved = Time.time + 1.85f + 0.11f * (float)Mathf.Min(message.Length, 30);
                }
                if (wasTeam)
                {
                   
                }
                else if (!component.playerIsDead && !component.inFlight && !isAction && !wasAntiSpamWarning)
                {
                    component.PlayChatSound();
                }
                Vector2 a = Camera.main.ScreenToWorldPoint(new Vector2(0f, (float)Screen.height));
                Vector2 a2 = Camera.main.ScreenToWorldPoint(new Vector2((float)Screen.width, 0f));
                Vector2 vector = a + new Vector2(-50f, 100f);
                Vector2 vector2 = a2 + new Vector2(50f, -100f);
                Vector2 vector3 = gameObject.transform.localPosition;
                bool flag = false;
               if (wasAntiSpamWarning && !wasRoll)
                {
                    flag = true;
                }
                else if (!wasTeam)
                {
                    if (vector3.x >= vector.x && vector3.x <= vector2.x && vector3.y >= vector2.y && vector3.y <= vector.y)
                    {
                        flag = true;
                    }
                }
                else
                {
                    flag = true;
                }
                if (flag)
                {
                    ___stringBuilderForChatMessage.Length = 0;
                    ___stringBuilderForChatMessage.Capacity = 0;
                    string text3 = component.playerName;
                    if (text3.Length > 25)
                    {
                        text3 = text3.Substring(0, 25);
                    }
                    if (!wasAntiSpamWarning)
                    {
                        if (wasTeam)
                        {
                            ___stringBuilderForChatMessage.Append("<color=#68eddd>");
                        }
                        else if (component.isUsingCustomNameColor.a > 0f)
                        {
                            ___stringBuilderForChatMessage.Append("<color=#" + ColorUtility.ToHtmlStringRGB(component.isUsingCustomNameColor) + ">");
                        }
                        ___stringBuilderForChatMessage.Append("<b>[");
                        ___stringBuilderForChatMessage.Append(text3);
                        if (!isAction)
                        {
                            ___stringBuilderForChatMessage.Append("]</b>: ");
                        }
                        else
                        {
                            ___stringBuilderForChatMessage.Append("]</b> ");
                        }
                        if (!wasTeam && component.isUsingCustomNameColor.a > 0f)
                        {
                            ___stringBuilderForChatMessage.Append("</color>");
                        }
                        ___stringBuilderForChatMessage.Append(message);
                        if (wasTeam)
                        {
                            ___stringBuilderForChatMessage.Append("</color>");
                        }
                    }
                    else
                    {
                        ___stringBuilderForChatMessage.Append("<color=#ffe6ff>");
                        if (message == "Too many messages. Try again shortly.")
                        {
                            message = LocalizationManager.GetTranslationForKey("InGameUI.ChatSpam");
                        }
                        else if (message == "Warning: inappropriate message. You can lose your chat privileges by typing offensive language.")
                        {
                            message = LocalizationManager.GetTranslationForKey("InGameUI.ChatWarning");
                        }
                        else if (message == "Warning: inappropriate message. You have lost your chat privileges for 24 hours.")
                        {
                            message = LocalizationManager.GetTranslationForKey("InGameUI.ChatBanned");
                        }
                        else if (message == "Your chat is currently timed out due to repeat violations.")
                        {
                            message = LocalizationManager.GetTranslationForKey("InGameUI.ChatTimeout");
                        }
                        ___stringBuilderForChatMessage.Append(message);
                        ___stringBuilderForChatMessage.Append("</color>");
                    }
                    ___chatFeedStrings.Add(___stringBuilderForChatMessage.ToString());
                    if (___chatFeedStrings.Count > 6)
                    {
                        ___chatFeedStrings.RemoveAt(0);
                    }
                    ___stringBuilderForChatMessage.Length = 0;
                    ___stringBuilderForChatMessage.Capacity = 0;
                    foreach (string value in ___chatFeedStrings)
                    {
                        ___stringBuilderForChatMessage.Append('\n').Append(value);
                    }
                    ___textChatFeed.text = ___stringBuilderForChatMessage.ToString();
                    ___textChatFeed.GetComponent<CanvasGroup>().alpha = 1f;
                    ___chatFeedClearTime = Time.time + 7f;
                   
                }
                return false;
            }

        }
    }
}
