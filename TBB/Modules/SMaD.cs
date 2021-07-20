using System;
using System.Linq;
using BepInEx;
using RogueLibsCore;
using UnityEngine;
using HarmonyLib;
using System.Reflection.Emit;
using System.Collections.Generic;
using System.IO;

namespace TBB
{
    class SMaD
    {
        public static List<ItemUnlock> Items = new List<ItemUnlock>();
        public static void SetActive(bool isEnabled)
        {
            foreach (ItemUnlock unlock in Items)
            {
                unlock.IsAvailable = isEnabled;
                unlock.IsAvailableInCC = isEnabled;
                unlock.IsAvailableInItemTeleporter = isEnabled;
            }
        }
        public void Awake()
        {
            ItemBuilder builder = RogueLibs.CreateCustomItem<Blind_Mushroom>()
                       .WithName(new CustomNameInfo
                       {
                           English = "Crepe Mushroom",
                           Russian = "Блино-гриб"
                       }).WithDescription(new CustomNameInfo
                       {
                           English = "Everyone's favorite mushroom from the game SUPER-CREPE. Feel yourself Super-Crepe!",
                           Russian = "Всеми любимый гриб из игры СУПЕР-БЛИН. Почувствуйте себя Супер-Блином!"
                       })
                       .WithSprite(Properties.Resources.Blind_Mushroom)
                       .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 5 });
            Items.Add(builder.Unlock);
            builder = RogueLibs.CreateCustomItem<JoCake>()
                           .WithName(new CustomNameInfo
                           {
                               English = "JoCake",
                               Russian = "Шуторт"
                           }).WithDescription(new CustomNameInfo
                           {
                               English = "This cake was made by 3 unknown comedians, being very fat and nutritious makes the eater immediately make a joke. The party with these cakes will be very fun!",
                               Russian = "Этот торт был изготовлен 3 неизвестными комиками, будучи весьма жирным и питательным заставляет съевшего немедленно пошутить. Вечеринка с такими тортами будет очень веселая!"
                           })
                           .WithSprite(Properties.Resources.JoCake)
                           .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 3 });
            Items.Add(builder.Unlock);
            builder = RogueLibs.CreateCustomItem<Steal_Apple>()
               .WithName(new CustomNameInfo
               {
                   English = "Steal Apple",
                   Russian = "Стальное яблоко"
               }).WithDescription(new CustomNameInfo
               {
                   English = "The latest development of Mech.Food.Industrial and yes.. this apple... steel apple.. The essence is simple when eaten, it envelops the organs and skin with a special alloy that can delay bullets and reduce damage from them. However, it big damages the body from the inside..It is usefull, isn't it?",
                   Russian = "Новейшая разработка Mech.Food.Industrial и да.. это яблоко... стальное яблоко.. Суть проста при съедении обволакивает органы и кожу особым сплавом который способен задерживать пули и снижать ущерб от них. Однако крайне сильно повреждает тело изнутри..Полезно, не правда ли?"
               })
               .WithSprite(Properties.Resources.steal_apple)
               .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 8 });
            Items.Add(builder.Unlock);
            builder = RogueLibs.CreateCustomItem<Tentacle_Kraken>()
               .WithName(new CustomNameInfo
               {
                   English = "Tentacle of the Kraken",
                   Russian = "Щупальце Кракена"
               }).WithDescription(new CustomNameInfo
               {
                   English = "Any Chinese would give a fortune for such a tentacle! What is unique about it? It has strong healing properties,heals all wounds, but gives you a taste of seasickness. Bon Appetit!",
                   Russian = "За такое щупальце любой китаец отдал бы состояние! Что в нём уникального? Оно обладая сильными целительными свойствами,залечивает все раны, но даёт вам попробовать на вкус морскую болезнь. Приятного аппетита!"
               })
               .WithSprite(Properties.Resources.tentacle_kraken)
               .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 5 });
            Items.Add(builder.Unlock);
            RoguePatcher Patcher = new RoguePatcher(Main.MainInstance, typeof(SMaD));
            RogueLibs.CreateCustomAudio("Blind_Mushroom_Use", Properties.Resources.Blind_Mushroom_Use, AudioType.OGGVORBIS);
            RogueLibs.CreateCustomAudio("Steel_Apple_Walk", Properties.Resources.Steel_Apple_Walk, AudioType.OGGVORBIS);
        }
        public class Blind_Mushroom : CustomItem, IItemUsable
        {
            public override void SetupDetails()
            {
                Item.itemType = ItemTypes.Food;
                Item.itemValue = 35;
                Item.initCount = 1;
                Item.rewardCount = 1;
                Item.healthChange = 15;
                Item.stackable = true;
                Item.hasCharges = true;
                Item.goesInToolbar = true;
                Item.cantBeCloned = false;
            }
            public bool UseItem()
            {
                int heal = new ItemFunctions().DetermineHealthChange(Item, Owner);
                Owner.statusEffects.ChangeHealth(heal);
                if (Owner.HasTrait("HealthItemsGiveFollowersExtraHealth") || Owner.HasTrait("HealthItemsGiveFollowersExtraHealth2"))
                {
                    new ItemFunctions().GiveFollowersHealth(Owner, heal);
                }
                Owner.statusEffects.AddStatusEffect("Invincible", 25);
                Count--;
                gc.audioHandler.Play(Owner, "Blind_Mushroom_Use");
                return true;
            }
        }
        public class Steal_Apple : CustomItem, IItemUsable
        {
            public override void SetupDetails()
            {
                Item.itemType = ItemTypes.Food;
                Item.itemValue = 60;
                Item.initCount = 1;
                Item.rewardCount = 1;
                Item.healthChange = -75;
                Item.stackable = true;
                Item.hasCharges = true;
                Item.goesInToolbar = true;
                Item.cantBeCloned = false;
            }
            public bool UseItem()
            {
                int heal = new ItemFunctions().DetermineHealthChange(Item, Owner);
                Owner.statusEffects.ChangeHealth(heal);
                if (Owner.HasTrait("HealthItemsGiveFollowersExtraHealth") || Owner.HasTrait("HealthItemsGiveFollowersExtraHealth2"))
                {
                    new ItemFunctions().GiveFollowersHealth(Owner, heal);
                }
                Owner.statusEffects.AddStatusEffect("Steal_Apple_Effect", 9999);
                Count--;
                gc.audioHandler.Play(Owner, "UseFood");
                return true;
            }
        }
        [EffectParameters(EffectLimitations.RemoveOnDeath | EffectLimitations.RemoveOnKnockOut)]
        public class Tentacle_Kraken : CustomItem, IItemUsable
        {
            public override void SetupDetails()
            {
                Item.itemType = ItemTypes.Food;
                Item.itemValue = 95;
                Item.initCount = 1;
                Item.rewardCount = 1;
                Item.healthChange = 180;
                Item.stackable = true;
                Item.hasCharges = true;
                Item.goesInToolbar = true;
                Item.cantBeCloned = true;
            }
            public bool UseItem()
            {
                int heal = new ItemFunctions().DetermineHealthChange(Item, Owner);
                Owner.statusEffects.ChangeHealth(heal);
                if (Owner.HasTrait("HealthItemsGiveFollowersExtraHealth") || Owner.HasTrait("HealthItemsGiveFollowersExtraHealth2"))
                {
                    new ItemFunctions().GiveFollowersHealth(Owner, heal);
                }
                Owner.statusEffects.AddStatusEffect("Tentacle_Kraken_Effect", 25);
                Count--;
                gc.audioHandler.Play(Owner, "AgentAnnoyed");
                return true;
            }
        }
        public class JoCake : CustomItem, IItemUsable
        {
            public override void SetupDetails()
            {
                Item.itemType = ItemTypes.Food;
                Item.itemValue = 25;
                Item.initCount = 1;
                Item.rewardCount = 1;
                Item.healthChange = 15;
                Item.stackable = true;
                Item.hasCharges = true;
                Item.goesInToolbar = true;
                Item.cantBeCloned = false;
            }
            public bool UseItem()
            {
                string prev = Owner.specialAbility;
                Owner.specialAbility = "Joke";
                Owner.statusEffects.PressedSpecialAbility();
                Owner.specialAbility = prev;
                int heal = new ItemFunctions().DetermineHealthChange(Item, Owner);
                Owner.statusEffects.ChangeHealth(heal);
                if (Owner.HasTrait("HealthItemsGiveFollowersExtraHealth") || Owner.HasTrait("HealthItemsGiveFollowersExtraHealth2"))
                {
                    new ItemFunctions().GiveFollowersHealth(Owner, heal);
                }
                Count--;
                //gc.audioHandler.Play(Owner, "UseFood");
                return true;
            }
        }
        [EffectParameters()]
        public class Steal_Apple_Effect : CustomEffect
        {
            [RLSetup]
            public static void Setup()
            {
                RogueLibs.CreateCustomEffect<Steal_Apple_Effect>()
                            .WithName(new CustomNameInfo
                            {
                                English = "Steel Apple shell",
                                Russian = "Оболочка Стального Яблока"
                            })
                            .WithDescription(new CustomNameInfo
                            {
                                English = "<color=#093794>Now you and your organs are protected from bullets, enjoy the weight of it!</color>",
                                Russian = "<color=#093794>Теперь вы и ваши органы защищены от пуль и огня, наслаждайтесь это тяжестью!</color>"
                            });
            }
            public override int GetEffectTime() => 9999;
            public override int GetEffectHate() => 0;
            public override void OnAdded()
            {
                Owner.AddTrait("ResistBullets");
                Owner.AddTrait("ResistDamageLarge");
                Owner.AddTrait("ResistFire");
                Owner.SetSpeed(Owner.speedStatMod - 3);
                Owner.SetStrength(Owner.strengthStatMod + 2);
            }
            public override void OnRemoved() 
            {
                Owner.statusEffects.RemoveTrait("ResistBullets");
                Owner.statusEffects.RemoveTrait("ResistDamageLarge");
                Owner.statusEffects.RemoveTrait("ResistFire");
                Owner.SetSpeed(Owner.speedStatMod + 3);
                Owner.SetStrength(Owner.strengthStatMod - 2);
            }
            public override void OnUpdated(EffectUpdatedArgs e)
            {
                    e.UpdateDelay = 4f;
                    gc.audioHandler.Play(Owner, "Steel_Apple_Walk");
                    Noise noise = gc.spawnerMain.SpawnNoise(Owner.tr.position, 1f, Owner, "Attract", Owner);
                    noise.distraction = true;
            }
        }
        public class Tentacle_Kraken_Effect : CustomEffect
        {
            [RLSetup]
            public static void Setup()
            {
                RogueLibs.CreateCustomEffect<Tentacle_Kraken_Effect>()
                            .WithName(new CustomNameInfo
                            {
                                English = "Seasickness",
                                Russian = "Морская болезнь"
                            })
                            .WithDescription(new CustomNameInfo
                            {
                                English = "<color=#167d0f>*puking*</color> Don't eat this anymore!",
                                Russian = "<color=#167d0f>*проблевавшись*</color> Больше не ешьте это!"
                            });
            }
            public override int GetEffectTime() => 25;
            public override int GetEffectHate() => 5;
            public override void OnAdded()
            {
                Owner.hasSecretKiller = true;
                Owner.lastHitByAgent = Effect.causingAgent;
                Owner.justHitByAgent2 = Effect.causingAgent;
                Owner.deathMethod = "Poison";
                if (Effect.causingAgent != null)
                    Owner.deathKiller = Effect.causingAgent.agentName;
                if (Effect.curTime != Effect.startTime - 1)
                    Owner.gc.audioHandler.Play(Owner, "WithdrawalDamage");
                Owner.ChangeHealth(Owner.gc.challenges.Contains("LowHealth") ? -1f : -2f);
                Owner.SetSpeed(Owner.speedStatMod - 3);
            }
            public override void OnRemoved()
            {
                Owner.SetSpeed(Owner.speedStatMod + 3);
            }
            public override void OnUpdated(EffectUpdatedArgs e)
            {
                e.UpdateDelay = 0.5f;
                CurrentTime--;
            }
        }
    }
}
