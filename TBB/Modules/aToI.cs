using System;
using System.Linq;
using RogueLibsCore;
using UnityEngine;
using HarmonyLib;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;

namespace TBB
{
	public class aToI
	{
		public static List<ItemUnlock> Items = new List<ItemUnlock>();
		public static void SetActive(bool isEnabled)
		{
			foreach (ItemUnlock unlock in Items.Where(i => i != null))
			{
				unlock.IsAvailable = isEnabled;
				unlock.IsAvailableInCC = isEnabled;
				unlock.IsAvailableInItemTeleporter = isEnabled;
			}
		}
		public void Awake()
		{
			ItemBuilder builder = RogueLibs.CreateCustomItem<VoodooBlank>()
				.WithName(new CustomNameInfo
				{
					English = "Blank Voodoo Doll",
					Russian = "Непривязанная кукла Вуду"
				})
				.WithDescription(new CustomNameInfo
				{
					English = "Bind the doll to someone and then combine things with it to inflict damage or effects onto that person.",
					Russian = "Привяжите куклу к кому-нибудь и потом совмещайте всякие предметы с ней, чтобы наносить урон или эффекты на этого человека."
				})
				.WithUnlock(new ItemUnlock(nameof(VoodooBlank))
				{
					UnlockCost = 0,
					CharacterCreationCost = 5,
					Prerequisites = new List<string> { "WalkieTalkie" }
				})
				.WithSprite(Properties.Resources.VoodooBlank);
			Items.Add(builder.Unlock);
			builder = RogueLibs.CreateCustomItem<VoodooActive>()
				.WithName(new CustomNameInfo
				{
					English = "Active Voodoo Doll",
					Russian = "Активированная кукла Вуду"
				}).WithDescription(new CustomNameInfo
				{
					English = "Combine things with the doll to inflict damage or effects onto the victim.",
					Russian = "Совмещайте всякие предметы с куклой для нанесения урона или эффектов жертве."
				})
				.WithSprite(Properties.Resources.VoodooActive);
			Items.Add(builder.Unlock);
			builder = RogueLibs.CreateCustomItem<NuclearBriefcase>()
			.WithName(new CustomNameInfo
			{
				English = "Nuclear Briefcase",
				Russian = "Ядерный чемоданчик"
			})
			.WithDescription(new CustomNameInfo
			{
				English = "Obliterates the entire level, leaving absolutely nothing behind.",
				Russian = "Уничтожает весь уровень, не оставляя после себя абсолютно ничего."
			})
			.WithSprite(Properties.Resources.NuclearBriefcase)
			.WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 10, LoadoutCost = 10 });
			Items.Add(builder.Unlock);
			builder = RogueLibs.CreateCustomItem<OpenNuclearBriefcase>()
				.WithName(new CustomNameInfo("Open Nuclear Briefcase"))
				.WithDescription(new CustomNameInfo("Oh no..."))
				.WithSprite(Properties.Resources.OpenNuclearBriefcase);
			Items.Add(builder.Unlock);
			builder = RogueLibs.CreateCustomItem<LootBox>()
			.WithName(new CustomNameInfo
			{
				English = "Loot Box",
				Russian = "Подарок"
			})
			.WithDescription(new CustomNameInfo
			{
				English = "Gives you a random item.",
				Russian = "Даёт вам рандомный предмет."
			})
			.WithSprite(Properties.Resources.LootBox1)
			.WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 0, LoadoutCost = 3 });
			Items.Add(builder.Unlock);
			builder = RogueLibs.CreateCustomItem<PortableAmmoDispenser>()
			.WithName(new CustomNameInfo
			{
				English = "Portable Ammo Dispenser",
				Russian = "Портативный раздатчик боеприпасов"
			})
			.WithDescription(new CustomNameInfo
			{
				English = "Use it to refill your ranged weapons' ammo. For money, of course.",
				Russian = "Используйте для пополнения запаса патронов у оружия дальнего боя. За деньги, конечно же."
			})
			.WithSprite(Properties.Resources.PortableAmmoDispenser)
			.WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 0, LoadoutCost = 5 });
			Items.Add(builder.Unlock);
			builder = RogueLibs.CreateCustomItem<Portable_Barbecue_Inactive>()
			.WithName(new CustomNameInfo
			{
				English = "Portable Barbecue",
				Russian = "Портативное барбекю"
			})
			.WithDescription(new CustomNameInfo
			{
				English = "To use it, you need to light it, thanks to a special technology, the barbecue does not go out. It easily fries food despite its compactness.",
				Russian = "Для использования требуется зажечь, благодаря особой технологии барбекю не потухает. С лёгкостью жарит еду несмотря на свою компактность."
			})
			.WithSprite(Properties.Resources.Portable_Barbecue_Inactive)
			.WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 3, LoadoutCost = 3 });
			Items.Add(builder.Unlock);
			builder = RogueLibs.CreateCustomItem<Portable_Barbecue_Active>()
			.WithName(new CustomNameInfo
			{
				English = "Portable Barbecue",
				Russian = "Портативное барбекю"
			})
			.WithDescription(new CustomNameInfo
			{
				English = "The barbecue is ready to use! Don't overcook it!",
				Russian = "Барбекю готово к использованию! Смотрите не пережарьте!"
			})
			.WithSprite(Properties.Resources.Portable_Barbecue_Active);
			Items.Add(builder.Unlock);
			builder = RogueLibs.CreateCustomItem<Air_Support_Phone>()
			.WithName(new CustomNameInfo
			{
				English = "Air Support Phone",
				Russian = "Телефон воздушной поддержки"
			})
			.WithDescription(new CustomNameInfo
			{
				English = "<color=#55e657>I'm waiting for the coordinates.</color>",
				Russian = "<color=#55e657>Ожидаю координаты.</color>"
			})
			.WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 3, LoadoutCost = 5 })
			.WithSprite(Properties.Resources.Air_Support_Phone);
			Items.Add(builder.Unlock);
			RogueLibs.CreateCustomSprite("LootBox2", SpriteScope.Items, Properties.Resources.LootBox2);
			RogueLibs.CreateCustomSprite("LootBox3", SpriteScope.Items, Properties.Resources.LootBox3);
			RogueLibs.CreateCustomName("UseNuclearBriefcase", "Interface", new CustomNameInfo
			{
				English = "Activate here",
				Russian = "Активировать здесь"
			});
			RogueLibs.CreateCustomName("Use_Air_Support_Phone", "Interface", new CustomNameInfo
			{
				English = "Request air support",
				Russian = "Запросить поддержку"
			});
			RogueLibs.CreateCustomName("VoodooBind", "Interface", new CustomNameInfo
			{
				English = "Bind",
				Russian = "Привязать"
			});
			RogueLibs.CreateCustomName("VoodooNotAgent", "Interface", new CustomNameInfo
			{
				English = "Select a character!",
				Russian = "Выберите персонажа!"
			});
			RogueLibs.CreateCustomName("VoodooDeadAgent", "Interface", new CustomNameInfo
			{
				English = "They're already dead",
				Russian = "Он уже мёртвый"
			});
			RogueLibs.CreateCustomName("VoodooElectronic", "Interface", new CustomNameInfo
			{
				English = "This thing doesn't have a soul",
				Russian = "У этой штуки нет души"
			});

			RoguePatcher patcher = new RoguePatcher(Main.MainInstance, typeof(aToI));

			patcher.Postfix(typeof(Gun), nameof(Gun.spawnBullet), new Type[] { typeof(bulletStatus), typeof(InvItem), typeof(int), typeof(bool), typeof(string) });
			patcher.Prefix(typeof(SpawnerMain), nameof(SpawnerMain.SpawnWreckage));
			patcher.Prefix(typeof(SpawnerMain), nameof(SpawnerMain.SpawnWreckage2));
			patcher.Prefix(typeof(SpawnerMain), nameof(SpawnerMain.SpawnParticleEffect),
				new Type[4] { typeof(string), typeof(Vector3), typeof(float), typeof(Transform) });
			patcher.Prefix(typeof(Explosion), nameof(Explosion.ExplosionHit));
			patcher.Prefix(typeof(AudioHandler), nameof(AudioHandler.PlayClipAt));
		}
		public static void Gun_spawnBullet(InvItem myWeapon, Bullet __result)
		{
			VoodooActive voodoo = myWeapon?.database?.GetItem<VoodooActive>();
			if (voodoo != null) voodoo.LastFiredBullet = __result;
		}
		public static bool suppress;
		public static bool SpawnerMain_SpawnWreckage(ref Item __result)
		{
			__result = new Item();
			return !suppress;
		}
		public static bool SpawnerMain_SpawnWreckage2() => !suppress;
		public static bool SpawnerMain_SpawnParticleEffect(ref GameObject __result)
		{
			__result = new GameObject();
			return !suppress;
		}
		public static void AudioHandler_PlayClipAt(string clipName, ref float vol)
		{
			if (clipName == "ExplodeRidiculous") vol *= 5f;
		}
		internal static readonly FieldInfo canHit = typeof(Explosion).GetField("canHit", BindingFlags.Instance | BindingFlags.NonPublic);
		public static bool Explosion_ExplosionHit(Explosion __instance, GameObject hitObject)
		{
			if (__instance.damage != 488755541) return true;
			if ((float)canHit.GetValue(__instance) <= 0f) return false;
			if (__instance.objectList.Contains(hitObject)) return false;
			__instance.objectList.Add(hitObject);
			if (hitObject.CompareTag("AgentSprite"))
			{
				try
				{
					hitObject = hitObject.GetComponent<AgentColliderBox>().objectSprite.go;
				}
				catch
				{
					hitObject = hitObject.transform.Find("AgentHitboxColliders").transform.GetChild(0).GetComponent<AgentColliderBox>().objectSprite.go;
				}
			}
			ObjectSprite spr = hitObject.GetComponent<ObjectSprite>();
			if (spr?.agent != null)
			{
				Agent Owner = __instance.agent;
				Agent agent = spr.agent;
				try
				{
					if (agent.isPlayer == 0)
					{
						GameController.gameController.stats.AddToStat(Owner, "Killed", 1);
						GameController.gameController.stats.AddToStat(Owner, "InnocentsKilled", 1);
						if (agent.statusEffects.AgentIsRival(Owner))
						{
							GameController.gameController.quests.AddBigQuestPoints(Owner, agent, "KillGuilty");
							Owner.skillPoints.AddPoints("KillPointsRival");
						}
						else if (agent.statusEffects.IsInnocent(Owner))
						{
							GameController.gameController.quests.AddBigQuestPoints(Owner, "KillInnocent");
							Owner.skillPoints.AddPoints("KillPointsInnocent");
						}
						else Owner.skillPoints.AddPoints("KillPoints");
						GameController.gameController.quests.AddBigQuestPoints(Owner, agent, "Dead");
						GameController.gameController.quests.AddBigQuestPoints(Owner, agent, "Neutralize");
						GameController.gameController.quests.AddBigQuestPoints(Owner, agent, "BloodlustKill");
					}
					agent.inventory.ClearInventory(false);
					agent.resurrect = false;
					agent.statusEffects.SetupDeath(__instance, false, true);
					agent.statusEffects.Disappear();
				}
				catch { }
			}
			if (spr?.objectReal != null)
			{
				ObjectReal obj = spr?.objectReal;
				try
				{
					obj.objectInvDatabase?.ClearInventory(false);
					obj.specialInvDatabase?.ClearInventory(false);
					obj.DestroyMe();
				}
				catch { }
			}
			if (spr?.item != null)
			{
				spr.item.DestroyMeFromClient();
			}
			if (hitObject.CompareTag("Fire"))
			{
				Fire fire = hitObject.GetComponent<Fire>();
				fire.DestroyMe();
			}
			if (hitObject.CompareTag("Wall"))
			{
				__instance.tileInfo.DestroyWallTileAtPosition(hitObject.transform.position.x, hitObject.transform.position.y, true, __instance.agent);

				__instance.gc.stats.AddDestructionQuestPoints();
				__instance.gc.stats.AddToStat(__instance.agent, "Destruction", 1);
			}
			return true;
		}
	}
	[ItemCategories(RogueCategories.Usable, RogueCategories.Social, RogueCategories.Stealth, RogueCategories.Weird)]
	public class VoodooBlank : CustomItem, IItemTargetable
	{
		public override void SetupDetails()
		{
			Item.itemType = ItemTypes.Tool;
			Item.itemValue = 80;
			Item.initCount = 3;
			Item.rewardCount = 3;
			Item.stackable = true;
			Item.hasCharges = true;
			Item.goesInToolbar = true;
		}
		public bool TargetFilter(PlayfieldObject target) => target is Agent agent && !agent.dead && !agent.mechFilled && !agent.mechEmpty
			&& !agent.statusEffects.hasTrait("Electronic");
		public bool TargetObject(PlayfieldObject target)
		{
			Inventory.DestroyItem(Item);
			VoodooActive voodoo = Inventory.AddItem<VoodooActive>(Count);
			voodoo.Victim = (Agent)target;
			return true;
		}
		public CustomTooltip TargetCursorText(PlayfieldObject target)
		{
			if (target is Agent agent)
			{
				if (agent.dead) return gc.nameDB.GetName("VoodooDeadAgent", "Interface");
				if (agent.mechFilled || agent.mechEmpty || agent.statusEffects.hasTrait("Electronic"))
					return gc.nameDB.GetName("VoodooElectronic", "Interface");

				return gc.nameDB.GetName("VoodooBind", "Interface");
			}
			else return gc.nameDB.GetName("VoodooNotAgent", "Interface");
		}
	}
	[ItemCategories(RogueCategories.Social, RogueCategories.Stealth, RogueCategories.Weird)]
	public class VoodooActive : CustomItem, IItemCombinable, IDoUpdate
	{
		public Agent Victim { get; set; }
		public Bullet LastFiredBullet { get; set; }
		public override void SetupDetails()
		{
			Item.itemType = ItemTypes.Combine;
			Item.itemValue = 100;
			Item.stackable = true;
			Item.hasCharges = true;
		}

		private int actualCount;
		public float Cooldown;
		public void Update()
		{
			if (Victim.dead || !Victim.isActiveAndEnabled) CombineItems(Item);
			if (Cooldown > 0f)
			{
				Cooldown = Math.Max(Cooldown - Time.deltaTime, 0f);
				int displayCount = (int)(Cooldown * 10);
				Count = displayCount > 0 ? displayCount : actualCount;
			}
		}
		public bool CombineFilter(InvItem other) => Item == other || other.itemType == ItemTypes.Consumable
			|| other.itemType == ItemTypes.WeaponMelee || other.itemType == ItemTypes.WeaponProjectile;
		public bool CombineItems(InvItem other)
		{
			if (Cooldown != 0f) return true;
			float cooldown;
			if (Item == other)
			{
				Inventory.DestroyItem(Item);
				if (--Count > 0) Inventory.AddItem<VoodooBlank>(Count);
				return true;
			}
			else if (other.itemType == ItemTypes.Consumable)
			{
				new ItemFunctions().UseItem(other, Victim);
				cooldown = Mathf.Clamp(other.itemValue / 50f, 0.5f, 1.5f);
			}
			else if (other.itemType == ItemTypes.WeaponMelee)
			{
				float damage = other.meleeDamage / 2f;
				damage *= 1f + Owner.strengthStatMod / 3f;
				damage *= Owner.agentSpriteTransform.localScale.x;
				if (Owner.statusEffects.hasTrait("Strength")) damage *= 1.5f;
				if (Owner.statusEffects.hasTrait("StrengthSmall")) damage *= 1.25f;
				if (Owner.statusEffects.hasTrait("Weak")) damage *= 0.5f;
				if (Owner.statusEffects.hasTrait("Withdrawal")) damage *= 0.75f;

				Inventory.DepleteMelee(Mathf.Clamp((int)(damage / Owner.agentSpriteTransform.localScale.x), 0, 15), other);
				Quaternion rn = UnityEngine.Random.rotation;
				Victim.statusEffects.ChangeHealth(-(int)damage, Owner);
				Victim.movement.KnockBackBullet(rn, 80f, true, Owner);
				Victim.relationships.SetRel(Owner, "Hateful");
				Victim.relationships.AddRelHate(Owner, 5);
				gc.audioHandler.Play(Victim, other.hitSoundType == "Cut"
					? damage < 12f ? "MeleeHitAgentCutSmall" : "MeleeHitAgentCutLarge"
					: damage < 10f ? "MeleeHitAgentSmall" : "MeleeHitAgentLarge");
				string effect = "BloodHit";
				if (Victim.inhuman) effect += "Yellow";
				if (damage >= 10f) effect += damage < 15f ? "Med" : "Large";
				gc.spawnerMain.SpawnParticleEffect(effect, Victim.tr.position, rn.eulerAngles.z);
				cooldown = Mathf.Clamp(damage / 15, 0.5f, 1f);
			}
			else if (other.itemType == ItemTypes.WeaponProjectile)
			{
				InvItem prev = Inventory.equippedWeapon;
				Inventory.equippedWeapon = other;
				Owner.gun.Shoot(false, false, false);
				Inventory.equippedWeapon = prev;
				Bullet bullet = LastFiredBullet;
				cooldown = Owner.weaponCooldown;
				bullet.curPosition = bullet.transform.position = Victim.curPosition;
				bullet.rb.velocity = Victim.rb.velocity;
			}
			else return true;
			actualCount = Count;
			Cooldown = cooldown;
			return true;
		}
		public CustomTooltip CombineTooltip(InvItem other) => "456";
		public CustomTooltip CombineCursorText(InvItem other) => string.Empty;
	}
	public class NuclearBriefcase : CustomItem, IItemUsable
	{
		public override void SetupDetails()
		{
			Item.itemType = ItemTypes.Tool;
			Item.initCount = 1;
			Item.rewardCount = 1;
			Item.itemValue = 300;
			Item.cantBeCloned = true;
			Item.goesInToolbar = true;
		}
		public bool UseItem()
		{
			Count--;
			OpenNuclearBriefcase open = Inventory.AddItem<OpenNuclearBriefcase>(1);
			gc.audioHandler.Play(Owner, "DoorOpen");
			Inventory.StartCoroutine(open.BriefcaseChecker());
			return true;
		}
	}
	public class OpenNuclearBriefcase : CustomItem, IItemTargetableAnywhere
	{
		public override void SetupDetails()
		{
			Item.itemType = ItemTypes.Tool;
			Item.initCount = 1;
			Item.rewardCount = 1;
			Item.itemValue = 300;
			Item.cantBeCloned = true;
			Item.goesInToolbar = true;
		}
		private float timer;
		public IEnumerator BriefcaseChecker()
		{
			timer = 3f;
			while (timer > 0)
			{
				yield return null;
				if (Item.invItemCount is 0 || Item.database != Inventory) yield break;
				if (Item.invInterface.draggedInvItem == Item || Item.invInterface.mainGUI.targetItem == Item
					|| Item.invInterface.Slots[Item.slotNum].overSlot)
				{
					timer = 3f;
				}
				timer -= Time.unscaledDeltaTime;
			}
			Count--;
			Inventory.AddItem<NuclearBriefcase>(1);
			gc.audioHandler.Play(Owner, "DoorClose");
		}
		public bool TargetFilter(Vector2 pos) => true;
		public bool TargetPosition(Vector2 pos)
		{
			Count--;
			gc.StartCoroutine(Explode(pos));
			return true;
		}
		private IEnumerator Explode(Vector2 pos)
		{
			BombFalling bomb = gc.spawnerMain.SpawnBombFalling(pos, string.Empty);
			gc.StartCoroutine(bomb.DropBomb());
			Danger danger = gc.spawnerMain.SpawnDanger(Owner, "Major", "Spooked");
			danger.tr.position = bomb.tr.position;
			danger.curPosition = danger.tr.position;
			danger.tr.parent = gc.dangersNest.transform;
			danger.timer = 5f;

			gc.audioHandler.Play(Owner, "ArmedMine");

			for (int i = 3; i >= 0; i--)
			{
				gc.spawnerMain.SpawnStatusText(Owner, "Countdown", i.ToString());
				yield return new WaitForSeconds(0.375f);
				gc.audioHandler.Stop(Owner, "ArmedMine");
				gc.audioHandler.Play(Owner, "ArmedMine");
				yield return new WaitForSeconds(0.375f);
			}

			gc.StartCoroutine(gc.SetSecondaryTimeScale(0.05f, 0.45f));
			yield return new WaitForSeconds(0.025f);
			gc.audioHandler.Stop(Owner, "ArmedMine");

			Explosion explosion = gc.spawnerMain.SpawnExplosion(Owner, pos, "Ridiculous");
			for (int i = 10; i < 20; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					float angle = UnityEngine.Random.Range(0f, 360f);
					gc.spawnerMain.SpawnParticleEffect("Explosion", explosion.tr.position, angle).transform.localScale = new Vector3(i, i, i);
				}
			}
			for (int i = 0; i < 10; i++)
				explosion.gc.audioHandler.Play(explosion, "ExplodeRidiculous");

			aToI.suppress = true;
			gc.tileInfo.clearingDoorWindowWalls = true;
			explosion.agent = Owner;
			explosion.destroySteel = true;
			explosion.damage = 488755541;
			explosion.circleCollider2D.enabled = true;
			aToI.canHit.SetValue(explosion, 1.1f);

			explosion.circleCollider2D.radius = 0;
			yield return null;
			explosion.circleCollider2D.radius = 10;
			yield return null;

			const float time = 1f;
			for (int i = 0; i < 240; i++)
			{
				explosion.circleCollider2D.radius += 0.25f;
				yield return new WaitForSeconds(time / 240f);
			}

			yield return new WaitForSeconds(0.5f);

			gc.audioHandler.MusicStop();

			gc.tileInfo.clearingDoorWindowWalls = false;
			aToI.suppress = false;
		}
		public CustomTooltip TargetCursorText(Vector2 pos) => gc.nameDB.GetName("UseNuclearBriefcase", "Interface");
	}
	[ItemCategories(RogueCategories.Supplies, RogueCategories.Technology, RogueCategories.Usable)]
	public class LootBox : CustomItem, IItemUsable
	{
		public override void SetupDetails()
		{
			Item.itemType = ItemTypes.Tool;
			Item.itemValue = 40;
			Item.initCount = 2;
			Item.rewardCount = 3;
			Item.stackable = true;
			Item.goesInToolbar = true;
			Item.cantBeCloned = true;

			int rnd = new System.Random().Next(3) + 1;
			if (rnd != 1)
				Item.LoadItemSprite($"LootBox{rnd}");
		}
		public bool UseItem()
		{
			List<Unlock> unlockPool = gc.sessionDataBig.unlocks.FindAll(u => u.unlockType == "Item");
			List<InvItem> pool = new List<InvItem>();

			System.Random rnd = new System.Random();
			for (int i = 0; i < 3; i++)
			{
				Unlock u;
				InvItem item;
				do
				{
					u = unlockPool[rnd.Next(unlockPool.Count)];
					item = new InvItem { invItemName = u.unlockName };
					item.SetupDetails(false);
				}
				while (item.itemValue < 1 || item.initCount == 0);

				item.invItemCount = item.initCount;
				pool.Add(item);
			}

			InvItem selected = pool[0];
			int selectedCost = Owner.determineMoneyCost(selected, selected.itemValue, "");
			for (int i = 1; i < pool.Count; i++)
			{
				int cost = Owner.determineMoneyCost(pool[i], pool[i].itemValue, "");
				if (cost < selectedCost)
				{
					selected = pool[i];
					selectedCost = cost;
				}
			}

			Count--;
			Inventory.AddItem(selected);
			gc.audioHandler.Play(Owner, "BeginCombine");

			return true;
		}
	}
	public class PortableAmmoDispenser : CustomItem, IItemCombinable
	{
		public override void SetupDetails()
		{
			Item.itemType = ItemTypes.Combine;
			Item.itemValue = 80;
			Item.initCount = 1;
			Item.rewardCount = 1;
			Item.stackable = true;
			Item.hasCharges = true;
		}

		private int actualCount;
		public float Cooldown;
		public bool CombineFilter(InvItem other) => Item == other || other.itemType == ItemTypes.WeaponProjectile && !other.noRefills;
		public bool CombineItems(InvItem other)
		{
			int amountToRefill = other.maxAmmo - other.invItemCount;
			float singleCost = (float)other.itemValue / other.maxAmmo;
			if (Owner.oma.superSpecialAbility && (Owner.agentName == "Soldier" || Owner.agentName == "Doctor"))
				singleCost = 0f;
			if (other.invItemCount >= other.maxAmmo)
			{
				Owner.SayDialogue("AmmoDispenserFull");
				Owner.gc.audioHandler.Play(Owner, "CantDo");
			}
			else if (Owner.inventory.money.invItemCount < amountToRefill * singleCost)
			{
				int affordableAmount = (int)Mathf.Floor(Owner.inventory.money.invItemCount / singleCost);
				if (affordableAmount == 0)
				{
					Owner.SayDialogue("NeedCash");
					Owner.gc.audioHandler.Play(Owner, "CantDo");
					return true;
				}
				Owner.inventory.SubtractFromItemCount(Owner.inventory.money, (int)Mathf.Ceil(affordableAmount * singleCost));
				other.invItemCount += affordableAmount;
				Owner.SayDialogue("AmmoDispenserFilled");
				Owner.gc.audioHandler.Play(Owner, "BuyItem");
				new ItemFunctions().UseItemAnim(Item, Owner);
			}
			else
			{
				Owner.inventory.money.invItemCount -= (int)Mathf.Ceil(amountToRefill * singleCost);
				other.invItemCount = other.maxAmmo;
				Owner.SayDialogue("AmmoDispenserFilled");
				Owner.gc.audioHandler.Play(Owner, "BuyItem");
				new ItemFunctions().UseItemAnim(Item, Owner);
			}
			return true;
		}
		public CustomTooltip CombineTooltip(InvItem other)
        {
			if (other.invItemName == "PortableAmmoDispenser") return default;
			int amountToRefill = other.maxAmmo - other.invItemCount;
			if (amountToRefill < 1) return default;
			float singleCost = (float)other.itemValue / other.maxAmmo;
			if (Owner.oma.superSpecialAbility && (Owner.agentName == "Soldier" || Owner.agentName == "Doctor"))
				singleCost = 0f;
			int amount = (int)Mathf.Ceil(amountToRefill * singleCost);
			return "$" + amount;
		}
		public CustomTooltip CombineCursorText(InvItem other) => string.Empty;
	}
	[ItemCategories(RogueCategories.Supplies, RogueCategories.Usable)]
	public class Portable_Barbecue_Inactive : CustomItem, IItemCombinable
	{
		public override void SetupDetails()
		{
			Item.itemType = ItemTypes.Combine;
			Item.itemValue = 85;
			Item.stackable = true;
			Item.hasCharges = true;
		}
		public bool CombineFilter(InvItem other) => other.invItemName == "CigaretteLighter"
			|| other.invItemName == "Flamethrower" && other.invItemCount > 0;
		public bool CombineItems(InvItem other)
		{
			if (!CombineFilter(other)) return false;
			if (other.invItemName == "Flamethrower")
			{
				Inventory.SubtractFromItemCount(other, 45);
				Inventory.DestroyItem(Item);
				Inventory.AddItem<Portable_Barbecue_Active>(Count);
			}
			else if (other.invItemName == "CigaretteLighter")
			{
				Inventory.DestroyItem(Item);
				Inventory.AddItem<Portable_Barbecue_Active>(Count);
			}
			return true;
		}
		public CustomTooltip CombineTooltip(InvItem other) => default;
		public CustomTooltip CombineCursorText(InvItem other) => default;
	}
	[ItemCategories(RogueCategories.Supplies, RogueCategories.Usable)]
	public class Portable_Barbecue_Active : CustomItem, IItemCombinable
	{
		public override void SetupDetails()
		{
			Item.itemType = ItemTypes.Combine;
			Item.itemValue = 85;
			Item.stackable = true;
			Item.hasCharges = true;
		}
		public bool CombineFilter(InvItem other) => other.invItemName == "Fud";
		public bool CombineItems(InvItem other)
		{
			if (!CombineFilter(other)) return false;
			if (other.invItemName == "Fud")
            {
				Inventory.SubtractFromItemCount(other, 1);
				Inventory.AddItem("HotFud", 1);
			}
			return true;
		}
		public CustomTooltip CombineTooltip(InvItem other) => default;
		public CustomTooltip CombineCursorText(InvItem other) => default;
	}
	[ItemCategories(RogueCategories.Supplies, RogueCategories.Technology, RogueCategories.Usable)]
	public class Air_Support_Phone : CustomItem, IItemTargetableAnywhere
	{
		public override void SetupDetails()
		{
			Item.itemType = ItemTypes.Tool;
			Item.initCount = 1;
			Item.rewardCount = 1;
			Item.itemValue = 75;
			Item.cantBeCloned = true;
			Item.goesInToolbar = true;
		}
		public bool TargetFilter(Vector2 pos) => true;
		public bool TargetPosition(Vector2 pos)
		{
			Count--;
			gc.StartCoroutine(Explode(pos));
			return true;
		}
		private IEnumerator Explode(Vector2 pos)
		{
			BombFalling bomb = gc.spawnerMain.SpawnBombFalling(pos, string.Empty);
			gc.StartCoroutine(bomb.DropBomb());
			Danger danger = gc.spawnerMain.SpawnDanger(Owner, "Major", "Spooked");
			danger.tr.position = bomb.tr.position;
			danger.curPosition = danger.tr.position;
			danger.tr.parent = gc.dangersNest.transform;
			danger.timer = 5f;
			gc.audioHandler.Play(Owner, "ArmedMine");
			for (int i = 3; i >= 0; i--)
			{
				gc.spawnerMain.SpawnStatusText(Owner, "Countdown", i.ToString());
				yield return new WaitForSeconds(0.375f);
				gc.audioHandler.Stop(Owner, "ArmedMine");
				gc.audioHandler.Play(Owner, "ArmedMine");
				yield return new WaitForSeconds(0.375f);
			}
			yield return new WaitForSeconds(0.025f);
			gc.audioHandler.Stop(Owner, "ArmedMine");
			Explosion explosion = gc.spawnerMain.SpawnExplosion(Owner, pos, "Normal");
			gc.spawnerMain.SpawnParticleEffect("Explosion", explosion.tr.position, 0).transform.localScale = new Vector3(1, 1, 1);
			explosion.agent = Owner;
		}
		public CustomTooltip TargetCursorText(Vector2 pos) => gc.nameDB.GetName("Use_Air_Support_Phone", "Interface");
	}
}
