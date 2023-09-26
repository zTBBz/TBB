using System;
using RogueLibsCore;
using UnityEngine;
using BepInEx.Logging;

namespace TBB
{
    public class UBS
    {
		public static new ManualLogSource Logger = null!;
		public void Awake()
        {
            RoguePatcher patcher = new RoguePatcher(Main.MainInstance, typeof(UBS));
            patcher.Postfix(typeof(Agent), nameof(Agent.SetupAgentStats), new Type[] { typeof(string)});
			patcher.Postfix(typeof(LoadLevel), nameof(LoadLevel.SetupMore4), null);
			patcher.Prefix(typeof(Movement), nameof(Movement.KnockBackBullet), new Type[4] { typeof(Quaternion), typeof(float), typeof(bool), typeof(PlayfieldObject) });
			patcher.Prefix(typeof(StatusEffects), nameof(StatusEffects.ExplodeAfterDeathChecks), null);

			FirstNames = Properties.Resources.BotsFirstNames.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
			TwoNames = Properties.Resources.BotsTwoNames.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
			RareNames = Properties.Resources.BotsRareNames.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
			CreateOctoSprite("Border_Bot_Broken", SpriteScope.Hair, Properties.Resources.Stalker_Bot, 64f, 64f);
			CreateOctoSprite("Border_Bot_Rusty", SpriteScope.Hair, Properties.Resources.Border_Bot_Rusty, 64f, 64f);
			CreateOctoSprite("Cutter_Bot1", SpriteScope.Hair, Properties.Resources.Cutter_Bot1, 64f, 64f);
			CreateOctoSprite("Cutter_Bot2", SpriteScope.Hair, Properties.Resources.Cutter_Bot2, 64f, 64f);
			CreateOctoSprite("Spidgren_Bot1", SpriteScope.Hair, Properties.Resources.Spidgren_Bot1, 64f, 64f);
			CreateOctoSprite("Spidgren_Bot2", SpriteScope.Hair, Properties.Resources.Spidgren_Bot2, 64f, 64f);
			CreateOctoSprite("Kamikaze_Bot", SpriteScope.Hair, Properties.Resources.Kamikaze_Bot, 64f, 64f);
			CreateOctoSprite("Flame_Bot", SpriteScope.Hair, Properties.Resources.Flame_Bot, 64f, 64f);
			CreateOctoSprite("MinotaurBot_Body", SpriteScope.Bodies, Properties.Resources.MinotaurBot_Body, 64f, 64f);
			CreateOctoSprite("MinotaurBot_Head", SpriteScope.Agents, Properties.Resources.MinotaurBot_Head, 64f, 64f);
			CreateOctoSprite("BullBot_Head", SpriteScope.Agents, Properties.Resources.BullBot_Head, 64f, 64f);
			CreateOctoSprite("BullBot_Body", SpriteScope.Bodies, Properties.Resources.BullBot_Body, 64f, 64f);
			CreateOctoSprite("Beelze_Bot", SpriteScope.Hair, Properties.Resources.BeelzeBot, 64f, 64f);
			CreateOctoSprite("Beelze_Drone", SpriteScope.Hair, Properties.Resources.BeelzeBotDrone, 64f, 64f);
			RogueLibs.CreateCustomName("Border_Bot_Broken", "Agent", new CustomNameInfo
			{
				English = "Broken BorderBot",
				Russian = "��������� ������-���",
			});
			RogueLibs.CreateCustomName("Border_Bot_Rusty", "Agent", new CustomNameInfo
			{
				English = "Rusty BorderBot",
				Russian = "������ ������-���",
			});
			RogueLibs.CreateCustomName("Cutter_Bot", "Agent", new CustomNameInfo
			{
				English = "CutterBot",
				Russian = "�����-���",
			});
			RogueLibs.CreateCustomName("Boom_Bot", "Agent", new CustomNameInfo
			{
				English = "BoomBot",
				Russian = "������-���",
			});
			RogueLibs.CreateCustomName("Spidgren_Bot", "Agent", new CustomNameInfo
			{
				English = "SpidgrenBot",
				Russian = "���������-���",
			});
		}
		public static string[] FirstNames;
		public static string[] TwoNames;
		public static string[] RareNames;
		public static int UBSNames = 1;
		public static int UBSBots1 = 1;
		public static RogueSprite[] CreateOctoSprite(string name, SpriteScope scope, byte[] rawData, float rectSize, float ppu = 64f)
		{
			Rect Area(int x, int y) => new Rect(x * rectSize, y * rectSize, rectSize, rectSize);

			return new RogueSprite[]
			{
				RogueLibs.CreateCustomSprite(name + "N", scope, rawData, Area(1, 2), ppu),
				RogueLibs.CreateCustomSprite(name + "NE", scope, rawData, Area(2, 2), ppu),
				RogueLibs.CreateCustomSprite(name + "E", scope, rawData, Area(2, 1), ppu),
				RogueLibs.CreateCustomSprite(name + "SE", scope, rawData, Area(2, 0), ppu),
				RogueLibs.CreateCustomSprite(name + "S", scope, rawData, Area(1, 0), ppu),
				RogueLibs.CreateCustomSprite(name + "SW", scope, rawData, Area(0, 0), ppu),
				RogueLibs.CreateCustomSprite(name + "W", scope, rawData, Area(0, 1), ppu),
				RogueLibs.CreateCustomSprite(name + "NW", scope, rawData, Area(0, 2), ppu),
			};
		}
		public static Sprite[] ConvertQuadraSprite(byte[] rawData, float rectSize, float ppu = 64f)
		{
			Rect Area(int x, int y) => new Rect(x * rectSize, y * rectSize, rectSize, rectSize);

			return new Sprite[]
			{
				RogueUtilities.ConvertToSprite(rawData, Area(0, 0), ppu),
				RogueUtilities.ConvertToSprite(rawData, Area(1, 0), ppu),
				RogueUtilities.ConvertToSprite(rawData, Area(0, 1), ppu),	
				RogueUtilities.ConvertToSprite(rawData, Area(1, 1), ppu),
			};
		}
		public class InvisibleHook : HookBase<PlayfieldObject>, IDoUpdate
		{
			protected override void Initialize() { }
			public void Update()
			{
				Agent agent = (Agent)Instance;
				agent.agentHitboxScript.heldItemH.SetSprite("Clear");
				agent.agentHitboxScript.heldItem2H.SetSprite("Clear");
				agent.agentHitboxScript.heldItemWB.SetSprite("Clear");
				agent.agentHitboxScript.heldItem.SetSprite("Clear");
				agent.agentHitboxScript.heldItem2.SetSprite("Clear");
				agent.agentHitboxScript.headH.SetSprite("Clear");
				agent.agentHitboxScript.head.SetSprite("Clear");
				agent.agentHitboxScript.headWB.SetSprite("Clear");
				agent.agentHitboxScript.headWBH.SetSprite("Clear");
				agent.agentHitboxScript.arm1H.SetSprite("Clear");
				agent.agentHitboxScript.arm2H.SetSprite("Clear");
				agent.agentHitboxScript.leg1H.SetSprite("Clear");
				agent.agentHitboxScript.leg2H.SetSprite("Clear");
				agent.agentHitboxScript.bodyH.SetSprite("Clear");
				agent.agentHitboxScript.bodyWB.SetSprite("Clear");
				agent.agentHitboxScript.bodyWBH.SetSprite("Clear");
				agent.agentHitboxScript.arm1WB.SetSprite("Clear");
				agent.agentHitboxScript.arm2WB.SetSprite("Clear");
				agent.agentHitboxScript.arm1WBH.SetSprite("Clear");
				agent.agentHitboxScript.arm2WBH.SetSprite("Clear");
				agent.agentHitboxScript.eyesWB.SetSprite("Clear");
				agent.agentHitboxScript.eyes.SetSprite("Clear");
				agent.agentHitboxScript.eyesH.SetSprite("Clear");
				agent.agentHitboxScript.facialHairWB.SetSprite("Clear");
				agent.agentHitboxScript.footwear1WB.SetSprite("Clear");
				agent.agentHitboxScript.footwear2WB.SetSprite("Clear");
				agent.agentHitboxScript.headPieceWB.SetSprite("Clear");
				agent.agentHitboxScript.headWB.SetSprite("Clear");
				agent.agentHitboxScript.leg1WB.SetSprite("Clear");
				agent.agentHitboxScript.leg2WB.SetSprite("Clear");
				agent.agentHitboxScript.leg1WBH.SetSprite("Clear");
				agent.agentHitboxScript.leg2WBH.SetSprite("Clear");
				agent.gun.gunSprite.SetSprite("Clear");
				agent.gun.arm1Sprite.SetSprite("Clear");
				agent.gun.arm2Sprite.SetSprite("Clear");
				agent.melee.arm1Sprite.SetSprite("Clear");
				agent.melee.arm2Sprite.SetSprite("Clear");
			}
		}
		public class Cutter_Bot_Hook : HookBase<PlayfieldObject>, IDoUpdate
		{
			protected override void Initialize() { }
			public void Update()
			{
				Agent agent = (Agent)Instance;
				int animIndex = (int)Math.Floor(Time.time * 8f % 2f);
				string direction = agent.playerDir;
				if (string.IsNullOrEmpty(direction)) direction = "S";
				string spriteName = $"Cutter_Bot{animIndex + 1}{direction}";
				agent.agentHitboxScript.hair.SetSprite(spriteName);
				agent.agentHitboxScript.heldItemH.SetSprite("Clear");
				agent.agentHitboxScript.heldItem2H.SetSprite("Clear");
				agent.agentHitboxScript.heldItemWB.SetSprite("Clear");
				agent.agentHitboxScript.heldItem.SetSprite("Clear");
				agent.agentHitboxScript.heldItem2.SetSprite("Clear");
				agent.agentHitboxScript.headH.SetSprite("Clear");
				agent.agentHitboxScript.head.SetSprite("Clear");
				agent.agentHitboxScript.headWB.SetSprite("Clear");
				agent.agentHitboxScript.headWBH.SetSprite("Clear");
				agent.agentHitboxScript.arm1H.SetSprite("Clear");
				agent.agentHitboxScript.arm2H.SetSprite("Clear");
				agent.agentHitboxScript.leg1H.SetSprite("Clear");
				agent.agentHitboxScript.leg2H.SetSprite("Clear");
				agent.agentHitboxScript.bodyH.SetSprite("Clear");
				agent.agentHitboxScript.bodyWB.SetSprite("Clear");
				agent.agentHitboxScript.bodyWBH.SetSprite("Clear");
				agent.agentHitboxScript.arm1WB.SetSprite("Clear");
				agent.agentHitboxScript.arm2WB.SetSprite("Clear");
				agent.agentHitboxScript.arm1WBH.SetSprite("Clear");
				agent.agentHitboxScript.arm2WBH.SetSprite("Clear");
				agent.agentHitboxScript.eyesWB.SetSprite("Clear");
				agent.agentHitboxScript.eyes.SetSprite("Clear");
				agent.agentHitboxScript.eyesH.SetSprite("Clear");
				agent.agentHitboxScript.facialHairWB.SetSprite("Clear");
				agent.agentHitboxScript.footwear1WB.SetSprite("Clear");
				agent.agentHitboxScript.footwear2WB.SetSprite("Clear");
				agent.agentHitboxScript.headPieceWB.SetSprite("Clear");
				agent.agentHitboxScript.headWB.SetSprite("Clear");
				agent.agentHitboxScript.leg1WB.SetSprite("Clear");
				agent.agentHitboxScript.leg2WB.SetSprite("Clear");
				agent.agentHitboxScript.leg1WBH.SetSprite("Clear");
				agent.agentHitboxScript.leg2WBH.SetSprite("Clear");
				agent.gun.gunSprite.SetSprite("Clear");
				agent.gun.arm1Sprite.SetSprite("Clear");
				agent.gun.arm2Sprite.SetSprite("Clear");
				agent.melee.arm1Sprite.SetSprite("Clear");
				agent.melee.arm2Sprite.SetSprite("Clear");
			}
		}
		public class Boom_Bot_Hook : HookBase<PlayfieldObject>, IDoUpdate
		{
			protected override void Initialize() { }
			private bool boomready = false;
			public void Update()
			{
				Agent agent = (Agent)Instance;
				agent.agentHitboxScript.heldItemH.SetSprite("Clear");
				agent.agentHitboxScript.heldItem2H.SetSprite("Clear");
				agent.agentHitboxScript.heldItemWB.SetSprite("Clear");
				agent.agentHitboxScript.heldItem.SetSprite("Clear");
				agent.agentHitboxScript.heldItem2.SetSprite("Clear");
				agent.agentHitboxScript.headH.SetSprite("Clear");
				agent.agentHitboxScript.head.SetSprite("Clear");
				agent.agentHitboxScript.headWB.SetSprite("Clear");
				agent.agentHitboxScript.headWBH.SetSprite("Clear");
				agent.agentHitboxScript.arm1H.SetSprite("Clear");
				agent.agentHitboxScript.arm2H.SetSprite("Clear");
				agent.agentHitboxScript.leg1H.SetSprite("Clear");
				agent.agentHitboxScript.leg2H.SetSprite("Clear");
				agent.agentHitboxScript.bodyH.SetSprite("Clear");
				agent.agentHitboxScript.bodyWB.SetSprite("Clear");
				agent.agentHitboxScript.bodyWBH.SetSprite("Clear");
				agent.agentHitboxScript.arm1WB.SetSprite("Clear");
				agent.agentHitboxScript.arm2WB.SetSprite("Clear");
				agent.agentHitboxScript.arm1WBH.SetSprite("Clear");
				agent.agentHitboxScript.arm2WBH.SetSprite("Clear");
				agent.agentHitboxScript.eyesWB.SetSprite("Clear");
				agent.agentHitboxScript.eyes.SetSprite("Clear");
				agent.agentHitboxScript.eyesH.SetSprite("Clear");
				agent.agentHitboxScript.facialHairWB.SetSprite("Clear");
				agent.agentHitboxScript.footwear1WB.SetSprite("Clear");
				agent.agentHitboxScript.footwear2WB.SetSprite("Clear");
				agent.agentHitboxScript.headPieceWB.SetSprite("Clear");
				agent.agentHitboxScript.headWB.SetSprite("Clear");
				agent.agentHitboxScript.leg1WB.SetSprite("Clear");
				agent.agentHitboxScript.leg2WB.SetSprite("Clear");
				agent.agentHitboxScript.leg1WBH.SetSprite("Clear");
				agent.agentHitboxScript.leg2WBH.SetSprite("Clear");
				agent.gun.gunSprite.SetSprite("Clear");
				agent.gun.arm1Sprite.SetSprite("Clear");
				agent.gun.arm2Sprite.SetSprite("Clear");
				agent.melee.arm1Sprite.SetSprite("Clear");
				agent.melee.arm2Sprite.SetSprite("Clear");
				if (agent.opponent == null) return;
				float dist = Vector3.Distance(agent.opponent.transform.position, agent.transform.position);
				if (dist < 0.64 && boomready == false)
				{
					agent.gc.spawnerMain.SpawnExplosion(agent, agent.tr.position, "Normal", false, -1, false, true);
					boomready = true;
					agent.statusEffects.Disappear();
				}
			}
		}
		public class BeelzeBot_Hook : HookBase<PlayfieldObject>, IDoUpdate
		{
			protected override void Initialize() { }
			private bool boomready = false;
			public void Update()
			{
				Agent agent = (Agent)Instance;
				agent.agentHitboxScript.heldItemH.SetSprite("Clear");
				agent.agentHitboxScript.heldItem2H.SetSprite("Clear");
				agent.agentHitboxScript.heldItemWB.SetSprite("Clear");
				agent.agentHitboxScript.heldItem.SetSprite("Clear");
				agent.agentHitboxScript.heldItem2.SetSprite("Clear");
				agent.agentHitboxScript.headH.SetSprite("Clear");
				agent.agentHitboxScript.head.SetSprite("Clear");
				agent.agentHitboxScript.headWB.SetSprite("Clear");
				agent.agentHitboxScript.headWBH.SetSprite("Clear");
				agent.agentHitboxScript.arm1H.SetSprite("Clear");
				agent.agentHitboxScript.arm2H.SetSprite("Clear");
				agent.agentHitboxScript.leg1H.SetSprite("Clear");
				agent.agentHitboxScript.leg2H.SetSprite("Clear");
				agent.agentHitboxScript.bodyH.SetSprite("Clear");
				agent.agentHitboxScript.bodyWB.SetSprite("Clear");
				agent.agentHitboxScript.bodyWBH.SetSprite("Clear");
				agent.agentHitboxScript.arm1WB.SetSprite("Clear");
				agent.agentHitboxScript.arm2WB.SetSprite("Clear");
				agent.agentHitboxScript.arm1WBH.SetSprite("Clear");
				agent.agentHitboxScript.arm2WBH.SetSprite("Clear");
				agent.agentHitboxScript.eyesWB.SetSprite("Clear");
				agent.agentHitboxScript.eyes.SetSprite("Clear");
				agent.agentHitboxScript.eyesH.SetSprite("Clear");
				agent.agentHitboxScript.facialHairWB.SetSprite("Clear");
				agent.agentHitboxScript.footwear1WB.SetSprite("Clear");
				agent.agentHitboxScript.footwear2WB.SetSprite("Clear");
				agent.agentHitboxScript.headPieceWB.SetSprite("Clear");
				agent.agentHitboxScript.headWB.SetSprite("Clear");
				agent.agentHitboxScript.leg1WB.SetSprite("Clear");
				agent.agentHitboxScript.leg2WB.SetSprite("Clear");
				agent.agentHitboxScript.leg1WBH.SetSprite("Clear");
				agent.agentHitboxScript.leg2WBH.SetSprite("Clear");
				agent.gun.gunSprite.SetSprite("Clear");
				agent.gun.arm1Sprite.SetSprite("Clear");
				agent.gun.arm2Sprite.SetSprite("Clear");
				agent.melee.arm1Sprite.SetSprite("Clear");
				agent.melee.arm2Sprite.SetSprite("Clear");
				if (agent.opponent == null) { }
				else
                {
					agent.gc.spawnerMain.SpawnAgent(agent.tr.position, null, "Beelze_Drone");
					boomready = true;
				}
			}
		}
		public class Bull_Bot_Hook : HookBase<PlayfieldObject>, IDoUpdate
		{
			protected override void Initialize() { }
			public void Update()
			{
				Agent agent = (Agent)Instance;
				agent.agentHitboxScript.heldItemH.SetSprite("Clear");
				agent.agentHitboxScript.heldItem2H.SetSprite("Clear");
				agent.agentHitboxScript.heldItemWB.SetSprite("Clear");
				agent.agentHitboxScript.heldItem.SetSprite("Clear");
				agent.agentHitboxScript.heldItem2.SetSprite("Clear");

				agent.agentHitboxScript.head.SetSprite("BullBot_Head");

				/*agent.agentHitboxScript.headWB.SetSprite("Clear");
				agent.agentHitboxScript.headWBH.SetSprite("Clear");
				agent.agentHitboxScript.arm1H.SetSprite("Clear");
				agent.agentHitboxScript.arm2H.SetSprite("Clear");
				agent.agentHitboxScript.leg1H.SetSprite("Clear");
				agent.agentHitboxScript.leg2H.SetSprite("Clear");*/

				agent.agentHitboxScript.body.SetSprite("BullBot_Body");

				/*agent.agentHitboxScript.bodyH.SetSprite("Clear");
				agent.agentHitboxScript.bodyWB.SetSprite("Clear");
				agent.agentHitboxScript.bodyWBH.SetSprite("Clear");
				agent.agentHitboxScript.arm1WB.SetSprite("Clear");
				agent.agentHitboxScript.headH.SetSprite("Clear");
				agent.agentHitboxScript.arm2WB.SetSprite("Clear");
				agent.agentHitboxScript.arm1WBH.SetSprite("Clear");
				agent.agentHitboxScript.arm2WBH.SetSprite("Clear");*/
				agent.agentHitboxScript.eyesWB.SetSprite("Clear");
				agent.agentHitboxScript.eyes.SetSprite("Clear");
				agent.agentHitboxScript.eyesH.SetSprite("Clear");
				agent.agentHitboxScript.facialHairWB.SetSprite("Clear");
				/*agent.agentHitboxScript.footwear1WB.SetSprite("Clear");
				agent.agentHitboxScript.footwear2WB.SetSprite("Clear");
				agent.agentHitboxScript.headPieceWB.SetSprite("Clear");
				agent.agentHitboxScript.headWB.SetSprite("Clear");
				agent.agentHitboxScript.leg1WB.SetSprite("Clear");
				agent.agentHitboxScript.leg2WB.SetSprite("Clear");
				agent.agentHitboxScript.leg1WBH.SetSprite("Clear");
				agent.agentHitboxScript.leg2WBH.SetSprite("Clear");*/
				agent.gun.gunSprite.SetSprite("Clear");
				agent.gun.arm1Sprite.SetSprite("Clear");
				agent.gun.arm2Sprite.SetSprite("Clear");
				agent.melee.arm1Sprite.SetSprite("Clear");
				agent.melee.arm2Sprite.SetSprite("Clear");
			}
		}
		public class Spidgren_Bot_Hook : HookBase<PlayfieldObject>, IDoUpdate
		{
			protected override void Initialize() { }
			public void Update()
			{
				Agent agent = (Agent)Instance;
				int animIndex = (int)Math.Floor(Time.time * 8f % 2f);
				string direction = agent.playerDir;
				if (string.IsNullOrEmpty(direction)) direction = "S";
				string spriteName = $"Spidgren_Bot{animIndex + 1}{direction}";
				agent.agentHitboxScript.body.SetSprite(spriteName);
				//agent.agentHitboxScript.hair.SetSprite(spriteName);
				agent.agentHitboxScript.heldItemH.SetSprite("Clear");
				agent.agentHitboxScript.heldItem2H.SetSprite("Clear");
				agent.agentHitboxScript.heldItemWB.SetSprite("Clear");
				agent.agentHitboxScript.heldItem.SetSprite("Clear");
				agent.agentHitboxScript.heldItem2.SetSprite("Clear");
				agent.agentHitboxScript.headH.SetSprite("Clear");
				agent.agentHitboxScript.head.SetSprite("Clear");
				agent.agentHitboxScript.headWB.SetSprite("Clear");
				agent.agentHitboxScript.headWBH.SetSprite("Clear");
				agent.agentHitboxScript.arm1H.SetSprite("Clear");
				agent.agentHitboxScript.arm2H.SetSprite("Clear");
				agent.agentHitboxScript.leg1H.SetSprite("Clear");
				agent.agentHitboxScript.leg2H.SetSprite("Clear");

				/*agent.agentHitboxScript.bodyH.SetSprite("Clear");
				agent.agentHitboxScript.bodyWB.SetSprite("Clear");
				agent.agentHitboxScript.bodyWBH.SetSprite("Clear");*/

				agent.agentHitboxScript.arm1WB.SetSprite("Clear");
				agent.agentHitboxScript.arm2WB.SetSprite("Clear");
				agent.agentHitboxScript.arm1WBH.SetSprite("Clear");
				agent.agentHitboxScript.arm2WBH.SetSprite("Clear");
				agent.agentHitboxScript.eyesWB.SetSprite("Clear");
				agent.agentHitboxScript.eyes.SetSprite("Clear");
				agent.agentHitboxScript.eyesH.SetSprite("Clear");
				agent.agentHitboxScript.facialHairWB.SetSprite("Clear");
				agent.agentHitboxScript.footwear1WB.SetSprite("Clear");
				agent.agentHitboxScript.footwear2WB.SetSprite("Clear");
				agent.agentHitboxScript.headPieceWB.SetSprite("Clear");
				agent.agentHitboxScript.headWB.SetSprite("Clear");
				agent.agentHitboxScript.leg1WB.SetSprite("Clear");
				agent.agentHitboxScript.leg2WB.SetSprite("Clear");
				agent.agentHitboxScript.leg1WBH.SetSprite("Clear");
				agent.agentHitboxScript.leg2WBH.SetSprite("Clear");
				agent.gun.gunSprite.SetSprite("Clear");
				agent.gun.arm1Sprite.SetSprite("Clear");
				agent.gun.arm2Sprite.SetSprite("Clear");
				agent.melee.arm1Sprite.SetSprite("Clear");
				agent.melee.arm2Sprite.SetSprite("Clear");
			}
		}
		private static System.Random rnd = new System.Random();
		public static string SelectFirstName() => FirstNames[rnd.Next(FirstNames.Length)];
		public static string SelectTwoName() => TwoNames[rnd.Next(TwoNames.Length)];
		public static string SelectRareName() => RareNames[rnd.Next(RareNames.Length)];
		public static void Agent_SetupAgentStats(string transformationType, Agent __instance)
        {
			if (__instance.agentName == "Border_Bot_Broken")
            {
                __instance.SetStrength(0);
		        __instance.SetEndurance(0);
		        __instance.SetAccuracy(1);
		        __instance.SetSpeed(6);
		        __instance.inhuman = false;
				__instance.wontFlee = true;
				__instance.cantChallengeToFight = true;
				__instance.preventsMindControl = true;
				__instance.statusEffects.AddTrait("TheLaw");
				__instance.statusEffects.AddTrait("DontTriggerFloorHazards");
				__instance.statusEffects.AddTrait("Electronic");
				__instance.statusEffects.AddTrait("ResistFire");
				__instance.copBot = true;
				__instance.modMeleeSkill = 0;
				__instance.modGunSkill = 2;
				__instance.modToughness = 1;
				__instance.modVigilant = 0;
				InvItem addedPistol = __instance.inventory.AddItem("Pistol", 999);
				addedPistol.doSpill = false;
				addedPistol.cantDropNPC = true;
				__instance.hackable = true;
				__instance.AddDesire("Supplies");
		        __instance.AddDesire("Technology");
				__instance.AddDesire("Guns");
				__instance.SetupSpecialInvDatabase();
                if (__instance.defaultGoal == string.Empty || __instance.defaultGoal == "None")
		        {
					__instance.SetDefaultGoal("Wander");
		        }
				__instance.agentHitboxScript.hasSetup = true;
				__instance.agentHitboxScript.SetUsesNewHead();
				__instance.agentHitboxScript.hairType = "Border_Bot_Broken";
				__instance.agentHitboxScript.head.SetSprite("Clear");
				__instance.customCharacterData.facialHair = "None";
				__instance.agentHitboxScript.bodyColor = new Color32(0, 0, 0, 0);
				__instance.agentHitboxScript.legsColor = new Color32(0, 0, 0, 0);
				__instance.agentHitboxScript.skinColor = new Color32(0, 0, 0, 0);
				__instance.agentHitboxScript.hairColor = new Color32(255, 255, 255, 255);
				__instance.AddHook<InvisibleHook>();
		        __instance.agentCategories.Clear();
		        __instance.health = __instance.healthMax;
		        __instance.setInitialCategories = true;            
                __instance.agentActive = true;
		        __instance.SetBrainActive(true);   
            }
			if (__instance.agentName == "Border_Bot_Rusty")
			{
				__instance.SetStrength(0);
				__instance.SetEndurance(0);
				__instance.SetAccuracy(0);
				__instance.SetSpeed(4);
				__instance.inhuman = false;
				__instance.wontFlee = true;
				__instance.cantChallengeToFight = true;
				__instance.preventsMindControl = true;
				__instance.statusEffects.AddTrait("TheLaw");
				__instance.statusEffects.AddTrait("DontTriggerFloorHazards");
				__instance.statusEffects.AddTrait("Electronic");
				__instance.statusEffects.AddTrait("ResistFire");
				__instance.copBot = true;
				__instance.modMeleeSkill = 0;
				__instance.modGunSkill = 1;
				__instance.modToughness = 1;
				__instance.modVigilant = 0;
				InvItem addedPistol = __instance.inventory.AddItem("Pistol", 999);
				addedPistol.doSpill = false;
				addedPistol.cantDropNPC = true;
				__instance.hackable = true;
				__instance.AddDesire("Supplies");
				__instance.AddDesire("Technology");
				__instance.AddDesire("Guns");
				__instance.SetupSpecialInvDatabase();
				if (__instance.defaultGoal == string.Empty || __instance.defaultGoal == "None")
				{
					__instance.SetDefaultGoal("Wander");
				}
				__instance.agentHitboxScript.hasSetup = true;
				__instance.agentHitboxScript.SetUsesNewHead();
				__instance.agentHitboxScript.hairType = "Border_Bot_Rusty";
				__instance.agentHitboxScript.head.SetSprite("Clear");
				__instance.customCharacterData.facialHair = "None";
				__instance.agentHitboxScript.bodyColor = new Color32(0, 0, 0, 0);
				__instance.agentHitboxScript.legsColor = new Color32(0, 0, 0, 0);
				__instance.agentHitboxScript.skinColor = new Color32(0, 0, 0, 0);
				__instance.agentHitboxScript.hairColor = new Color32(255, 255, 255, 255);
				__instance.AddHook<InvisibleHook>();
				__instance.agentCategories.Clear();
				__instance.health = __instance.healthMax;
				__instance.setInitialCategories = true;
				__instance.agentActive = true;
				__instance.SetBrainActive(true);
			}
			if (__instance.agentName == "Cutter_Bot")
			{
				__instance.SetStrength(0);
				__instance.SetEndurance(0);
				__instance.SetAccuracy(0);
				__instance.SetSpeed(10);
				__instance.inhuman = false;
				__instance.wontFlee = true;
				__instance.cantChallengeToFight = true;
				__instance.preventsMindControl = true;
				__instance.statusEffects.AddTrait("TheLaw");
				__instance.statusEffects.AddTrait("CantAttack");
				__instance.statusEffects.AddTrait("DontTriggerFloorHazards");
				__instance.statusEffects.AddTrait("Electronic");
				__instance.statusEffects.AddTrait("ResistFire");
				__instance.statusEffects.AddStatusEffect("ElectroTouch", false, true, 999);
				__instance.copBot = true;
				__instance.modMeleeSkill = 0;
				__instance.modGunSkill = 0;
				__instance.modToughness = 1;
				__instance.modVigilant = 0;
				__instance.hackable = true;
				__instance.AddDesire("Supplies");
				__instance.AddDesire("Technology");
				__instance.AddDesire("Guns");
				__instance.SetupSpecialInvDatabase();
				if (__instance.defaultGoal == string.Empty || __instance.defaultGoal == "None")
				{
					__instance.SetDefaultGoal("Wander");
				}
				__instance.agentHitboxScript.hasSetup = true;
				__instance.agentHitboxScript.SetUsesNewHead();
				__instance.agentHitboxScript.hairType = "Cutter_Bot1";
				__instance.agentHitboxScript.head.SetSprite("Clear");
				__instance.customCharacterData.facialHair = "None";
				__instance.agentHitboxScript.bodyColor = new Color32(0, 0, 0, 0);
				__instance.agentHitboxScript.legsColor = new Color32(0, 0, 0, 0);
				__instance.agentHitboxScript.skinColor = new Color32(0, 0, 0, 0);
				__instance.agentHitboxScript.hairColor = new Color32(255, 255, 255, 255);
				__instance.AddHook<Cutter_Bot_Hook>();
				__instance.agentCategories.Clear();
				__instance.health = __instance.healthMax;
				__instance.setInitialCategories = true;
				__instance.agentActive = true;
				__instance.SetBrainActive(true);
			}
			if (__instance.agentName == "Boom_Bot")
			{
				__instance.SetStrength(0);
				__instance.SetEndurance(0);
				__instance.SetAccuracy(0);
				__instance.SetSpeed(15);
				__instance.inhuman = false;
				__instance.wontFlee = true;
				__instance.cantChallengeToFight = true;
				__instance.preventsMindControl = true;
				__instance.statusEffects.AddTrait("TheLaw");
				__instance.statusEffects.AddTrait("CantAttack");
				__instance.statusEffects.AddTrait("DontTriggerFloorHazards");
				__instance.statusEffects.AddTrait("Electronic");
				__instance.statusEffects.AddTrait("ResistFire");
				__instance.copBot = true;
				__instance.modMeleeSkill = 0;
				__instance.modGunSkill = 0;
				__instance.modToughness = 1;
				__instance.modVigilant = 0;
				__instance.hackable = true;
				__instance.AddDesire("Supplies");
				__instance.AddDesire("Technology");
				__instance.AddDesire("Guns");
				__instance.SetupSpecialInvDatabase();
				if (__instance.defaultGoal == string.Empty || __instance.defaultGoal == "None")
				{
					__instance.SetDefaultGoal("Wander");
				}
				__instance.agentHitboxScript.hasSetup = true;
				__instance.agentHitboxScript.SetUsesNewHead();
				__instance.agentHitboxScript.hairType = "Kamikaze_Bot";
				__instance.agentHitboxScript.head.SetSprite("Clear");
				__instance.customCharacterData.facialHair = "None";
				__instance.agentHitboxScript.bodyColor = new Color32(0, 0, 0, 0);
				__instance.agentHitboxScript.legsColor = new Color32(0, 0, 0, 0);
				__instance.agentHitboxScript.skinColor = new Color32(0, 0, 0, 0);
				__instance.agentHitboxScript.hairColor = new Color32(255, 255, 255, 255);
				__instance.AddHook<Boom_Bot_Hook>();
				__instance.agentCategories.Clear();
				__instance.health = __instance.healthMax;
				__instance.setInitialCategories = true;
				__instance.agentActive = true;
				__instance.SetBrainActive(true);
			}
			if (__instance.agentName == "Spidgren_Bot")
			{
				__instance.SetStrength(0);
				__instance.SetEndurance(0);
				__instance.SetAccuracy(1);
				__instance.SetSpeed(6);
				__instance.inhuman = false;
				__instance.wontFlee = true;
				__instance.cantChallengeToFight = true;
				__instance.preventsMindControl = true;
				__instance.statusEffects.AddTrait("TheLaw");
				//__instance.statusEffects.AddTrait("CantAttack");
				__instance.statusEffects.AddTrait("DontTriggerFloorHazards");
				__instance.statusEffects.AddTrait("Electronic");
				__instance.statusEffects.AddTrait("ResistFire");
				InvItem addedGrenade = __instance.inventory.AddItem("Grenade", 999);
				addedGrenade.doSpill = false;
				addedGrenade.cantDropNPC = true;
				__instance.copBot = true;
				__instance.modMeleeSkill = 0;
				__instance.modGunSkill = 1;
				__instance.modToughness = 1;
				__instance.modVigilant = 0;
				__instance.hackable = true;
				__instance.AddDesire("Supplies");
				__instance.AddDesire("Technology");
				__instance.AddDesire("Guns");
				__instance.SetupSpecialInvDatabase();
				if (__instance.defaultGoal == string.Empty || __instance.defaultGoal == "None")
				{
					__instance.SetDefaultGoal("Wander");
				}
				__instance.agentHitboxScript.hasSetup = true;
				__instance.agentHitboxScript.SetUsesNewHead();
				__instance.agentHitboxScript.hairType = "Spidgren_Bot1";
				__instance.agentHitboxScript.head.SetSprite("Clear");
				__instance.customCharacterData.facialHair = "None";
				__instance.agentHitboxScript.bodyColor = new Color32(0, 0, 0, 0);
				__instance.agentHitboxScript.legsColor = new Color32(0, 0, 0, 0);
				__instance.agentHitboxScript.skinColor = new Color32(0, 0, 0, 0);
				__instance.agentHitboxScript.hairColor = new Color32(255, 255, 255, 255);
				__instance.AddHook<Spidgren_Bot_Hook>();
				__instance.agentCategories.Clear();
				__instance.health = __instance.healthMax;
				__instance.setInitialCategories = true;
				__instance.agentActive = true;
				__instance.SetBrainActive(true);
			}
			if (__instance.agentName == "Bull_Bot")
			{
				__instance.SetStrength(2);
				__instance.SetEndurance(2);
				__instance.SetAccuracy(0);
				__instance.SetSpeed(2);
				__instance.inhuman = false;
				__instance.wontFlee = true;
				__instance.cantChallengeToFight = true;
				__instance.preventsMindControl = true;
				//__instance.statusEffects.AddTrait("TheLaw");
				__instance.statusEffects.AddTrait("Electronic");
				__instance.statusEffects.AddTrait("ResistFire");
				__instance.statusEffects.AddTrait("CantUseGuns");
				__instance.statusEffects.AddTrait("DontHitAligned");
				__instance.copBot = true;
				__instance.modMeleeSkill = 2;
				__instance.modGunSkill = 0;
				__instance.modToughness = 1;
				__instance.modVigilant = 0;
				__instance.hackable = true;
				__instance.AddDesire("Supplies");
				__instance.AddDesire("Technology");
				__instance.AddDesire("Guns");
				__instance.AddJob("Bribe", 5);
				__instance.SetupSpecialInvDatabase();
				if (__instance.defaultGoal == string.Empty || __instance.defaultGoal == "None" || __instance.defaultGoal == null)
				{
					__instance.SetDefaultGoal("Guard");
				}
				__instance.agentHitboxScript.hasSetup = true;
				__instance.agentHitboxScript.SetUsesNewHead();
				/*__instance.agentHitboxScript.hairType = "Spidgren_Bot1";
				__instance.agentHitboxScript.head.SetSprite("Clear");*/
				__instance.customCharacterData.facialHair = "None";
				__instance.agentHitboxScript.bodyColor = new Color32(255, 255, 255, 255);
				__instance.agentHitboxScript.legsColor = new Color32(24, 69, 56, 255);
				__instance.agentHitboxScript.skinColor = new Color32(0, 0, 0, 255);
				__instance.agentHitboxScript.hairColor = new Color32(255, 255, 255, 255);
				__instance.AddHook<Bull_Bot_Hook>();
				__instance.agentCategories.Clear();
				__instance.health = __instance.healthMax;
				__instance.setInitialCategories = true;
				__instance.agentActive = true;
				__instance.SetBrainActive(true);
			}
			if (__instance.agentName == "Turret_Bot")
			{
				__instance.SetStrength(0);
				__instance.SetEndurance(0);
				__instance.SetAccuracy(1);
				__instance.SetSpeed(1);
				__instance.inhuman = false;
				__instance.wontFlee = true;
				__instance.cantChallengeToFight = true;
				__instance.preventsMindControl = true;
				__instance.statusEffects.AddTrait("TheLaw");
				__instance.statusEffects.AddTrait("Electronic");
				__instance.statusEffects.AddTrait("ResistFire");
				__instance.copBot = true;
				__instance.modMeleeSkill = 0;
				__instance.modGunSkill = 1;
				__instance.modToughness = 1;
				__instance.modVigilant = 0;
				__instance.hackable = true;
				InvItem addedRevolver = __instance.inventory.AddItem("Revolver", 999);
				addedRevolver.doSpill = false;
				addedRevolver.cantDropNPC = true;
				__instance.AddDesire("Supplies");
				__instance.AddDesire("Technology");
				__instance.AddDesire("Guns");
				__instance.SetupSpecialInvDatabase();
				if (__instance.defaultGoal == string.Empty || __instance.defaultGoal == "None")
				{
					__instance.SetDefaultGoal("Wander");
				}
				__instance.agentHitboxScript.hasSetup = true;
				__instance.agentHitboxScript.SetUsesNewHead();
				__instance.agentHitboxScript.hairType = "Spidgren_Bot1";
				__instance.agentHitboxScript.head.SetSprite("Clear");
				__instance.customCharacterData.facialHair = "None";
				__instance.agentHitboxScript.bodyColor = new Color32(0, 0, 0, 255);
				__instance.agentHitboxScript.legsColor = new Color32(0, 0, 0, 255);
				__instance.agentHitboxScript.skinColor = new Color32(0, 0, 0, 255);
				__instance.agentHitboxScript.hairColor = new Color32(0, 0, 0, 255);
				__instance.AddHook<Spidgren_Bot_Hook>();
				__instance.agentCategories.Clear();
				__instance.health = __instance.healthMax;
				__instance.setInitialCategories = true;
				__instance.agentActive = true;
				__instance.SetBrainActive(true);
			}
			if (__instance.agentName == "Beelze_Drone")
			{
				__instance.SetStrength(0);
				__instance.SetEndurance(0);
				__instance.SetAccuracy(0);
				__instance.SetSpeed(5);
				__instance.inhuman = false;
				__instance.wontFlee = true;
				__instance.cantChallengeToFight = true;
				__instance.preventsMindControl = true;
				__instance.statusEffects.AddTrait("TheLaw");
				__instance.statusEffects.AddTrait("Electronic");
				__instance.statusEffects.AddTrait("ResistFire");
				__instance.statusEffects.AddTrait("CantUseGuns");
				__instance.statusEffects.AddTrait("CantAttack");
				__instance.copBot = true;
				__instance.modMeleeSkill = 0;
				__instance.modGunSkill = 0;
				__instance.modToughness = 1;
				__instance.modVigilant = 0;
				__instance.hackable = true;
				__instance.AddDesire("Supplies");
				__instance.AddDesire("Technology");
				__instance.AddDesire("Guns");
				__instance.SetupSpecialInvDatabase();
				if (__instance.defaultGoal == string.Empty || __instance.defaultGoal == "None")
				{
					__instance.SetDefaultGoal("Wander");
				}
				__instance.agentHitboxScript.hasSetup = true;
				__instance.agentHitboxScript.SetUsesNewHead();
				__instance.agentHitboxScript.hairType = "Spidgren_Bot1";
				__instance.agentHitboxScript.head.SetSprite("Clear");
				__instance.customCharacterData.facialHair = "None";
				__instance.agentHitboxScript.bodyColor = new Color32(0, 0, 0, 255);
				__instance.agentHitboxScript.legsColor = new Color32(0, 0, 0, 255);
				__instance.agentHitboxScript.skinColor = new Color32(0, 0, 0, 255);
				__instance.agentHitboxScript.hairColor = new Color32(255, 255, 255, 255);
				__instance.AddHook<Spidgren_Bot_Hook>();
				__instance.agentCategories.Clear();
				__instance.health = __instance.healthMax;
				__instance.setInitialCategories = true;
				__instance.agentActive = true;
				__instance.SetBrainActive(true);
			}
			if (__instance.agentName == "Beelze_Bot")
			{
				__instance.SetStrength(0);
				__instance.SetEndurance(1);
				__instance.SetAccuracy(0);
				__instance.SetSpeed(1);
				__instance.inhuman = false;
				__instance.wontFlee = true;
				__instance.cantChallengeToFight = true;
				__instance.preventsMindControl = true;
				__instance.statusEffects.AddTrait("TheLaw");
				__instance.statusEffects.AddTrait("Electronic");
				__instance.statusEffects.AddTrait("ResistFire");
				__instance.statusEffects.AddTrait("CantUseGuns");
				__instance.statusEffects.AddTrait("CantAttack");
				__instance.copBot = true;
				__instance.modMeleeSkill = 0;
				__instance.modGunSkill = 0;
				__instance.modToughness = 1;
				__instance.modVigilant = 0;
				__instance.hackable = true;
				__instance.AddDesire("Supplies");
				__instance.AddDesire("Technology");
				__instance.AddDesire("Guns");
				__instance.SetupSpecialInvDatabase();
				if (__instance.defaultGoal == string.Empty || __instance.defaultGoal == "None")
				{
					__instance.SetDefaultGoal("Wander");
				}
				__instance.agentHitboxScript.hasSetup = true;
				__instance.agentHitboxScript.SetUsesNewHead();
				__instance.agentHitboxScript.hairType = "Spidgren_Bot1";
				__instance.agentHitboxScript.head.SetSprite("Clear");
				__instance.customCharacterData.facialHair = "None";
				__instance.agentHitboxScript.bodyColor = new Color32(0, 0, 0, 0);
				__instance.agentHitboxScript.legsColor = new Color32(0, 0, 0, 0);
				__instance.agentHitboxScript.skinColor = new Color32(0, 0, 0, 0);
				__instance.agentHitboxScript.hairColor = new Color32(255, 255, 255, 255);
				__instance.AddHook<Spidgren_Bot_Hook>();
				__instance.agentCategories.Clear();
				__instance.health = __instance.healthMax;
				__instance.setInitialCategories = true;
				__instance.agentActive = true;
				__instance.SetBrainActive(true);
			}
			if (__instance.agentName == "Flame_Bot")
			{
				__instance.SetStrength(0);
				__instance.SetEndurance(2);
				__instance.SetAccuracy(3);
				__instance.SetSpeed(1);
				__instance.inhuman = false;
				__instance.wontFlee = true;
				__instance.cantChallengeToFight = true;
				__instance.preventsMindControl = true;
				__instance.statusEffects.AddTrait("TheLaw");
				__instance.statusEffects.AddTrait("DontTriggerFloorHazards");
				__instance.statusEffects.AddTrait("Electronic");
				__instance.statusEffects.AddTrait("ResistFire");
				__instance.copBot = true;
				__instance.modMeleeSkill = 0;
				__instance.modGunSkill = 2;
				__instance.modToughness = 1;
				__instance.modVigilant = 0;
				InvItem addedFlamethrower = __instance.inventory.AddItem("Flamethrower", 999);
				addedFlamethrower.doSpill = false;
				addedFlamethrower.cantDropNPC = true;
				__instance.hackable = true;
				__instance.AddDesire("Supplies");
				__instance.AddDesire("Technology");
				__instance.AddDesire("Guns");
				__instance.SetupSpecialInvDatabase();
				if (__instance.defaultGoal == string.Empty || __instance.defaultGoal == "None")
				{
					__instance.SetDefaultGoal("Wander");
				}
				__instance.agentHitboxScript.hasSetup = true;
				__instance.agentHitboxScript.SetUsesNewHead();
				__instance.agentHitboxScript.hairType = "Flame_Bot";
				__instance.agentHitboxScript.head.SetSprite("Clear");
				__instance.customCharacterData.facialHair = "None";
				__instance.agentHitboxScript.bodyColor = new Color32(0, 0, 0, 0);
				__instance.agentHitboxScript.legsColor = new Color32(0, 0, 0, 0);
				__instance.agentHitboxScript.skinColor = new Color32(0, 0, 0, 0);
				__instance.agentHitboxScript.hairColor = new Color32(255, 255, 255, 255);
				__instance.AddHook<InvisibleHook>();
				__instance.agentCategories.Clear();
				__instance.health = __instance.healthMax;
				__instance.setInitialCategories = true;
				__instance.agentActive = true;
				__instance.SetBrainActive(true);
			}
		}
		public static void LoadLevel_SetupMore4(LoadLevel __instance, ref GameController ___gc)
		{
			if (UBS.UBSNames == 1)
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
					if (agent.agentName is "CopBot" or "Robot" || agent.agentName is "RobotPlayer" && ___gc.levelType == "HomeBase")
					{
						agent.agentRealName = robotname + "-" + botint;
					}
					else if (agent.agentName is "Zombie")
                    {
						if (rnd.Next(100) == 0) // 1%
						{
							agent.agentRealName = "Walking Corpse of" + SelectRareName();
						}
						else
							agent.agentRealName = "Walking Corpse of" + SelectFirstName() + " " + SelectTwoName();
					}
					else if (agent.agentName is "Ghost")
					{
						if (rnd.Next(100) == 0) // 1%
						{
							agent.agentRealName = "The Ghost of" + SelectRareName();
						}
						else
							agent.agentRealName = "The Ghost of" + SelectFirstName() + " " + SelectTwoName();
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
			}
			if (UBS.UBSBots1 == 1)
            {
				if (___gc.levelType != "HomeBase" && ___gc.levelType != "Tutorial")
				{
					/*levelTheme == 0 => levelType = "�������";
					levelTheme == 1 => levelType = "�����";
					levelTheme == 2 => levelType = "����";
					levelTheme == 3 => levelType = "��������";
					levelTheme == 4 => levelType = "������� �����";
					levelTheme == 5 => levelType = "������� ����";*/

					int borderbotchoose = UnityEngine.Random.Range(1, 3);
					Vector2 randompos = ___gc.tileInfo.FindRandLocationGeneral();
					if (___gc.levelTheme is 0)
					{
						___gc.spawnerMain.SpawnAgent(___gc.elevatorDown.curPosition, null, "Bull_Bot");
						//___gc.spawnerMain.SpawnAgent(___gc.elevatorDown.curPosition, null, "Spidgren_Bot");
						//___gc.spawnerMain.SpawnAgent(___gc.elevatorDown.curPosition, null, "Bull_Bot");
						for (int r = 0; r < 4; r++)
						{
							borderbotchoose = UnityEngine.Random.Range(1, 3);
							if (borderbotchoose == 1)
							{
								___gc.spawnerMain.SpawnAgent(randompos, null, "Border_Bot_Broken");
							}
							else ___gc.spawnerMain.SpawnAgent(randompos, null, "Border_Bot_Rusty");
						}
					}
					else if (___gc.levelTheme is 1)
					{
						for (int r = 0; r < 6; r++)
						{
							borderbotchoose = UnityEngine.Random.Range(1, 3);
							if (borderbotchoose == 1)
							{
								___gc.spawnerMain.SpawnAgent(randompos, null, "Border_Bot_Broken");
							}
							else ___gc.spawnerMain.SpawnAgent(randompos, null, "Border_Bot_Rusty");
						}
						for (int r = 0; r < 2; r++)
						{
							___gc.spawnerMain.SpawnAgent(randompos, null, "Cutter_Bot");
						}
					}
					else if (___gc.levelTheme is 3)
					{
						for (int r = 0; r < 10; r++)
						{
							if (borderbotchoose == 1)
							{
								___gc.spawnerMain.SpawnAgent(randompos, null, "Border_Bot_Broken");
							}
						}
						for (int r = 0; r < 4; r++)
						{
							___gc.spawnerMain.SpawnAgent(randompos, null, "Cutter_Bot");
						}
					}
					else if (___gc.levelTheme is 4)
					{
						for (int r = 0; r < 6; r++)
						{
							___gc.spawnerMain.SpawnAgent(randompos, null, "Cutter_Bot");
						}
						/*for (int r = 0; r < 4; r++)
						{
							___gc.spawnerMain.SpawnAgent(___gc.elevatorUp.curPosition, null, "Spidgren_Bot");
						}*/
						for (int r = 0; r < 2; r++)
						{
							___gc.spawnerMain.SpawnAgent(randompos, null, "Boom_Bot");
						}
					}
					else if (___gc.levelTheme is 5)
					{
						for (int r = 0; r < 8; r++)
						{
							___gc.spawnerMain.SpawnAgent(randompos, null, "Cutter_Bot");
						}
						/*for (int r = 0; r < 4; r++)
						{
							___gc.spawnerMain.SpawnAgent(___gc.elevatorUp.curPosition, null, "Spidgren_Bot");
						}*/
						for (int r = 0; r < 4; r++)
						{
							___gc.spawnerMain.SpawnAgent(randompos, null, "Boom_Bot");
						}
					}
				}
			}
		}
		public static void Movement_KnockBackBullet(ref float strength, PlayfieldObject knockerObject)
        {
			if (knockerObject is Agent agent && agent.agentName == "Cutter_Bot")
            {
				strength = 0f;
			}
		}
		public static bool StatusEffects_ExplodeAfterDeathChecks(StatusEffects __instance)
			=> __instance.agent.GetHook<Boom_Bot_Hook>() is null;
	}
}