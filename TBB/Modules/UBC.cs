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

namespace TBB
{
    class UBC
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
            RoguePatcher patcher = new RoguePatcher(Main.MainInstance, typeof(UBC));
            patcher.Postfix(typeof(Agent), nameof(Agent.SetupAgentStats), new Type[] { typeof(string)});
        }
        public static void Agent_SetupAgentStats(string transformationType, Agent __instance)
        {
            if (__instance.agentName == "RobotHelper")
            {
                __instance.SetStrength(0);
		        __instance.SetEndurance(0);
		        __instance.SetAccuracy(0);
		        __instance.SetSpeed(4);
		        __instance.inhuman = true;
		        __instance.preventsMindControl = true;
		        //__instance.statusEffects.AddTrait("");
		        __instance.statusEffects.AddStatusEffect("Invincible", 999);
		        __instance.AddDesire("Supplies");
		        __instance.AddDesire("Technology");
		        __instance.SetupSpecialInvDatabase();
                if (__instance.defaultGoal == string.Empty || __instance.defaultGoal == "None")
		        {
			        __instance.SetDefaultGoal(__instance.gc.Choose<string>("Guard", "CuriousObject", new string[0]));
		        }
                __instance.customCharacterData.facialHair = "None";
		        __instance.customCharacterData.legsColorName = "Black";
		        __instance.customCharacterData.bodyColorName = "Blue";
		        __instance.customCharacterData.eyesColorName = "Blue";
		        __instance.customCharacterData.skinColorName = "PaleSkin";
		        __instance.customCharacterData.startingHeadPiece = "Sunglasses";
		        __instance.agentHitboxScript.GetColorFromString(__instance.customCharacterData.bodyColorName, "Body");
		        __instance.agentHitboxScript.GetColorFromString(__instance.customCharacterData.legsColorName, "Legs");
		        __instance.agentHitboxScript.GetColorFromString(__instance.customCharacterData.eyesColorName, "Eyes");
		        __instance.inventory.startingHeadPiece = __instance.customCharacterData.startingHeadPiece;
		        __instance.agentHitboxScript.skinColorName = __instance.customCharacterData.skinColorName;
		        __instance.agentHitboxScript.GetColorFromString(__instance.customCharacterData.skinColorName, "Skin");           
		        if (!__instance.gc.serverPlayer && __instance.localPlayer)
		        {
			        __instance.oma.skinColor = __instance.oma.convertColorToInt("X");
		        }
                __instance.agentHitboxScript.SetUsesNewHead();
		        __instance.agentHitboxScript.SetCantShowHairUnderHeadPiece();
		        __instance.agentCategories.Clear();
		        __instance.agentCategories.Add("Trade");
		        __instance.agentCategories.Add("Food");
		        __instance.health = __instance.healthMax;
		        __instance.setInitialCategories = true;            
                __instance.agentActive = true;
		        __instance.SetBrainActive(true);
                __instance.preventsMindControl = true;











               
                        
            }
        }
    }
}