using RogueLibsCore;

namespace TBB
{
    public class ModulesSwitcher
    {
        public void Awake()
        {
            RogueLibs.CreateCustomName("UBS_Names_Display_Off", "Interface", new CustomNameInfo
            {
                English = "<color=#ff0000ff>UBS Names</color>",
                Russian = "<color=#ff0000ff>Имена UBS</color>"
            });
            RogueLibs.CreateCustomName("UBS_Names_Display_On", "Interface", new CustomNameInfo
            {
                English = "<color=#008000ff>UBS Names</color>",
                Russian = "<color=#008000ff>Имена UBS</color>"
            });
            RogueLibs.CreateCustomName("UBS_Bots1_Display_Off", "Interface", new CustomNameInfo
            {
                English = "<color=#ff0000ff>UBS Bots</color>",
                Russian = "<color=#ff0000ff>Боты UBS</color>"
            });
            RogueLibs.CreateCustomName("UBS_Bots1_Display_On", "Interface", new CustomNameInfo
            {
                English = "<color=#008000ff>UBS Bots</color>",
                Russian = "<color=#008000ff>Боты UBS</color>"
            });
            RogueLibs.CreateCustomName("SMaD_Display_Off", "Interface", new CustomNameInfo
            {
                English = "<color=#ff0000ff>SMaD</color>",
                Russian = "<color=#ff0000ff>SMaD</color>"
            });
            RogueLibs.CreateCustomName("SMaD_Display_On", "Interface", new CustomNameInfo
            {
                English = "<color=#008000ff>SMaD</color>",
                Russian = "<color=#008000ff>SMaD</color>"
            });
            RogueLibs.CreateCustomName("MTP_Display_Off", "Interface", new CustomNameInfo
            {
                English = "<color=#ff0000ff>MTP</color>",
                Russian = "<color=#ff0000ff>MTP</color>"
            });
            RogueLibs.CreateCustomName("MTP_Display_On", "Interface", new CustomNameInfo
            {
                English = "<color=#008000ff>MTP</color>",
                Russian = "<color=#008000ff>MTP</color>"
            });
            RogueLibs.CreateCustomName("aToI_Display_Off", "Interface", new CustomNameInfo
            {
                English = "<color=#ff0000ff>aToI</color>",
                Russian = "<color=#ff0000ff>aToI</color>"
            });
            RogueLibs.CreateCustomName("aToI_Display_On", "Interface", new CustomNameInfo
            {
                English = "<color=#008000ff>aToI</color>",
                Russian = "<color=#008000ff>aToI</color>"
            });

            // SMaD buttons

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

            // MTP buttons

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

            // aToI buttons

            RogueLibs.CreateCustomName("aToI_Off_colored", "Unlock", new CustomNameInfo
            {
                English = "<color=#ff0000ff>Swith off [aToI]</color>",
                Russian = "<color=#ff0000ff>Выключить [aToI]</color>"
            });
            RogueLibs.CreateCustomName("aToI_Off", "Unlock", new CustomNameInfo
            {
                English = "Swith off [aToI]",
                Russian = "Выключить [aToI]"
            });
            RogueLibs.CreateCustomName("D_aToI_Off", "Unlock", new CustomNameInfo
            {
                English = "Changes all the items, etc. of the aToI module, depending on the name of the button",
                Russian = "Изменяет все предметы и т.д aToI модуля в зависимости от названия кнопки"
            });
            RogueLibs.CreateCustomName("aToI_On_colored", "Unlock", new CustomNameInfo
            {
                English = "<color=#008000ff>Swith on [aToI]</color>",
                Russian = "<color=#008000ff>Включить [aToI]</color>"
            });
            RogueLibs.CreateCustomName("aToI_On", "Unlock", new CustomNameInfo
            {
                English = "Swith on [aToI]",
                Russian = "Включить [aToI]"
            });
            RogueLibs.CreateCustomName("D_aToI_On", "Unlock", new CustomNameInfo
            {
                English = "Changes all the items, etc. of the aToI module, depending on the name of the button",
                Russian = "Изменяет все предметы и т.д aToI модуля в зависимости от названия кнопки"
            });

            // UBS buttons

            RogueLibs.CreateCustomName("UBSNames_Off_colored", "Unlock", new CustomNameInfo
            {
                English = "<color=#ff0000ff>Swith off NPC renaming [UBS]</color>",
                Russian = "<color=#ff0000ff>Выключить переименование НПС [UBS]</color>"
            });
            RogueLibs.CreateCustomName("UBSNames_Off", "Unlock", new CustomNameInfo
            {
                English = "Swith off NPC renaming [UBS]",
                Russian = "Выключить переименование НПС [UBS]"
            });
            RogueLibs.CreateCustomName("D_UBSNames_Off", "Unlock", new CustomNameInfo
            {
                English = "Changes parameter renaming NPC in UBS module, depending on the name of the button",
                Russian = "Изменяет параметр переименования НПС в UBS модуле в зависимости от названия кнопки"
            });
            RogueLibs.CreateCustomName("UBSNames_On_colored", "Unlock", new CustomNameInfo
            {
                English = "<color=#008000ff>Swith on NPC renaming [UBS]</color>",
                Russian = "<color=#008000ff>Включить переименование НПС [UBS]</color>"
            });
            RogueLibs.CreateCustomName("UBSNames_On", "Unlock", new CustomNameInfo
            {
                English = "Swith on NPC renaming [UBS]",
                Russian = "Включить переименование НПС [UBS]"
            });
            RogueLibs.CreateCustomName("D_UBSNames_On", "Unlock", new CustomNameInfo
            {
                English = "Changes parameter renaming NPC in UBS module, depending on the name of the button",
                Russian = "Изменяет параметр переименования НПС в UBS модуле в зависимости от названия кнопки"
            });

            RogueLibs.CreateCustomName("UBSBots1_Off_colored", "Unlock", new CustomNameInfo
            {
                English = "<color=#ff0000ff>Swith off Bots [UBS]</color>",
                Russian = "<color=#ff0000ff>Выключить ботов [UBS]</color>"
            });
            RogueLibs.CreateCustomName("UBSBots1_Off", "Unlock", new CustomNameInfo
            {
                English = "Swith off Bots [UBS]",
                Russian = "Выключить ботов [UBS]"
            });
            RogueLibs.CreateCustomName("D_UBSBots1_Off", "Unlock", new CustomNameInfo
            {
                English = "Changes the state of the UBS module bots, depending on the name of the button",
                Russian = "Изменяет состояние ботов UBS модуля в зависимости от названия кнопки"
            });
            RogueLibs.CreateCustomName("UBSBots1_On_colored", "Unlock", new CustomNameInfo
            {
                English = "<color=#008000ff>Swith on Bots [UBS]</color>",
                Russian = "<color=#008000ff>Включить ботов [UBS]</color>"
            });
            RogueLibs.CreateCustomName("UBSBots1_On", "Unlock", new CustomNameInfo
            {
                English = "Swith on Bots [UBS]",
                Russian = "Включить ботов [UBS]"
            });
            RogueLibs.CreateCustomName("D_UBSBots1_On", "Unlock", new CustomNameInfo
            {
                English = "Changes the state of the UBS module bots, depending on the name of the button",
                Russian = "Изменяет состояние ботов UBS модуля в зависимости от названия кнопки"
            });

            RogueLibs.CreateCustomUnlock(new SMaD_Switch());
            RogueLibs.CreateCustomUnlock(new MTP_Switch());
            RogueLibs.CreateCustomUnlock(new aToI_Switch());
            RogueLibs.CreateCustomUnlock(new UBS_Names_Switch());
            RogueLibs.CreateCustomUnlock(new UBS_Bots1_Switch());
        }
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
    public class aToI_Switch : MutatorUnlock
    {
        public aToI_Switch() : base("aToI_Switch", true)
        {
            SortingOrder = -50;
            IgnoreStateSorting = true;
        }
        public override void OnPushedButton()
        {
            if (aToI.Items[0].IsAvailable)
            {
                aToI.SetActive(false);
            }
            else
                aToI.SetActive(true);
            UpdateButton();
            UpdateMenu();
        }
        public override void UpdateButton()
        {
            base.UpdateButton();
            if (aToI.Items[0].IsAvailable)
                Text = gc.nameDB.GetName("aToI_Off_colored", "Unlock");
            else Text = gc.nameDB.GetName("aToI_On_colored", "Unlock");
        }
        public override string GetFancyName()
        {
            if (aToI.Items[0].IsAvailable)
            {
                return gc.nameDB.GetName("aToI_Off_colored", "Unlock");
            }
            else
            {
                return gc.nameDB.GetName("aToI_On_colored", "Unlock");
            }
        }
        public override string GetName()
        {
            if (aToI.Items[0].IsAvailable)
            {
                return gc.nameDB.GetName("aToI_Off", "Unlock");
            }
            else
            {
                return gc.nameDB.GetName("aToI_On", "Unlock");
            }
        }
        public override string GetDescription()
        {
            if (aToI.Items[0].IsAvailable)
            {
                return gc.nameDB.GetName("D_aToI_Off", "Unlock");
            }
            else
            {
                return gc.nameDB.GetName("D_aToI_On", "Unlock");
            }
        }
    }
    public class UBS_Names_Switch : MutatorUnlock
    {
        public UBS_Names_Switch() : base("UBS_Names_Switch", true)
        {
            SortingOrder = -50;
            IgnoreStateSorting = true;
        }
        public override void OnPushedButton()
        {
            if (UBS.UBSNames == 1)
            {
                UBS.UBSNames = 0;
            }
            else
                UBS.UBSNames = 1;
            UpdateButton();
            UpdateMenu();
        }
        public override void UpdateButton()
        {
            base.UpdateButton();
            if (UBS.UBSNames == 1)
                Text = gc.nameDB.GetName("UBSNames_Off_colored", "Unlock");
            else Text = gc.nameDB.GetName("UBSNames_On_colored", "Unlock");
        }
        public override string GetFancyName()
        {
            if (UBS.UBSNames == 1)
            {
                return gc.nameDB.GetName("UBSNames_Off_colored", "Unlock");
            }
            else
            {
                return gc.nameDB.GetName("UBSNames_On_colored", "Unlock");
            }
        }
        public override string GetName()
        {
            if (UBS.UBSNames == 1)
            {
                return gc.nameDB.GetName("UBSNames_Off", "Unlock");
            }
            else
            {
                return gc.nameDB.GetName("UBSNames_On", "Unlock");
            }
        }
        public override string GetDescription()
        {
            if (UBS.UBSNames == 1)
            {
                return gc.nameDB.GetName("D_UBSNames_Off", "Unlock");
            }
            else
            {
                return gc.nameDB.GetName("D_UBSNames_On", "Unlock");
            }
        }
    }
    public class UBS_Bots1_Switch : MutatorUnlock
    {
        public UBS_Bots1_Switch() : base("UBS_Bots1_Switch", true)
        {
            SortingOrder = -50;
            IgnoreStateSorting = true;
        }
        public override void OnPushedButton()
        {
            if (UBS.UBSBots1 == 1)
            {
                UBS.UBSBots1 = 0;
            }
            else
                UBS.UBSBots1 = 1;
            UpdateButton();
            UpdateMenu();
        }
        public override void UpdateButton()
        {
            base.UpdateButton();
            if (UBS.UBSBots1 == 1)
                Text = gc.nameDB.GetName("UBSBots1_Off_colored", "Unlock");
            else Text = gc.nameDB.GetName("UBSBots1_On_colored", "Unlock");
        }
        public override string GetFancyName()
        {
            if (UBS.UBSBots1 == 1)
            {
                return gc.nameDB.GetName("UBSBots1_Off_colored", "Unlock");
            }
            else
            {
                return gc.nameDB.GetName("UBSBots1_On_colored", "Unlock");
            }
        }
        public override string GetName()
        {
            if (UBS.UBSBots1 == 1)
            {
                return gc.nameDB.GetName("UBSBots1_Off", "Unlock");
            }
            else
            {
                return gc.nameDB.GetName("UBSBots1_On", "Unlock");
            }
        }
        public override string GetDescription()
        {
            if (UBS.UBSBots1 == 1)
            {
                return gc.nameDB.GetName("D_UBSBots1_Off", "Unlock");
            }
            else
            {
                return gc.nameDB.GetName("D_UBSBots1_On", "Unlock");
            }
        }
    }
}
