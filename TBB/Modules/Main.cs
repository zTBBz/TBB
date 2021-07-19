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
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    [BepInProcess("StreetsOfRogue.exe")]
    [BepInDependency(RogueLibs.GUID, "2.0")]
    public class Main : BaseUnityPlugin
    {
        public static BaseUnityPlugin MainInstance;
        public static BepInEx.Logging.ManualLogSource logger;
        /*public static ModFlags enabled;
        public static bool IsEnabled(ModFlags flags) => (enabled & flags) != 0;
        [Flags]
        public enum ModFlags
        {
            ModuleA = 1 << 0,
            ModuleB = 1 << 1,
            ModuleC = 1 << 2,
        }*/
        public const string pluginGuid = "ztbbz.streetsofrogue.tbb";
        public const string pluginName = "TBB";
        public const string pluginVersion = "0.0.1";
        public void Awake()
        {
            RogueFramework.DebugFlags |= DebugFlags.Names;
            RogueLibs.LoadFromAssembly();
            RoguePatcher Patcher = new RoguePatcher(this);
            MainInstance = this;
            logger = Logger;
            new MTP().Awake();
            new SMaD().Awake();
            int score_traits = MTP.Traits.Count;
            logger.LogWarning("[MTP]: Traits count: " + score_traits);
            int score_items = SMaD.Items.Count;
            logger.LogWarning("[SMaD]: Items count: " + score_items);
            RogueLibs.CreateCustomName("SMaD_Off_colored", "Unlock", new CustomNameInfo
            {
                English = "<color=#ff0000ff>Swith off [SMaD]</color>",
                Russian = "<color=#ff0000ff>Выключить [SMaD]</color>"
            });
            RogueLibs.CreateCustomName("SMaD_Off", "Unlock", new CustomNameInfo
            {
                English = "Swith off [SMaD]",
                Russian = "Выключить [SMaD]"
            });
            RogueLibs.CreateCustomName("D_SMaD_Off", "Unlock", new CustomNameInfo
            {
                English = "Changes all the items, etc. of the SMaD module, depending on the name of the button",
                Russian = "Изменяет все предметы и т.д SMaD модуля в зависимости от названия кнопки"
            });
            RogueLibs.CreateCustomName("SMaD_On_colored", "Unlock", new CustomNameInfo
            {
                English = "<color=#008000ff>Swith on [SMaD]</color>",
                Russian = "<color=#008000ff>Включить [SMaD]</color>"
            });
            RogueLibs.CreateCustomName("SMaD_On", "Unlock", new CustomNameInfo
            {
                English = "Swith on [SMaD]",
                Russian = "Включить [SMaD]"
            });
            RogueLibs.CreateCustomName("D_SMaD_On", "Unlock", new CustomNameInfo
            {
                English = "Changes all the items, etc. of the SMaD module, depending on the name of the button",
                Russian = "Изменяет все предметы и т.д SMaD модуля в зависимости от названия кнопки"
            });
            RogueLibs.CreateCustomName("MTP_Off_colored", "Unlock", new CustomNameInfo
            {
                English = "<color=#ff0000ff>Swith off [MTP]</color>",
                Russian = "<color=#ff0000ff>Выключить [MTP]</color>"
            });
            RogueLibs.CreateCustomName("MTP_Off", "Unlock", new CustomNameInfo
            {
                English = "Swith off [MTP]",
                Russian = "Выключить [MTP]"
            });
            RogueLibs.CreateCustomName("D_MTP_Off", "Unlock", new CustomNameInfo
            {
                English = "Changes all the items, etc. of the MTP module, depending on the name of the button",
                Russian = "Изменяет все предметы и т.д MTP модуля в зависимости от названия кнопки"
            });
            RogueLibs.CreateCustomName("MTP_On_colored", "Unlock", new CustomNameInfo
            {
                English = "<color=#008000ff>Swith on [MTP]</color>",
                Russian = "<color=#008000ff>Включить [MTP]</color>"
            });
            RogueLibs.CreateCustomName("MTP_On", "Unlock", new CustomNameInfo
            {
                English = "Swith on [MTP]",
                Russian = "Включить [MTP]"
            });
            RogueLibs.CreateCustomName("D_MTP_On", "Unlock", new CustomNameInfo
            {
                English = "Changes all the items, etc. of the MTP module, depending on the name of the button",
                Russian = "Изменяет все предметы и т.д MTP модуля в зависимости от названия кнопки"
            });
            RogueLibs.CreateCustomUnlock(new SMaD_Switch());
            RogueLibs.CreateCustomUnlock(new MTP_Switch());
            RogueLibs.CreateCustomAudio("Bag_Use", Properties.Resources.Bag_Use, AudioType.OGGVORBIS);
        }
        public class SMaD_Switch : MutatorUnlock
        {
            public SMaD_Switch() : base("SMaD_Switch", true)
            {
                SortingOrder = -50;
                IgnoreStateSorting = true;
            }
            public override void OnPushedButton()
            {
                if (SMaD.Items[0].IsAvailable)
                {
                    SMaD.SetActive(false);
                }
                else
                    SMaD.SetActive(true);
               UpdateButton();
               UpdateMenu();
            }
            public override void UpdateButton()
            {
                base.UpdateButton();
                if (SMaD.Items[0].IsAvailable)
                    Text = gc.nameDB.GetName("SMaD_Off_colored", "Unlock");
                else Text = gc.nameDB.GetName("SMaD_On_colored", "Unlock");
            }
            public override string GetFancyName()
            {
                if (SMaD.Items[0].IsAvailable)
                {
                    return gc.nameDB.GetName("SMaD_Off_colored", "Unlock");
                }
                else
                {
                    return gc.nameDB.GetName("SMaD_Off_colored", "Unlock");
                }
            }
            public override string GetName()
            {
                if (SMaD.Items[0].IsAvailable)
                {
                    return gc.nameDB.GetName("SMaD_Off", "Unlock");
                }
                else
                {
                    return gc.nameDB.GetName("SMaD_On", "Unlock");
                }
            }
            public override string GetDescription()
            {
                if (SMaD.Items[0].IsAvailable)
                {
                    return gc.nameDB.GetName("D_SMaD_Off", "Unlock");
                }
                else
                {
                    return gc.nameDB.GetName("D_SMaD_On", "Unlock");
                }
            }

        }
        public class MTP_Switch : MutatorUnlock
        {
            public MTP_Switch() : base("MTP_Switch", true)
            {
                SortingOrder = -50;
                IgnoreStateSorting = true;
            }
            public override void OnPushedButton()
            {
                if (MTP.Traits[0].IsAvailable)
                {
                    MTP.SetActive(false);
                }
                else
                    MTP.SetActive(true);
               UpdateButton();
               UpdateMenu();
            }
            public override void UpdateButton()
            {
                base.UpdateButton();
                if (MTP.Traits[0].IsAvailable)
                    Text = gc.nameDB.GetName("MTP_Off_colored", "Unlock");
                else Text = gc.nameDB.GetName("MTP_On_colored", "Unlock");
            }
            public override string GetFancyName()
            {
                if (MTP.Traits[0].IsAvailable)
                {
                    return gc.nameDB.GetName("MTP_Off_colored", "Unlock");
                }
                else
                {
                    return gc.nameDB.GetName("MTP_On_colored", "Unlock");
                }
            }
            public override string GetName()
            {
                if (MTP.Traits[0].IsAvailable)
                {
                    return gc.nameDB.GetName("MTP_Off", "Unlock");
                }
                else
                {
                    return gc.nameDB.GetName("MTP_On", "Unlock");
                }
            }
            public override string GetDescription()
            {
                if (MTP.Traits[0].IsAvailable)
                {
                    return gc.nameDB.GetName("D_MTP_Off", "Unlock");
                }
                else
                {
                    return gc.nameDB.GetName("D_MTP_On", "Unlock");
                }
            }

        }
        public class Bag_Low : CustomItem, IItemUsable
        {
            [RLSetup]
            public static void Setup()
            {
                RogueLibs.CreateCustomItem<Bag_Low>()
            .WithName(new CustomNameInfo
            {
                English = "<color=#a52a2aff>Horrible</color> Traveler's Bag",
                Russian = "<color=#a52a2aff>Ужасный</color> Мешок Путешественника"
            })
            .WithDescription(new CustomNameInfo
            {
                English = "That bag from far lands, what does he contains?",
                Russian = "Мешок из далёких земель, что же в нём?"
            })
            .WithSprite(Properties.Resources.Bag)
            .WithUnlock(new ItemUnlock { UnlockCost = 20, CharacterCreationCost = 9999 });
            }
            public override void SetupDetails()
            {
                Item.itemType = ItemTypes.Tool;
                Item.itemValue = 40;
                Item.initCount = 1;
                Item.rewardCount = 1;
                Item.stackable = true;
                Item.hasCharges = true;
                Item.goesInToolbar = true;
                Item.cantBeCloned = false;
            }
            public void SetSmallCount(InvItem item)
            => item.invItemCount = item.isArmor || item.isArmorHead || item.hasCharges || item.isWeapon && item.itemType != ItemTypes.WeaponThrown ? item.initCount : 1;
            public bool UseItem()
            {
                List<Unlock> unlockPool = gc.sessionDataBig.unlocks.FindAll(u => u.unlockType == "Item");
                List<InvItem> pool = new List<InvItem>();
                System.Random rnd = new System.Random();
                for (int i = 0; i < 2; i++)
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
                    SetSmallCount(item);
                    pool.Add(item);
                }
                Inventory.AddItem(pool[0]);
                Inventory.AddItem(pool[1]);
                Count--;
                gc.audioHandler.Play(Owner, "Bag_Use");
                return true;
            }
        }
        public class Bag_Low_5 : CustomItem, IItemUsable
        {
            [RLSetup]
            public static void Setup()
            {
                RogueLibs.CreateCustomItem<Bag_Low_5>()
                .WithName(new CustomNameInfo
                {
                     English = "<color=#808080ff>Normal</color> Traveler's Bag",
                     Russian = "<color=#808080ff>Нормальный</color> Мешок Путешественника"
                })
                .WithDescription(new CustomNameInfo
                {
                     English = "That bag from far lands, what does he contains?",
                     Russian = "Мешок из далёких земель, что же в нём?"
                })
                .WithSprite(Properties.Resources.Bag)
                .WithUnlock(new ItemUnlock { UnlockCost = 20, CharacterCreationCost = 9999 });
            }
            public override void SetupDetails()
            {
                Item.itemType = ItemTypes.Tool;
                Item.itemValue = 80;
                Item.initCount = 1;
                Item.rewardCount = 1;
                Item.stackable = true;
                Item.hasCharges = true;
                Item.goesInToolbar = true;
                Item.cantBeCloned = false;
            }
            public void SetSmallCount(InvItem item)
            => item.invItemCount = item.isArmor || item.isArmorHead || item.hasCharges || item.isWeapon && item.itemType != ItemTypes.WeaponThrown ? item.initCount : 1;
            public bool UseItem()
            {
                List<Unlock> unlockPool = gc.sessionDataBig.unlocks.FindAll(u => u.unlockType == "Item");
                List<InvItem> pool = new List<InvItem>();
                System.Random rnd = new System.Random();
                for (int i = 0; i < 5; i++)
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
                    SetSmallCount(item);
                    pool.Add(item);
                }
                Inventory.AddItem(pool[0]);
                Inventory.AddItem(pool[1]);
                Inventory.AddItem(pool[2]);
                Inventory.AddItem(pool[3]);
                Inventory.AddItem(pool[4]);
                Count--;
                gc.audioHandler.Play(Owner, "Bag_Use");
                return true;
            }
        }
        public class Bag_Low_Lega : CustomItem, IItemUsable
        {
            [RLSetup]
            public void Setuo()
            {
            RogueLibs.CreateCustomItem<Bag_Low_Lega>()
            .WithName(new CustomNameInfo
            {
                English = "<color=#c0c0c0ff>Argent</color> Traveler's Bag",
                Russian = "<color=#c0c0c0ff>Серебристый</color> Мешок Путешественника"
            })
            .WithDescription(new CustomNameInfo
            {
                English = "That bag from far lands, what does he contains?",
                Russian = "Мешок из далёких земель, что же в нём?"
            })
            .WithSprite(Properties.Resources.Bag)
            .WithUnlock(new ItemUnlock { UnlockCost = 20, CharacterCreationCost = 9999 });
            }
            public override void SetupDetails()
            {
                Item.itemType = ItemTypes.Tool;
                Item.itemValue = 230;
                Item.initCount = 1;
                Item.rewardCount = 1;
                Item.stackable = true;
                Item.hasCharges = true;
                Item.goesInToolbar = true;
                Item.cantBeCloned = false;
            }
            public bool UseItem()
            {
                List<Unlock> unlockPool = gc.sessionDataBig.unlocks.FindAll(u => u.unlockType == "Item");
                List<InvItem> pool = new List<InvItem>();
                System.Random rnd = new System.Random();
                for (int i = 0; i < 10; i++)
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
                    if (cost > selectedCost)
                    {
                        selected = pool[i];
                        selectedCost = cost;
                    }
                }
                Inventory.AddItem(pool[0]);
                Inventory.AddItem(selected);
                Count--;
                gc.audioHandler.Play(Owner, "Bag_Use");
                return true;
            }
        }
    }
}
