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
            RoguePatcher Patcher = new RoguePatcher(Main.MainInstance, typeof(SMaD));
            Patcher.Postfix(typeof(RandomItems), "fillItems");
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
                               English = "Is it just me, or does this cake look a little suspicious? In any case, you have it.",
                               Russian = "Мне кажется или, этот торт выглядит немного подозрительно? В любом случае вам его есть."
                           })
                           .WithSprite(Properties.Resources.Evil_Cake)
                           .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 8 });
            Items.Add(builder.Unlock);
            builder = RogueLibs.CreateCustomItem<Steal_Apple>()
               .WithName(new CustomNameInfo
               {
                   English = "Steel Apple",
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
                   English = "Any Chinese would give a fortune for such a tentacle! What is unique about it? It has strong healing properties, heals all wounds, but gives you a taste of seasickness. Bon Appetit!",
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
               .WithSprite(Properties.Resources.Vent_IceCream)
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
                   English = "Brain jellyfish",
                   Russian = "Мозговая медуза"
               }).WithDescription(new CustomNameInfo
               {
                   English = "A fairly decent-sized jellyfish that can control the host's brain, transmitting its properties to the host's body, even if not for long.",
                   Russian = "Достаточно приличных размеров медуза способная контролировать мозг носителя, передавая свои свойства телу носителя, пускай и не надолго."
               })
               .WithSprite(Properties.Resources.Brain_Jellyfish)
               .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 4 });
            Items.Add(builder.Unlock);
            builder = RogueLibs.CreateCustomItem<BotexLeg>()
               .WithName(new CustomNameInfo
               {
                   English = "Botex leg",
                   Russian = "Ботексная ножка"
               }).WithDescription(new CustomNameInfo
               {
                   English = "Chicken leg straight from one of the most famous fast food restaurants with a secret ingredient. Oversaturating the body.",
                   Russian = "Куриная ножка прямиком из одного из самых известных ресторанов быстрого питания с секретным ингредиентом. Перенасыщает организм."
               })
               .WithSprite(Properties.Resources.Botex_Chicken)
               .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 6 });
            Items.Add(builder.Unlock);
            builder = RogueLibs.CreateCustomItem<Boompkin>()
               .WithName(new CustomNameInfo
               {
                   English = "Boompkin",
                   Russian = "Бумква"
               }).WithDescription(new CustomNameInfo
               {
                   English = "Is it just me, or is there something wrong with this pumpkin?",
                   Russian = "Мне кажется или что-то с этой тыквой не так?"
               })
               .WithSprite(Properties.Resources.Boom_Pumpkin)
               .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 3 });
            Items.Add(builder.Unlock);
            builder = RogueLibs.CreateCustomItem<KC_Drink>()
               .WithName(new CustomNameInfo
               {
                   English = "KC Drink",
                   Russian = "Газировка KC"
               }).WithDescription(new CustomNameInfo
               {
                   English = "A unique soda of its kind. KC is King of Caramel, according to rumors, when you drink it, you feel like your body is filled with caramel. Although scientists are not sure that this is caramel, but whatever it is, it move speed.",
                   Russian = "Уникальная в своём роде газировка. KC это King of Сaramel или же Король Карамели, со слухов когда выпиваешь её, то чувствуешь как твоё тело наливается карамелью. Хотя учёные не уверены что это карамель, но чтобы это не было оно ускоряет движения."
               })
               .WithSprite(Properties.Resources.KC_Fuzzi)
               .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 5 });
            Items.Add(builder.Unlock);
            builder = RogueLibs.CreateCustomItem<Fire_Salamander_Heart>()
               .WithName(new CustomNameInfo
               {
                   English = "Fire Salamander Heart",
                   Russian = "Сердце Огненной Саламандры"
               }).WithDescription(new CustomNameInfo
               {
                   English = "The Salamander heart is an incredibly nasty-tasting organ that pumps blood. I do not think that you need to eat it, although if you are a Pyromancer, it is your best friend, because your blood is saturated with special cells and will spread them throughout the body and you will become less vulnerable to fire. These cells are able to adapt quickly, it is a pity that your body will not accept them immediately.. so that.. Good luck surviving the War inside your body!",
                   Russian = "Саламандровское сердце - невероятно противный на вкус орган качающий кровь. Не думаю что нужно его есть, хотя если вы пиромант то это ваш лучший друг, ведь ваша кровь насытиться особыми клетками и разнесёт их по всему организму и вы станете менее уязвима к огню. Эти клетки умеют быстро адаптироваться, жаль что ваш организм не примет их сразу.. так что.. Удачи вам пережить Войну внутри вашего организма!"
               })
               .WithSprite(Properties.Resources.Salamandr_Heart)
               .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 6 });
            Items.Add(builder.Unlock);
            builder = RogueLibs.CreateCustomItem<FishOfLuck>()
               .WithName(new CustomNameInfo
               {
                   English = "Fish from Well",
                   Russian = "Рыба из Колодца"
               }).WithDescription(new CustomNameInfo
               {
                   English = "The legendary fish that was caught from the very Well. it's all dry, but so warm.. Is it edible? Is unknown.. no one has tried it, but you can be the first! But according to the legends, it gives a surge of strength, heals all wounds and gives a sense of good luck.",
                   Russian = "Легендарная рыба которую выловили из того самого Колодца.. она вся сухая, но такая тёплая.. Возможно она съедобная? Неизвестно.. никто не пробовал, но вы можете стать первым! Но судя по легендам она даёт прилив сил, залечивает все раны и даёт ощущение удачи."
               })
               .WithSprite(Properties.Resources.Luck_Fish)
               .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 10 });
            Items.Add(builder.Unlock);
            builder = RogueLibs.CreateCustomItem<Tears_Heaven>()
               .WithName(new CustomNameInfo
               {
                   English = "Tear of Heaven",
                   Russian = "Слезы Небес"
               }).WithDescription(new CustomNameInfo
               {
                   English = "Heaven's tears are granted if the gods like your soul. A person who receives the Tears of Heaven at a critical moment can drink them to get even temporary, but the power of God, and restore the body, but his body is not able to withstand the power of the gods,which is why it is not able to move.",
                   Russian = "Слезы Небес даруются, если богам понравилась твоя душа. Человек получивший Слезы Небес в критический момент может выпить их что бы получить пускай и временную, но силу бога, и восстановить организм, однако его тело не способно выдержать мощь богов из-за чего не способно двигаться."
               })
               .WithSprite(Properties.Resources.Heaven_Tears)
               .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 10 });
            Items.Add(builder.Unlock);
            builder = RogueLibs.CreateCustomItem<Fish_Oil>()
               .WithName(new CustomNameInfo
               {
                   English = "Fish Oil",
                   Russian = "Рыбий Жир"
               }).WithDescription(new CustomNameInfo
               {
                   English = "Fish oil - as scientists have proven a very useful thing, although people are not completely sure about it. its taste and color are known to many,but few people know that it can restore the cells of human organs, as well as increase your strength, but it is quite a heavy product so that a run is not fatal for you..but still it is not desirable to run. But you did not listen to your mother and did not eat fish oil as a child, even in the game eat.",
                   Russian = "Рыбий жир - как доказали ученые очень полезная вещь, хотя люди не до конца уверены в этом. его вкус и цвет известен многим,однако мало кто знает что он может восстанавливать клетки человеческих органов, так же увеличивает  вашу силу, но он достаточно тяжёлый продукт так что пробежка для вас не смертельна..но всё таки бегать не желательно. А вы вот не слушались маму и не ели рыбий жир в детстве, хоть в игре поешьте."
               })
               .WithSprite(Properties.Resources.Fish_Fat)
               .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 6 });
            Items.Add(builder.Unlock);
            builder = RogueLibs.CreateCustomItem<Divine_Honey>()
               .WithName(new CustomNameInfo
               {
                   English = "Divine Honey",
                   Russian = "Божественный Мёд"
               }).WithDescription(new CustomNameInfo
               {
                   English = "This honey was produced by the legendary divine bees, or so the legends say. This honey was obtained in the most insidious way - Stolen. It has effective regenerative abilities, rejuvenates the skin and regenerates lost cells, but it all takes time. Because of the rush during the Assembly of honey, larvae gather in it.",
                   Russian = "Этот мед производили легендарные божественных пчелы, по крайней мере так гласят легенды. Этот мёд был добыт самым коварным способом - Украден. Обладает действенными регенерационными способностями, омолаживает кожу и регенерует потерянные клетки, однако это всё занимает время. Из-за спешки во время сборки мёда в нём содержаться личинки."
               })
               .WithSprite(Properties.Resources.Honey)
               .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 8 });
            Items.Add(builder.Unlock);
            builder = RogueLibs.CreateCustomItem<Juicy_Watermelon>()
               .WithName(new CustomNameInfo
               {
                   English = "Juicy Watermelon",
                   Russian = "Сочный Арбуз"
               }).WithDescription(new CustomNameInfo
               {
                   English = "Mmmmmmm.. how juicy and delicious this watermelon is..watermelon juice is flowing out of it.. or is it not juice? I won't torment you. It restores 80 HP to Vampires when people are only 30.. keep in mind that vampires are good, people are bad, I'm talking about bloodmixing.",
                   Russian = "Ммммммм.. какой сочный и вкусный этот арбуз..из него так и течёт арбузный сок.. или это не сок? Не буду томить. Он восстанавливает Вампирам 80 ХП, когда людям только 30.. учтите что вампирам хорошо, людям плохо, я про кровосмешение."
               })
               .WithSprite(Properties.Resources.Blood_Watermelon)
               .WithUnlock(new ItemUnlock { UnlockCost = 0, CharacterCreationCost = 4 });
            Items.Add(builder.Unlock);
            RogueLibs.CreateCustomAudio("Blind_Mushroom_Use", Properties.Resources.Blind_Mushroom_Use, AudioType.OGGVORBIS);
            RogueLibs.CreateCustomAudio("Steel_Apple_Walk", Properties.Resources.Steel_Apple_Walk, AudioType.OGGVORBIS);
            RogueLibs.CreateCustomAudio("Steal_Apple_Use", Properties.Resources.Steal_Apple_Use, AudioType.OGGVORBIS);
            RogueLibs.CreateCustomAudio("Evil_Cake_Use", Properties.Resources.Evil_Cake_Use, AudioType.OGGVORBIS);
            RogueLibs.CreateCustomAudio("BOOMCorn_Use", Properties.Resources.BOOMCorn_Use, AudioType.OGGVORBIS);
            RogueLibs.CreateCustomAudio("Vent_IceCream_Use", Properties.Resources.CIceCream_Use, AudioType.OGGVORBIS);
            RogueLibs.CreateCustomAudio("Blood_Donut_Use", Properties.Resources.BloodDonut_Use, AudioType.OGGVORBIS);
            RogueLibs.CreateCustomAudio("Brain_Jellyfish_Use", Properties.Resources.Brain_Jellyfish_Use, AudioType.OGGVORBIS);
            RogueLibs.CreateCustomAudio("BotexLeg_Use", Properties.Resources.BotexLeg_Use, AudioType.OGGVORBIS);
            RogueLibs.CreateCustomAudio("Fire_Salamander_Heart_Use", Properties.Resources.Fire_Salamander_Heart_Use, AudioType.OGGVORBIS);
            RogueLibs.CreateCustomAudio("Divine_Honey_Use", Properties.Resources.Divine_Honey_Use, AudioType.OGGVORBIS);
            RogueLibs.CreateCustomAudio("Tears_Heaven_Use", Properties.Resources.Tears_Heaven_Use, AudioType.OGGVORBIS);
            RogueLibs.CreateCustomAudio("FishOfLuck_Use", Properties.Resources.FishOfLuck_Use, AudioType.OGGVORBIS);
        }
        public static void RandomItems_fillItems(RandomItems __instance)
        {
            RandomSelection sel = GameObject.Find("ScriptObject").GetComponent<RandomSelection>();
            RandomList rList = sel.randomListTable["Food1"];
            sel.CreateRandomElement(rList, "KC_Drink", 6);
            sel.CreateRandomElement(rList, "BOOMCorn", 4);
            rList = sel.randomListTable["Food2"];
            sel.CreateRandomElement(rList, "Vent_IceCream", 4);
            sel.CreateRandomElement(rList, "Juicy_Watermelon", 3);
            sel.CreateRandomElement(rList, "Tentacle_Kraken", 2);
            sel.CreateRandomElement(rList, "Fish_Oil", 4);
            sel.CreateRandomElement(rList, "BloodDonut", 5);
            sel.CreateRandomElement(rList, "Boompkin", 4);
            sel.CreateRandomElement(rList, "Divine_Honey", 3);
            sel.CreateRandomElement(rList, "BotexLeg", 4);
            sel.CreateRandomElement(rList, "Steal_Apple", 1);
            sel.CreateRandomElement(rList, "FishOfLuck", 1);
            sel.CreateRandomElement(rList, "Brain_Jellyfish", 3);
            sel.CreateRandomElement(rList, "Fire_Salamander_Heart", 2);
            //sel.CreateRandomElement(rList, "EvilCake", 3);
        }
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
            Owner.statusEffects.AddStatusEffect("Frozen", 10);
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
            Item.goesInToolbar = true;
            Item.cantBeCloned = true;
        }
        public bool UseItem()
        {
            gc.audioHandler.Play(Owner, "Blood_Donut_Use");
            Owner.statusEffects.AddStatusEffect("Blood_Donut_Effect");
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
    public class BotexLeg : CustomItem, IItemUsable
    {
        public override void SetupDetails()
        {
            Item.itemType = ItemTypes.Food;
            Item.itemValue = 60;
            Item.initCount = 1;
            Item.rewardCount = 1;
            Item.healthChange = 35;
            Item.stackable = true;
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
            Owner.statusEffects.AddStatusEffect("BotexLeg_Effect");
            Count--;
            gc.audioHandler.Play(Owner, "BotexLeg_Use");
            return true;
        }
    }
    public class Boompkin : CustomItem, IItemUsable
    {
        public override void SetupDetails()
        {
            Item.itemType = ItemTypes.Food;
            Item.itemValue = 35;
            Item.initCount = 1;
            Item.rewardCount = 1;
            Item.stackable = true;
            Item.goesInToolbar = true;
            Item.cantBeCloned = true;
        }
        public bool UseItem()
        {
            Count--;
            Owner.gc.spawnerMain.SpawnExplosion(Owner, Owner.tr.position, "Normal", false, -1, false, true).agent = Owner;
            Owner.gc.spawnerMain.SpawnExplosion(Owner, Owner.tr.position, "Normal", false, -1, false, true).agent = Owner;
            Owner.gc.spawnerMain.SpawnExplosion(Owner, Owner.tr.position, "Normal", false, -1, false, true).agent = Owner;
            Owner.gc.spawnerMain.SpawnExplosion(Owner, Owner.tr.position, "Normal", false, -1, false, true).agent = Owner;
            return true;
        }
    }
    public class KC_Drink : CustomItem, IItemUsable
    {
        public override void SetupDetails()
        {
            Item.itemType = ItemTypes.Food;
            Item.itemValue = 30;
            Item.initCount = 3;
            Item.rewardCount = 3;
            Item.healthChange = 5;
            Item.stackable = true;
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
            Owner.statusEffects.AddStatusEffect("KC_Drink_Effect");
            Count--;
            gc.audioHandler.Play(Owner, "Drink");
            return true;
        }
    }
    public class Fire_Salamander_Heart : CustomItem, IItemUsable
    {
        public override void SetupDetails()
        {
            Item.itemType = ItemTypes.Food;
            Item.itemValue = 60;
            Item.initCount = 1;
            Item.rewardCount = 1;
            Item.healthChange = -80;
            Item.stackable = true;
            Item.goesInToolbar = true;
            Item.cantBeCloned = true;
        }
        public bool UseItem()
        {
            int heal = new ItemFunctions().DetermineHealthChange(Item, Owner);
            Owner.statusEffects.ChangeHealth(heal);
            Owner.statusEffects.AddTrait("ResistFire");
            Count--;
            gc.audioHandler.Play(Owner, "Fire_Salamander_Heart_Use");
            return true;
        }
    }
    public class FishOfLuck : CustomItem, IItemUsable
    {
        public override void SetupDetails()
        {
            Item.itemType = ItemTypes.Food;
            Item.itemValue = 60;
            Item.initCount = 1;
            Item.rewardCount = 1;
            Item.stackable = true;
            Item.goesInToolbar = true;
            Item.cantBeCloned = true;
        }
        public bool UseItem()
        {
            int chance = new System.Random().Next(100);
            if (chance > 55) // 45%
                Inventory.AddItem("Money", 20);
            if (chance > 85) // 15%
                Inventory.AddItem("Money", 50);
            if (chance < 1) // 1%
                Inventory.AddItem("Money", 1000);
            Count--;
            gc.audioHandler.Play(Owner, "FishOfLuck_Use");
            return true;
        }
    }
    public class Tears_Heaven : CustomItem, IItemUsable
    {
        public override void SetupDetails()
        {
            Item.itemType = ItemTypes.Food;
            Item.itemValue = 45;
            Item.initCount = 1;
            Item.rewardCount = 1;
            Item.healthChange = 99999;
            Item.stackable = true;
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
            gc.audioHandler.Play(Owner, "Tears_Heaven_Use");
            Owner.statusEffects.AddStatusEffect("Tears_Heaven_Effect");
            Count--;
            return true;
        }
    }
    public class Fish_Oil : CustomItem, IItemUsable
    {
        public override void SetupDetails()
        {
            Item.itemType = ItemTypes.Food;
            Item.itemValue = 35;
            Item.initCount = 2;
            Item.rewardCount = 2;
            Item.healthChange = 10;
            Item.stackable = true;
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
            Owner.statusEffects.AddStatusEffect("Fish_Oil_Effect");
            Count--;
            gc.audioHandler.Play(Owner, "UseFood");
            return true;
        }
    }
    public class Divine_Honey : CustomItem, IItemUsable
    {
        public override void SetupDetails()
        {
            Item.itemType = ItemTypes.Food;
            Item.itemValue = 55;
            Item.initCount = 1;
            Item.rewardCount = 1;
            Item.stackable = true;
            Item.goesInToolbar = true;
            Item.cantBeCloned = true;
        }
        public bool UseItem()
        {
            Owner.statusEffects.AddStatusEffect("Divine_Honey_Effect");
            Count--;
            gc.audioHandler.Play(Owner, "Divine_Honey_Use");
            return true;
        }
    }
    public class Juicy_Watermelon : CustomItem, IItemUsable
    {
        public override void SetupDetails()
        {
            Item.itemType = ItemTypes.Food;
            Item.itemValue = 35;
            Item.initCount = 1;
            Item.rewardCount = 1;
            Item.healthChange = 30;
            Item.stackable = true;
            Item.goesInToolbar = true;
            Item.cantBeCloned = true;
        }
        public bool UseItem()
        {
            if (Owner.statusEffects.hasTrait("BloodRestoresHealth"))
                Item.healthChange = 80;
            else
            {
                Item.healthChange = 30;
                Owner.statusEffects.AddStatusEffect("Confused", false, false, 25);
            }
            int heal = new ItemFunctions().DetermineHealthChange(Item, Owner);
            Owner.statusEffects.ChangeHealth(heal);
            if (Owner.HasTrait("HealthItemsGiveFollowersExtraHealth") || Owner.HasTrait("HealthItemsGiveFollowersExtraHealth2"))
            {
                new ItemFunctions().GiveFollowersHealth(Owner, heal);
            }
            Count--;
            gc.audioHandler.Play(Owner, "UseFood");
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
    public class Blood_Donut_Effect : CustomEffect
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomEffect<Blood_Donut_Effect>()
                        .WithName(new CustomNameInfo
                        {
                            English = "Erythrocyte replenishment",
                            Russian = "Восполнение эритроцитов"
                        })
                        .WithDescription(new CustomNameInfo
                        {
                            English = "Yes, you will now have red blood cells that you can bathe a whole zoo in them!",
                            Russian = "Да, у вас сейчас будет эритроцитов, что вы сможете в них искупать целый зоопарк!"
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
            int a = Owner.FindSpeed();
            Owner.speedMax = a;
        }
        public override void OnUpdated(EffectUpdatedArgs e)
        {
            Owner.ChangeHealth(Owner.gc.challenges.Contains("LowHealth") ? +1f : +1f);
            CurrentTime--;
        }
    }
    [EffectParameters(EffectLimitations.RemoveOnDeath | EffectLimitations.RemoveOnKnockOut)]
    public class Tears_Heaven_Effect : CustomEffect
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomEffect<Tears_Heaven_Effect>()
                        .WithName(new CustomNameInfo
                        {
                            English = "Mercy of Gods",
                            Russian = "Милость Богов"
                        })
                        .WithDescription(new CustomNameInfo
                        {
                            English = "Congratulations, the gods themselves favor you, live.",
                            Russian = "Поздравляю сами боги вам благоволят, живите."
                        });
        }
        public override int GetEffectTime() => 30;
        public override int GetEffectHate() => 0;
        public override void OnAdded()
        {
            Owner.speedMax = 0;
            Owner.statusEffects.AddStatusEffect("Invincible", false, false, 30);
        }
        public override void OnRemoved()
        {
            int a = Owner.FindSpeed();
            Owner.speedMax = a;
        }
        public override void OnUpdated(EffectUpdatedArgs e)
        {
            CurrentTime--;
        }
    }
    [EffectParameters(EffectLimitations.RemoveOnDeath | EffectLimitations.RemoveOnKnockOut)]
    public class Brain_Jellyfish_Effect : CustomEffect
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomEffect<Brain_Jellyfish_Effect>()
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
            Owner.AddEffect("Enraged", new CreateEffectInfo { SpecificTime = 25, DontShowText = true });
            CurrentTime--;
        }
    }
    [EffectParameters(EffectLimitations.RemoveOnDeath | EffectLimitations.RemoveOnKnockOut)]
    public class BotexLeg_Effect : CustomEffect
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomEffect<BotexLeg_Effect>()
                        .WithName(new CustomNameInfo
                        {
                            English = "Oversaturated body",
                            Russian = "Перенасыщенный организм"
                        })
                        .WithDescription(new CustomNameInfo
                        {
                            English = "How do you look.. very plump",
                            Russian = "Как то вы выглядите.. очень пухло"
                        });
        }
        public override int GetEffectTime() => 20;
        public override int GetEffectHate() => 0;
        public override void OnAdded()
        {
            Owner.statusEffects.AddTrait("Giant");
            Owner.SetSpeed(Owner.speedStatMod - 3);
        }
        public override void OnRemoved()
        {
            Owner.statusEffects.RemoveTrait("Giant");
            Owner.SetSpeed(Owner.speedStatMod + 3);
        }
        public override void OnUpdated(EffectUpdatedArgs e)
        {
            CurrentTime--;
        }
    }
    [EffectParameters(EffectLimitations.RemoveOnDeath | EffectLimitations.RemoveOnKnockOut)]
    public class KC_Drink_Effect : CustomEffect
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomEffect<KC_Drink_Effect>()
                        .WithName(new CustomNameInfo
                        {
                            English = "Under KC drink",
                            Russian = "Под действием KC газировки"
                        })
                        .WithDescription(new CustomNameInfo
                        {
                            English = "You drank KC drink",
                            Russian = "Вы выпили KC газировку, больше не пейте, а то жопа слипнется"
                        });
        }
        public override int GetEffectTime() => 15;
        public override int GetEffectHate() => 0;
        public override void OnAdded()
        {
            Owner.SetSpeed(Owner.speedStatMod + 2);
        }
        public override void OnRemoved()
        {
            Owner.SetSpeed(Owner.speedStatMod - 2);
        }
        public override void OnUpdated(EffectUpdatedArgs e)
        {
            CurrentTime--;
        }
    }
    [EffectParameters(EffectLimitations.RemoveOnDeath | EffectLimitations.RemoveOnKnockOut)]
    public class Fish_Oil_Effect : CustomEffect
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomEffect<Fish_Oil_Effect>()
                        .WithName(new CustomNameInfo
                        {
                            English = "Power of Fish Oil",
                            Russian = "Сила рыбьего жира"
                        })
                        .WithDescription(new CustomNameInfo
                        {
                            English = "I hope you enjoyed the fish oil!",
                            Russian = "Надеюсь вам понравился рыбий жир!"
                        });
        }
        public override int GetEffectTime() => 15;
        public override int GetEffectHate() => 0;
        public override void OnAdded()
        {
            Owner.SetSpeed(Owner.speedStatMod - 2);
            Owner.SetStrength(Owner.strengthStatMod + 2);
        }
        public override void OnRemoved()
        {
            Owner.SetSpeed(Owner.speedStatMod + 2);
            Owner.SetStrength(Owner.strengthStatMod - 2);
        }
        public override void OnUpdated(EffectUpdatedArgs e)
        {
            CurrentTime--;
        }
    }
    [EffectParameters(EffectLimitations.RemoveOnDeath | EffectLimitations.RemoveOnKnockOut)]
    public class Divine_Honey_Effect : CustomEffect
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomEffect<Divine_Honey_Effect>()
                        .WithName(new CustomNameInfo
                        {
                            English = "Cell regeneration",
                            Russian = "Регенерация клеток"
                        })
                        .WithDescription(new CustomNameInfo
                        {
                            English = "Your cells are regenerating.. wait..",
                            Russian = "Ваши клетки регенерируются.. подождите.."
                        });
        }
        public override int GetEffectTime() => 60;
        public override int GetEffectHate() => 0;
        public override void OnAdded()
        {
            Owner.speedMax = 0;
            Owner.statusEffects.AddStatusEffect("Poisoned", false, false, 30);
        }
        public override void OnRemoved()
        {
            int a = Owner.FindSpeed();
            Owner.speedMax = a;
        }
        public override void OnUpdated(EffectUpdatedArgs e)
        {
            Owner.ChangeHealth(Owner.gc.challenges.Contains("LowHealth") ? +1f : +1f);
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
