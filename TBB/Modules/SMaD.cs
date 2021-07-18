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
                       .WithUnlock(new ItemUnlock { UnlockCost = 10, CharacterCreationCost = 5 });
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
                           .WithUnlock(new ItemUnlock { UnlockCost = 5, CharacterCreationCost = 3 });
            Items.Add(builder.Unlock);
            RoguePatcher Patcher = new RoguePatcher(Main.MainInstance, typeof(SMaD));
            RogueLibs.CreateCustomAudio("Blind_Mushroom_Use", Properties.Resources.Blind_Mushroom_Use, AudioType.OGGVORBIS);
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
    }
}
