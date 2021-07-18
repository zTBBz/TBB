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
    class MTP
    {
        public static bool IsATOIInstalled;
        public void Awake()
        {
            RoguePatcher Patcher = new RoguePatcher(Main.MainInstance, typeof(MTP));
            Patcher.Postfix(typeof(Relationships), "SetupRelationshipOriginal", new Type[1] { typeof(Agent) });
            IsATOIInstalled = File.Exists(Path.GetFullPath(Path.Combine(Paths.PluginPath, "aTonOfItems.dll")));
            RogueFramework.TraitFactories.Add(new AlignedTraitFactory());
            RogueLibs.CreateCustomUnlock(new TraitUnlock("AlignedTo_Gangbanger") { UnlockCost = 0, CharacterCreationCost = 5 },
                new CustomNameInfo
                {
                    English = "Crepe Rolle",
                    Russian = "Друг блинчиков"
                },
                new CustomNameInfo
                {
                    English = "You back the Blue, but the other kind. Throughout your early life, you rolled with Crepes.",
                    Russian = "После нескольких лет в трущобах, вы связали свою жизнь с блинчиками."
                });
            RogueLibs.CreateCustomUnlock(new TraitUnlock("AlignedTo_GangbangerB") { UnlockCost = 0, CharacterCreationCost = 5 },
                new CustomNameInfo
                {
                    English = "Blahd Brother",
                    Russian = "Друг кровяных"
                },
                new CustomNameInfo
                {
                    English = "Due to your love of bad food, pointless work, and raw deals, the Soldiers see you as one of their own.",
                    Russian = "После нескольких лет в трущобах, вы связали свою жизнь с кровяными."
                });
            RogueLibs.CreateCustomUnlock(new TraitUnlock("LoyalTo_Soldier") { UnlockCost = 0, CharacterCreationCost = 4 },
                new CustomNameInfo
                {
                    English = "Honorary Sergeant",
                    Russian = "Салага"
                },
                new CustomNameInfo
                {
                    English = "Your father is a former military man, it's no secret that for all soldiers you are a native rookie",
                    Russian = "Ваш отец бывший военный, никому уже не секрет что для всех солдат вы родной салага."
                });
            RogueLibs.CreateCustomUnlock(new TraitUnlock("LoyalTo_Mafia") { UnlockCost = 0, CharacterCreationCost = 4 },
                new CustomNameInfo
                {
                    English = "Spaghetti Connoisseur",
                    Russian = "Ценитель спагетти"
                },
                new CustomNameInfo
                {
                    English = "The mafia saw you eating spaghetti downtown one time. Ever since, you have carried their undying respect and loyalty.<color=#ff0000ff>[Every new floor +30 Ammo Box]</color>",
                    Russian = "Будучи в деловом центре вы попробовали спагетти, с тех пор когда вас видят мафиози они признают вас истинным ценителем спаггети.<color=#ff0000ff>[Каждый этаж +30 Ящик с боеприпасами]</color>."
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
}