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
            builder = RogueLibs.CreateCustomItem<EvilCake>()
                           .WithName(new CustomNameInfo
                           {
                               English = "Suspicious cake",
                               Russian = "Подозрительный торт"
                           }).WithDescription(new CustomNameInfo
                           {
                               English = "This cake was made by 3 unknown comedians, being very fat and nutritious makes the eater immediately make a joke. The party with these cakes will be very fun!",
                               Russian = "Этот торт был изготовлен 3 неизвестными комиками, будучи весьма жирным и питательным заставляет съевшего немедленно пошутить. Вечеринка с такими тортами будет очень веселая!"
                           })
                           .WithSprite(Properties.Resources.Evil_Cake)
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
               .WithSprite(Properties.Resources.Steal_Apple)
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
               .WithSprite(Properties.Resources.Kraken_Tentacle)
               .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 5 });
            Items.Add(builder.Unlock);
            builder = RogueLibs.CreateCustomItem<BOOMCorn>()
               .WithName(new CustomNameInfo
               {
                   English = "BOOMcorn",
                   Russian = "BOOMкорн"
               }).WithDescription(new CustomNameInfo
               {
                   English = "This item was still in the Hitman beta, but for their game it is too refined a way to kill. If you wanted to become a kamikaze, here's your chance.  As you can understand, this is not popcorn, but just a bomb in a XXL popcorn bag.",
                   Russian = "Этот BOOMкорн был ещё в бете Hitman`а, но для их игры это слишком изысканный способ убийства. Если вы хотели стать камикадзе, то вот ваш шанс.  Как можно понять это не попкорн, а всего лишь бомба в XXL пакете от попкорна."
               })
               .WithSprite(Properties.Resources.Boomkorn)
               .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 3 });
            Items.Add(builder.Unlock);
            builder = RogueLibs.CreateCustomItem<Vent_IceCream>()
               .WithName(new CustomNameInfo
               {
                   English = "Conditioner Icecream",
                   Russian = "Самоохлаждающееся мороженое"
               }).WithDescription(new CustomNameInfo
               {
                   English = "Is someone tired of their ice cream constantly melting? Well, now it will freeze together with the ice cream, because the ice cream has a built-in air conditioner! Yes, you heard right!",
                   Russian = "Кому-то надоело что его мороженное постоянно тает? Ну, теперь он замёрзнет вместе с мороженным, ведь в мороженное встроен кондиционер! Да-да вы не ослышались!"
               })
               .WithSprite(Properties.Resources.Vent_Icecream)
               .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 5 });
            Items.Add(builder.Unlock);
            builder = RogueLibs.CreateCustomItem<BloodDonut>()
               .WithName(new CustomNameInfo
               {
                   English = "Blood Donut",
                   Russian = "Кровавый пончик"
               }).WithDescription(new CustomNameInfo
               {
                   English = "Doughnuts themselves are very nutritious, but only energetically, now imagine that there is a doughnut that will be nutritious for your blood, replenishing the number of red blood cells in it, but this all takes time and it is better not to move during the replenishment of red blood cells.",
                   Russian = "Сами по себе пончики очень питательны, но только энергетически, теперь представьте что есть пончик который будет питателен и для вашей крови восполняя количество эритроцитов в ней, однако это всё занимает время и лучше не двигаться во время восполнения эритроцитов."
               })
               .WithSprite(Properties.Resources.Blood_Donut)
               .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 5 });
            Items.Add(builder.Unlock);
            builder = RogueLibs.CreateCustomItem<Brain_Jellyfish>()
               .WithName(new CustomNameInfo
               {
                   English = "Blood Donut",
                   Russian = "Кровавый пончик"
               }).WithDescription(new CustomNameInfo
               {
                   English = "Doughnuts themselves are very nutritious, but only energetically, now imagine that there is a doughnut that will be nutritious for your blood, replenishing the number of red blood cells in it, but this all takes time and it is better not to move during the replenishment of red blood cells.",
                   Russian = "Сами по себе пончики очень питательны, но только энергетически, теперь представьте что есть пончик который будет питателен и для вашей крови восполняя количество эритроцитов в ней, однако это всё занимает время и лучше не двигаться во время восполнения эритроцитов."
               })
               .WithSprite(Properties.Resources.Brain_Jellyfish)
               .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 4 });
            Items.Add(builder.Unlock);
            RoguePatcher Patcher = new RoguePatcher(Main.MainInstance, typeof(SMaD));
            RogueLibs.CreateCustomAudio("Blind_Mushroom_Use", Properties.Resources.Blind_Mushroom_Use, AudioType.OGGVORBIS);
            RogueLibs.CreateCustomAudio("Steel_Apple_Walk", Properties.Resources.Steel_Apple_Walk, AudioType.OGGVORBIS);
            RogueLibs.CreateCustomAudio("Steal_Apple_Use", Properties.Resources.Steal_Apple_Use, AudioType.OGGVORBIS);
            RogueLibs.CreateCustomAudio("Evil_Cake_Use", Properties.Resources.Evil_Cake_Use, AudioType.OGGVORBIS);
            RogueLibs.CreateCustomAudio("BOOMCorn_Use", Properties.Resources.BOOMCorn_Use, AudioType.OGGVORBIS);
            RogueLibs.CreateCustomAudio("Vent_IceCream_Use", Properties.Resources.CIceCream_Use, AudioType.OGGVORBIS);
            RogueLibs.CreateCustomAudio("BloodDonut_Use", Properties.Resources.BloodDonut_Use, AudioType.OGGVORBIS);
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
                gc.audioHandler.Play(Owner, "Steal_Apple_Use");
                return true;
            }
        }
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
        public class BOOMCorn : CustomItem, IItemUsable
        {
            public override void SetupDetails()
            {
                Item.itemType = ItemTypes.Food;
                Item.itemValue = 25;
                Item.initCount = 1;
                Item.rewardCount = 1;
                Item.stackable = true;
                Item.hasCharges = true;
                Item.goesInToolbar = true;
                Item.cantBeCloned = false;
            }
            public bool UseItem()
            {
                Count--;
                gc.audioHandler.Play(Owner, "BOOMCorn_Use");
                Owner.gc.spawnerMain.SpawnExplosion(Owner, Owner.tr.position, "Normal", false, -1, false, true).agent = Owner;
                return true;
            }
        }
        public class Vent_IceCream : CustomItem, IItemUsable
        {
            public override void SetupDetails()
            {
                Item.itemType = ItemTypes.Food;
                Item.itemValue = 30;
                Item.initCount = 1;
                Item.rewardCount = 1;
                Item.healthChange = 20;
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
                Owner.statusEffects.AddStatusEffect("Frozen" , 10);
                Count--;
                gc.audioHandler.Play(Owner, "Vent_IceCream_Use");
                return true;
            }
        }
        public class BloodDonut : CustomItem, IItemUsable
        {
            public override void SetupDetails()
            {
                Item.itemType = ItemTypes.Food;
                Item.itemValue = 45;
                Item.initCount = 1;
                Item.rewardCount = 1;
                Item.stackable = true;
                Item.hasCharges = true;
                Item.goesInToolbar = true;
                Item.cantBeCloned = true;
            }
            public bool UseItem()
            {
                gc.audioHandler.Play(Owner, "BloodDonut_Use");
                Owner.statusEffects.AddStatusEffect("BloodDonut_Effect");
                Count--;
                return true;
            }
        }
        public class Brain_Jellyfish : CustomItem, IItemUsable
        {
            public override void SetupDetails()
            {
                Item.itemType = ItemTypes.Food;
                Item.itemValue = 40;
                Item.initCount = 1;
                Item.rewardCount = 1;
                Item.healthChange = -15;
                Item.stackable = true;
                Item.hasCharges = true;
                Item.goesInToolbar = true;
                Item.cantBeCloned = true;
            }
            public bool UseItem()
            {
                int heal = new ItemFunctions().DetermineHealthChange(Item, Owner);
                Owner.statusEffects.ChangeHealth(heal);
                Owner.statusEffects.AddStatusEffect("Brain_Jellyfish_Effect", 25);
                Count--;
                gc.audioHandler.Play(Owner, "Blind_Mushroom_Use");
                return true;
            }
        }
        public class EvilCake : CustomItem, IItemUsable
        {
            public override void SetupDetails()
            {
                Item.itemType = ItemTypes.Food;
                Item.itemValue = 25;
                Item.initCount = 1;
                Item.rewardCount = 1;
                Item.stackable = true;
                Item.hasCharges = true;
                Item.goesInToolbar = true;
                Item.cantBeCloned = false;
            }
            public bool UseItem()
            {
                Count--;
                Owner.statusEffects.AddStatusEffect("Evil_Cake_Effect");
                gc.audioHandler.Play(Owner, "Evil_Cake_Use");
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
        [EffectParameters(EffectLimitations.RemoveOnDeath | EffectLimitations.RemoveOnKnockOut)]
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
                Owner.SetSpeed(Owner.speedStatMod - 3);
            }
            public override void OnRemoved()
            {
                Owner.SetSpeed(Owner.speedStatMod + 3);
            }
            public override void OnUpdated(EffectUpdatedArgs e)
            {
                e.UpdateDelay = 0.5f;
                Owner.hasSecretKiller = true;
                Owner.lastHitByAgent = Effect.causingAgent;
                Owner.justHitByAgent2 = Effect.causingAgent;
                Owner.deathMethod = "Poison";
                if (Effect.causingAgent != null)
                    Owner.deathKiller = Effect.causingAgent.agentName;
                if (Effect.curTime != Effect.startTime - 1)
                    Owner.gc.audioHandler.Play(Owner, "WithdrawalDamage");
                Owner.ChangeHealth(Owner.gc.challenges.Contains("LowHealth") ? -1f : -2f);
                CurrentTime--;
            }
        }
        [EffectParameters(EffectLimitations.RemoveOnDeath | EffectLimitations.RemoveOnKnockOut)]
        public class BloodDonut_Effect : CustomEffect
        {
            [RLSetup]
            public static void Setup()
            {
                RogueLibs.CreateCustomEffect<BloodDonut_Effect>()
                            .WithName(new CustomNameInfo
                            {
                                English = "Erythrocyte replenishment",
                                Russian = "Восполнение эритроцитов"
                            })
                            .WithDescription(new CustomNameInfo
                            {
                                English = "Yes, you will now have red blood cells that you can bathe a whole zoo in them!",
                                Russian = "Да, у вас сейчас будет эритроцитов что вы сможете в них искупать целый зоопарк!"
                            });
            }
            public override int GetEffectTime() => 60;
            public override int GetEffectHate() => 0;
            public override void OnAdded()
            {
                Owner.speedMax = 0;
            }
            public override void OnRemoved()
            {

            }
            public override void OnUpdated(EffectUpdatedArgs e)
            {
                Owner.ChangeHealth(Owner.gc.challenges.Contains("LowHealth") ? +1f : +1f);
                CurrentTime--;
            }
        }
        [EffectParameters(EffectLimitations.RemoveOnDeath | EffectLimitations.RemoveOnKnockOut)]
        public class Brain_Jellyfish_Effect : CustomEffect
        {
            [RLSetup]
            public static void Setup()
            {
                RogueLibs.CreateCustomEffect<BloodDonut_Effect>()
                            .WithName(new CustomNameInfo
                            {
                                English = "Controlled by Brain Jellyfish",
                                Russian = "Контролируется Мозговой Медузой"
                            })
                            .WithDescription(new CustomNameInfo
                            {
                                English = "TO STING TO STING TO STING!",
                                Russian = "УЖАЛИТЬ УЖАЛИТЬ УЖАЛИТЬ!"
                            });
            }
            public override int GetEffectTime() => 20;
            public override int GetEffectHate() => 5;
            public override void OnAdded()
            {
                Owner.statusEffects.AddTrait("ElectroTouch");
            }
            public override void OnRemoved()
            {
                Owner.statusEffects.RemoveTrait("ElectroTouch");
            }
            public override void OnUpdated(EffectUpdatedArgs e)
            {
                Owner.AddEffect("Enraged", new CreateEffectInfo { SpecificTime = 20, DontShowText = true });
                CurrentTime--;
            }
        }
        [EffectParameters(EffectLimitations.RemoveOnDeath)]
        public class Evil_Cake_Effect : CustomEffect
        {
            [RLSetup]
            public static void Setup()
            {
                RogueLibs.CreateCustomEffect<Evil_Cake_Effect>()
                            .WithName(new CustomNameInfo
                            {
                                English = "<color=#000000>Container for soul</color>",
                                Russian = "<color=#000000>Сосуд для души</color>"
                            })
                            .WithDescription(new CustomNameInfo
                            {
                                English = "<color=#000000>It soon be reborn...</color>",
                                Russian = "<color=#000000>Оно скоро переродится...</color>"
                            });
            }
            public override int GetEffectTime() => 9999;
            public override int GetEffectHate() => 5;
            public override void OnAdded()
            {
                Owner.SetEndurance(Owner.enduranceStatMod - 2);
                Owner.resurrect = true;
            }
            public override void OnRemoved()
            {
                Owner.statusEffects.RemoveAllStatusEffects();
                Owner.statusEffects.RemoveAllTraits();
                Owner.statusEffects.AddTrait("Evil_Cake_Trait");
            }
            public override void OnUpdated(EffectUpdatedArgs e)
            {
                e.UpdateDelay = 0.5f;
                Owner.hasSecretKiller = true;
                Owner.lastHitByAgent = Effect.causingAgent;
                Owner.justHitByAgent2 = Effect.causingAgent;
                Owner.deathMethod = "Poison";
                if (Effect.causingAgent != null)
                    Owner.deathKiller = Effect.causingAgent.agentName;
                if (Effect.curTime != Effect.startTime - 1)
                    Owner.gc.audioHandler.Play(Owner, "WithdrawalDamage");
                Owner.ChangeHealth(Owner.gc.challenges.Contains("LowHealth") ? -1f : -2f);
            }
        }
    }
}
