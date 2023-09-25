using BepInEx;
using RogueLibsCore;
using UnityEngine;
using System.Collections.Generic;
using BepInEx.Logging;

namespace TBB
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    [BepInDependency(RogueLibs.GUID, "3.6.4")]
    public class Main : BaseUnityPlugin
    {
        public static BaseUnityPlugin MainInstance = null!;
        public const string pluginGuid = "ztbbz.streetsofrogue.tbb";
        public const string pluginName = "TBB";
        public const string pluginVersion = "1.3.0";
        public static new ManualLogSource Logger = null!;
        public void Awake()
        {
            RogueLibs.CreateVersionText("TBB_id", "TBB v" + pluginVersion);

            Logger = base.Logger;
            RogueLibs.LoadFromAssembly();

            MainInstance = this;

            new ModulesSwitcher().Awake();

            new MTP().Awake();
            new SMaD().Awake();
            new aToI().Awake();
            new UBS().Awake();
            new NQfC().Awake();

            RogueLibs.CreateCustomAudio("Bag_Use", Properties.Resources.Bag_Use, AudioType.OGGVORBIS);
        }
    }
    public class Thief_Bag_Low : CustomItem, IItemUsable
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomItem<Thief_Bag_Low>()
        .WithName(new CustomNameInfo
        {
            English = "<color=#a52a2aff>Horrible</color> Thief Bag",
            Russian = "<color=#a52a2aff>Ужасный</color> Мешок Вора"
        })
        .WithDescription(new CustomNameInfo
        {
            English = "That bag from far lands, what does he contains?",
            Russian = "Мешок из далёких земель, что же в нём?"
        })
        .WithSprite(Properties.Resources.Thief_Bag)
        .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 20 });
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
    public class Thief_Bag_Avarage : CustomItem, IItemUsable
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomItem<Thief_Bag_Avarage>()
            .WithName(new CustomNameInfo
            {
                English = "<color=#808080ff>Normal</color> Thief Bag",
                Russian = "<color=#808080ff>Нормальный</color> Мешок Вора"
            })
            .WithDescription(new CustomNameInfo
            {
                English = "That bag from far lands, what does he contains?",
                Russian = "Мешок из далёких земель, что же в нём?"
            })
            .WithSprite(Properties.Resources.Thief_Bag)
            .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 20 });
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
    public class Thief_Bag_Lega : CustomItem, IItemUsable
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomItem<Thief_Bag_Lega>()
           .WithName(new CustomNameInfo
           {
               English = "<color=#c0c0c0ff>Argent</color> Thief Bag",
               Russian = "<color=#c0c0c0ff>Серебристый</color> Мешок Вора"
           })
           .WithDescription(new CustomNameInfo
           {
               English = "That bag from far lands, what does he contains?",
               Russian = "Мешок из далёких земель, что же в нём?"
           })
           .WithSprite(Properties.Resources.Thief_Bag)
           .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 20 });
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
            return true;
        }
    }
}