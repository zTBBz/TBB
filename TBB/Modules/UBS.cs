using System;
using System.Linq;
using BepInEx;
using RogueLibsCore;
using UnityEngine;
using HarmonyLib;
using System.Reflection.Emit;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Reflection;
using BepInEx.Logging;

namespace TBB
{
    class UBS
    {
		/*public static List<ItemUnlock> Items = new List<ItemUnlock>();
		public static void SetActive(bool isEnabled)
		{
			foreach (ItemUnlock unlock in Items.Where(i => i != null))
			{
				unlock.IsAvailable = isEnabled;
				unlock.IsAvailableInCC = isEnabled;
				unlock.IsAvailableInItemTeleporter = isEnabled;
			}
		}*/
		public void Awake()
        {
            RoguePatcher patcher = new RoguePatcher(Main.MainInstance, typeof(UBS));
            patcher.Postfix(typeof(Agent), nameof(Agent.SetupAgentStats), new Type[] { typeof(string)});
			patcher.Postfix(typeof(LoadLevel), nameof(LoadLevel.SetupMore4), null);

			FirstNames = Properties.Resources.BotsFirstNames.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
			TwoNames = Properties.Resources.BotsTwoNames.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
			RareNames = Properties.Resources.BotsRareNames.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
		}
		public static string[] FirstNames;
		public static string[] TwoNames;
		public static string[] RareNames;

		private static System.Random rnd = new System.Random();
		public static string SelectFirstName() => FirstNames[rnd.Next(FirstNames.Length)];
		public static string SelectTwoName() => TwoNames[rnd.Next(TwoNames.Length)];
		public static string SelectRareName() => RareNames[rnd.Next(RareNames.Length)];
		public static void Agent_SetupAgentStats(string transformationType, Agent __instance)
        {
            if (__instance.agentName == "RobotHelper")
            {
                __instance.SetStrength(0);
		        __instance.SetEndurance(0);
		        __instance.SetAccuracy(0);
		        __instance.SetSpeed(4);
		        __instance.inhuman = false;
		        __instance.preventsMindControl = true;
		        __instance.statusEffects.AddTrait("AttacksOneDamage");
		        __instance.statusEffects.AddStatusEffect("Invincible", 999);
		        __instance.AddDesire("Supplies");
		        __instance.AddDesire("Technology");
		        __instance.SetupSpecialInvDatabase();
                if (__instance.defaultGoal == string.Empty || __instance.defaultGoal == "None")
		        {
					__instance.SetDefaultGoal("RobotFollow");
					//__instance.SetDefaultGoal(__instance.gc.Choose<string>("Guard", "CuriousObject", new string[0]));
		        }
                __instance.customCharacterData.facialHair = "None";
		        __instance.customCharacterData.legsColorName = "Grey";
		        //__instance.customCharacterData.bodyColorName = "Green";
		        //__instance.customCharacterData.bodyType = "CopBotS";
				__instance.customCharacterData.hairType = "CopBotHead";
				//__instance.customCharacterData.skinColorName = "PaleSkin";
				//__instance.customCharacterData.bodyColorName = "Body";
				__instance.customCharacterData.bodyType = "CopBot";
				//__instance.agentHitboxScript.body = "CopBot";
				__instance.agentHitboxScript.MustRefresh();
				Main.Logger.LogWarning("1111111");
				/*__instance.agentHitboxScript.GetColorFromString(__instance.customCharacterData.bodyColorName, "Body");
		        __instance.agentHitboxScript.GetColorFromString(__instance.customCharacterData.legsColorName, "Legs");
		        __instance.agentHitboxScript.GetColorFromString(__instance.customCharacterData.eyesColorName, "Eyes");
				__instance.inventory.startingHeadPiece = __instance.customCharacterData.startingHeadPiece;
		        __instance.agentHitboxScript.skinColorName = __instance.customCharacterData.skinColorName;
		        __instance.agentHitboxScript.GetColorFromString(__instance.customCharacterData.skinColorName, "Skin");*/
				if (!__instance.gc.serverPlayer && __instance.localPlayer)
		        {
			        __instance.oma.skinColor = __instance.oma.convertColorToInt("X");
		        }
                //__instance.agentHitboxScript.SetUsesNewHead();
		        //__instance.agentHitboxScript.SetCantShowHairUnderHeadPiece();
		        __instance.agentCategories.Clear();
		        __instance.agentCategories.Add("Trade");
		        __instance.agentCategories.Add("Food");
		        __instance.health = __instance.healthMax;
		        __instance.setInitialCategories = true;            
                __instance.agentActive = true;
		        __instance.SetBrainActive(true);   
            }
        }
		public static void LoadLevel_SetupMore4(LoadLevel __instance, ref GameController ___gc)
		{
			for (int i = 0; i < ___gc.agentList.Count; i++)
			{
				Agent agent = ___gc.agentList[i];
				static char RandomLetter()
				{
					string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
					return alphabet[rnd.Next(alphabet.Length)];
				}
				int nameLength = UnityEngine.Random.Range(2, 4);
				char[] chars = new char[nameLength];
				for (int r = 0; r < nameLength; r++)
					chars[r] = RandomLetter();
				string robotname = new string(chars);
				int botint = UnityEngine.Random.Range(111, 1000);
				if (agent.agentName is "CopBot" or "ButlerBot" or "Robot" || agent.agentName is "RobotPlayer" && ___gc.levelType == "HomeBase")
				{
					agent.agentRealName = robotname+ "-" + botint;
				}
				else if (rnd.Next(100) == 0) // 1%
				{
					agent.agentRealName = SelectRareName();
				}
				else
				{
					agent.agentRealName = SelectFirstName() + " " + SelectTwoName();
				}
			}
			if (___gc.levelType != "HomeBase" && ___gc.levelType != "Tutorial")
            {
				//___gc.spawnerMain.SpawnAgent(___gc.elevatorDown.curPosition, null, "RobotHelper");
			}
		}

	}
}