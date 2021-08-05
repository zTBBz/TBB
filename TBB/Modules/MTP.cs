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

namespace TBB
{
    class MTP
    {
        public static bool IsATOIInstalled;
        public static List<TraitUnlock> Traits = new List<TraitUnlock>();
        public static void SetActive(bool isEnabled)
        {
            foreach (TraitUnlock unlock in Traits)
            {
                unlock.IsAvailable = isEnabled;
                unlock.IsAvailableInCC = isEnabled;
            }
        }
        public void Awake()
        {
            RoguePatcher Patcher = new RoguePatcher(Main.MainInstance, typeof(MTP));
            Patcher.Postfix(typeof(Relationships), "SetupRelationshipOriginal", new Type[1] { typeof(Agent) });
            IsATOIInstalled = File.Exists(Path.GetFullPath(Path.Combine(Paths.PluginPath, "aTonOfItems.dll")));
            RogueFramework.TraitFactories.Add(new AlignedTraitFactory());
            TraitUnlock unlock = new TraitUnlock("AlignedTo_Gangbanger") { UnlockCost = 0, CharacterCreationCost = 5 };
            Traits.Add(unlock);
            RogueLibs.CreateCustomUnlock(unlock)
            .WithName(new CustomNameInfo
            {
                    English = "Crepe Rolle",
                    Russian = "Друг блинчиков"
            })
            .WithDescription(new CustomNameInfo
            {
                    English = "You back the Blue, but the other kind. Throughout your early life, you rolled with Crepes.",
                    Russian = "После нескольких лет в трущобах, вы связали свою жизнь с блинчиками."
            });
            unlock = new TraitUnlock("AlignedTo_GangbangerB") { UnlockCost = 0, CharacterCreationCost = 5 };
            Traits.Add(unlock);
            RogueLibs.CreateCustomUnlock(unlock)
            .WithName(new CustomNameInfo
            {
                    English = "Blahd Brother",
                    Russian = "Друг кровяных"
            })
            .WithDescription(new CustomNameInfo
            {
                    English = "Blahd in, Blahd out! The Boys in Red have jumped you in, and you're a trusted ally.",
                    Russian = "После нескольких лет в трущобах, вы связали свою жизнь с кровяными."
            });
            unlock = new TraitUnlock("LoyalTo_Soldier") { UnlockCost = 0, CharacterCreationCost = 4 };
            Traits.Add(unlock);
            RogueLibs.CreateCustomUnlock(unlock)
            .WithName(new CustomNameInfo
            {
                    English = "Honorary Sergeant",
                    Russian = "Салага"
            })
            .WithDescription(new CustomNameInfo
            {
                    English = "Your father is a former military man, it's no secret that for all soldiers you are a native rookie",
                    Russian = "Ваш отец бывший военный, никому уже не секрет что для всех солдат вы родной салага."
            });
            unlock = new TraitUnlock("LoyalTo_Mafia") { UnlockCost = 0, CharacterCreationCost = 4 };
            Traits.Add(unlock);
            RogueLibs.CreateCustomUnlock(unlock)
            .WithName(new CustomNameInfo
            {
                English = "Spaghetti Connoisseur",
                Russian = "Ценитель спагетти"
            })
            .WithDescription(new CustomNameInfo
            {
                English = "The mafia saw you eating spaghetti downtown one time. Ever since, you have carried their undying respect and loyalty.<color=#ff0000ff>[Every new floor +30 Ammo Box]</color>",
                Russian = "Будучи в деловом центре вы попробовали спагетти, с тех пор когда вас видят мафиози они признают вас истинным ценителем спаггети.<color=#ff0000ff>[Каждый этаж +30 Ящик с боеприпасами]</color>."
            });
            unlock = new TraitUnlock("AlignedTo_Thief") { UnlockCost = 0, CharacterCreationCost = 5 };
            Traits.Add(unlock);
            RogueLibs.CreateCustomUnlock(unlock)
            .WithName(new CustomNameInfo
            {
                English = "Celebrity Among Thieves",
                Russian = "Знаменитость среди воров"
            })
            .WithDescription(new CustomNameInfo
            {
                English = "After busting your ass for 10 years in the factory, you started feeling discontent. You started with petty theft, until one day you stole the entire factory and pawned it. Thieves everywhere look at you with reverence.",
                Russian = "Более 10 лет вы впахивали на заводе, в конце - концов вам это надоело, вы захотели лёгкой жизни и стали воровать, все воры в городе знают о вас."
            });
            unlock = new TraitUnlock("LoyalTo_Bartender") { UnlockCost = 0, CharacterCreationCost = 4 };
            Traits.Add(unlock);
            RogueLibs.CreateCustomUnlock(unlock)
            .WithName(new CustomNameInfo
            {
                English = "Loyal Bar-Fly",
                Russian = "Любитель выпить"
            })
            .WithDescription(new CustomNameInfo
            {
                English = "After wasted your life funding their, the Bartenders of the city have decided you're a pretty cool customer. Hey, it's not all bad! They know your name, at least.",
                Russian = "Вы имея на руках деньги от умершего отца вы начали пропивать их, уже через несколько месяцев вы стали заядлым алкоголиком и знаменитостью среди барменов."
            });
            unlock = new TraitUnlock("AlignedTo_Hacker") { UnlockCost = 0, CharacterCreationCost = 5 };
            Traits.Add(unlock);
            RogueLibs.CreateCustomUnlock(unlock)
            .WithName(new CustomNameInfo
            {
                English = "Cyber-Spider",
                Russian = "Паук в интернете"
            })
            .WithDescription(new CustomNameInfo
            {
                English = "You are known in Cyberspace as the Spider. The Data Cowboys, RAM Rustlers, and Techno-Fetishists of the city associate your name with deep respect.<color=#ff0000ff>[Every new floor +2 Hacking Tool]</color>",
                Russian = "Постоянно играв и зависая в сети вы начали обрастать новыми знакомствами, в частности вы познакомились с хакерами.<color=#ff0000ff>[Каждый этаж +2 Устройства для взлома]</color>"
            });
            unlock = new TraitUnlock("AlignedTo_Doctor") { UnlockCost = 0, CharacterCreationCost = 5 };
            Traits.Add(unlock);
            RogueLibs.CreateCustomUnlock(unlock)
            .WithName(new CustomNameInfo
            {
                English = "Pharmaceutical Importer",
                Russian = "Контрабандист лекарств"
            })
            .WithDescription(new CustomNameInfo
            {
                English = "Doctors love you. Not because you're good, or because you're kind. But because you bring them the Good Shit at a price that they won't ask questions about.<color=#ff0000ff>[Every new floor +1 Syringe]</color>",
                Russian = "Вы долгое время ходили по этажам и доставляли различные лекарства, в основном нелегальные.. Для всех врачей вы запомнились оптимальными ценами.<color=#ff0000ff>[Каждый этаж +1 Шприц]</color>"
            });
            unlock = new TraitUnlock("LoyalTo_Scientist") { UnlockCost = 0, CharacterCreationCost = 4 };
            unlock.Unlock.upgrade = "AlignedTo_Scientist";
            Traits.Add(unlock);
            RogueLibs.CreateCustomUnlock(unlock)
            .WithName(new CustomNameInfo
            {
                English = "Model Specimen",
                Russian = "Идеальный образец"
            })
            .WithDescription(new CustomNameInfo
            {
                English = "The Scientists remember you fondly. You were poked and prodded and injected with all manner of things, and never once complained.",
                Russian = "Сидя в камере лаборатории вы не дёргались и выполняли все приказы людей в халатах, спустя пару лет вас выпустили. Среди учёных разнёсся слух о идеальном образце, о вас."
            });
            unlock = new TraitUnlock("AlignedTo_Scientist") { UnlockCost = 0, CharacterCreationCost = 5 };
            Traits.Add(unlock);
            RogueLibs.CreateCustomUnlock(unlock)
            .WithName(new CustomNameInfo
            {
                English = "Model Specimen +",
                Russian = "Идеальный образец +"
            })
            .WithDescription(new CustomNameInfo
            {
                English = "The Scientists remember you fondly. You were poked and prodded and injected with all manner of things, and never once complained.",
                Russian = "Сидя в камере лаборатории вы не дёргались и выполняли все приказы людей в халатах, спустя пару лет вас выпустили. Среди учёных разнёсся слух о идеальном образце, о вас."
            });
            unlock = new TraitUnlock("AlignedTo_Gorilla") { UnlockCost = 0, CharacterCreationCost = 5 };
            Traits.Add(unlock);
            RogueLibs.CreateCustomUnlock(unlock)
            .WithName(new CustomNameInfo
            {
                English = "Smooth Cousin",
                Russian = "Не волосатый родственник"
            })
            .WithDescription(new CustomNameInfo
            {
                English = "You stick out like a sore (opposable) thumb at family gatherings, because you're the only one who's not a Gorilla. The food leaves something to be desired, but the Gorillas of the city are your family!",
                Russian = "Без волос на теле, с гладкой кожей, с большим пальцем.. Да вы не волосатый родственник!"
            });
        }
        public static void Relationships_SetupRelationshipOriginal(Relationships __instance, Agent otherAgent, Agent ___agent)
        {
            if (___agent.IsAligned(otherAgent))
            {
                ___agent.relationships.SetRelHate(otherAgent, 0);
                otherAgent.relationships.SetRelHate(___agent, 0);
                otherAgent.relationships.SetRelInitial(___agent, "Aligned");
                ___agent.relationships.SetRelInitial(otherAgent, "Aligned");
            }
            if (___agent.IsLoyal(otherAgent))
            {
                ___agent.relationships.SetRelHate(otherAgent, 0);
                otherAgent.relationships.SetRelHate(___agent, 0);
                otherAgent.relationships.SetRelInitial(___agent, "Loyal");
                ___agent.relationships.SetRelInitial(otherAgent, "Loyal");
            }
        }
    }
    public class AlignedTrait : CustomTrait, ITraitUpdateable
    {
        public string AgentName;
        public override void OnAdded()
        {
            foreach (Agent otherAgent in gc.agentList.Where(a => a.agentName == AgentName))
            {
                otherAgent.relationships.SetRelHate(Owner, 0);
                Owner.relationships.SetRelHate(otherAgent, 0);
                Owner.relationships.SetRelInitial(otherAgent, "Aligned");
                otherAgent.relationships.SetRelInitial(Owner, "Aligned");
            }
        }
        public override void OnRemoved() { }
        public void OnUpdated(TraitUpdatedArgs e) { }
    }
    public class LoyalTrait : CustomTrait, ITraitUpdateable
    {
        public string AgentName;
        public override void OnAdded()
        {
            foreach (Agent otherAgent in gc.agentList.Where(a => a.agentName == AgentName))
            {
                otherAgent.relationships.SetRelHate(Owner, 0);
                Owner.relationships.SetRelHate(otherAgent, 0);
                Owner.relationships.SetRelInitial(otherAgent, "Loyal");
                otherAgent.relationships.SetRelInitial(Owner, "Loyal");
            }
        }
        public override void OnRemoved() { }
        public void OnUpdated(TraitUpdatedArgs e) { }
    }
    public static class MTPExtensions
    {
        public static bool IsAligned(this Agent agent, Agent toAgent)
        {
            foreach (Trait trait in agent.statusEffects.TraitList)
            {
                AlignedTrait aligned = trait.GetHook<AlignedTrait>();
                if (aligned != null && aligned.AgentName == toAgent.agentName)
                    return true;
            }
            foreach (Trait trait in toAgent.statusEffects.TraitList)
            {
                AlignedTrait aligned = trait.GetHook<AlignedTrait>();
                if (aligned != null && aligned.AgentName == agent.agentName)
                    return true;
            }
            return false;
        }
        public static bool IsLoyal(this Agent agent, Agent toAgent)
        {
            foreach (Trait trait in agent.statusEffects.TraitList)
            {
                LoyalTrait loyal = trait.GetHook<LoyalTrait>();
                if (loyal != null && loyal.AgentName == toAgent.agentName)
                    return true;
            }
            foreach (Trait trait in toAgent.statusEffects.TraitList)
            {
                LoyalTrait loyal = trait.GetHook<LoyalTrait>();
                if (loyal != null && loyal.AgentName == agent.agentName)
                    return true;
            }
            return false;
        }
    }
    public class Evil_Cake_Trait : CustomTrait, ITraitUpdateable
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Evil_Cake_Trait>()
                .WithName(new CustomNameInfo
                {
                    English = "<color=#000000>Unknown soul</color>",
                    Russian = "<color=#000000>Неизвестная душа</color>"
                })
                .WithDescription(new CustomNameInfo
                {
                    English = "<color=#000000>Inside you unknown soul..</color>",
                    Russian = "<color=#000000>Внутри вас неизвестная душа..</color>"
                })
                .WithUnlock(new TraitUnlock { IsAvailableInCC = false });
        }
        public override void OnAdded()
        {
            Owner.statusEffects.ChangeHealth(500, Owner);
        }
        public override void OnRemoved() { }
        public void OnUpdated(TraitUpdatedArgs e)
        {
            e.UpdateDelay = 15;
            StatusEffects.StartCoroutine(ParalyzedEnumerator());
            Owner.ChangeHealth(Owner.gc.challenges.Contains("LowHealth") ? +10f : +10f);
        }
        public IEnumerator ParalyzedEnumerator()
        {
            Owner.AddEffect("Enraged", new CreateEffectInfo { SpecificTime = 10, DontShowText = true });
            Owner.SetAccuracy(Owner.accuracyStatMod + 3);
            Owner.SetStrength(Owner.strengthStatMod + 3);
            Owner.SetSpeed(Owner.speedStatMod + 3);
            yield return new WaitForSeconds(10f);
            Owner.SetAccuracy(Owner.accuracyStatMod - 3);
            Owner.SetStrength(Owner.strengthStatMod - 3);
            Owner.SetSpeed(Owner.speedStatMod - 3);
        }
    }
    public class AlignedTraitFactory : HookFactoryBase<Trait>
    {
        public override bool TryCreate(Trait instance, out IHook<Trait> hook)
        {
            if (instance.traitName.StartsWith("AlignedTo_"))
            {
                string agentName = instance.traitName.Substring("AlignedTo_".Length);
                AlignedTrait aligned = new AlignedTrait { AgentName = agentName };
                hook = aligned;
                hook.Instance = instance;
                return true;
            }
            hook = null;
            return false;
        }
    }
    public class LoyalTraitFactory : HookFactoryBase<Trait>
    {
        public override bool TryCreate(Trait instance, out IHook<Trait> hook)
        {
            if (instance.traitName.StartsWith("LoyalTo_"))
            {
                string agentName = instance.traitName.Substring("LoyalTo_".Length);
                LoyalTrait loyal = new LoyalTrait { AgentName = agentName };
                hook = loyal;
                hook.Instance = instance;
                return true;
            }
            hook = null;
            return false;
        }
    }
}