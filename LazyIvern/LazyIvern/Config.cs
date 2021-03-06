﻿using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable StringLiteralsWordIsNotInDictionary
// ReSharper disable IdentifierWordIsNotInDictionary

// ReSharper disable MemberHidesStaticFromOuterClass
// ReSharper disable InconsistentNaming

namespace LazyIvern
{
    public static class Config
    {
        private const string MenuName = "Lazy Ivern";
        private static readonly Menu Menu;

        static Config()
        {
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Enjoy Lazy Ivern :)");
            Menu.AddLabel("Good luck, have fun!");

            Modes.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            /// <summary>
            ///     <see cref="Initialize" /> <see cref="Menu" /> for each Mode
            /// </summary>
            private static readonly Menu
                ComboMenu,
                HarassMenu,
                LaneClearMenu,
                JungleClearMenu,
                LastHitMenu,
                FleeMenu,
                SkinMenu,
                DrawMenu,
                PermaActiveMenu;

            static Modes()
            {
                ComboMenu = Menu.AddSubMenu("Combo");
                HarassMenu = Menu.AddSubMenu("Harass");
                LaneClearMenu = Menu.AddSubMenu("LaneClear");
                JungleClearMenu = Menu.AddSubMenu("JungleClear");
                LastHitMenu = Menu.AddSubMenu("LastHit");
                FleeMenu = Menu.AddSubMenu("Flee");
                DrawMenu = Menu.AddSubMenu("Drawings");
                SkinMenu = Menu.AddSubMenu("Skins");
                PermaActiveMenu = Menu.AddSubMenu("PermaActive");

                // Initialize all modes
                // Combo
                Combo.Initialize();

                // Harass
                Harass.Initialize();

                //LaneClear
                LaneClear.Initialize();

                //JungleClear
                JungleClear.Initialize();

                //LastHit
                LastHit.Initialize();

                //Flee
                Flee.Initialize();

                //Skins
                Skins.Initialize();

                //PermaActive
                PermaActive.Initialize();

                //Drawings
                Drawings.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly Slider _useQmana;
                private static readonly CheckBox _useW;
                private static readonly Slider _useWmana;
                private static readonly CheckBox _useE;
                private static readonly Slider _useEmana;
                private static readonly Slider _keepWstacks;

                static Combo()
                {
                    ComboMenu.AddGroupLabel("Combo");

                    _useQ = ComboMenu.Add("useQ", new CheckBox("Use Q"));
                    ComboMenu.AddSeparator(20);

                    _useQmana = ComboMenu.Add("useQmana", new Slider("If Mana % > {0}", 0, 0, 100));
                    ComboMenu.AddSeparator(20);

                    _useW = ComboMenu.Add("useW", new CheckBox("Use W"));
                    ComboMenu.AddSeparator(20);

                    _useWmana = ComboMenu.Add("useWmana", new Slider("If Mana % > {0}", 0, 0, 100));
                    ComboMenu.AddSeparator(20);

                    _keepWstacks = ComboMenu.Add("keepWstacks", new Slider("Keep {0} Stacks", 1, 0, 3));
                    ComboMenu.AddSeparator(50);

                    _useE = ComboMenu.Add("useE", new CheckBox("Use E"));
                    ComboMenu.AddSeparator(20);

                    _useEmana = ComboMenu.Add("useEmana", new Slider("If Mana % > {0}", 0, 0, 100));
                    ComboMenu.AddSeparator(50);
                }

                public static bool useQ => _useQ.CurrentValue;
                public static int useQmana => _useQmana.CurrentValue;
                public static bool useW => _useW.CurrentValue;
                public static int useWmana => _useWmana.CurrentValue;
                public static int keepWstacks => _keepWstacks.CurrentValue;
                public static bool useE => _useE.CurrentValue;
                public static int useEmana => _useEmana.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                private static readonly CheckBox _useQ;
                private static readonly Slider _useQmana;
                private static readonly CheckBox _useW;
                private static readonly Slider _useWmana;
                private static readonly CheckBox _useE;
                private static readonly Slider _useEmana;
                private static readonly Slider _keepWstacks;

                static Harass()
                {
                    HarassMenu.AddGroupLabel("Harass");

                    _useQ = HarassMenu.Add("useQ", new CheckBox("Use Q"));
                    HarassMenu.AddSeparator(20);

                    _useQmana = HarassMenu.Add("useQmana", new Slider("If Mana % > {0}", 60, 0, 100));
                    HarassMenu.AddSeparator(50);

                    _useW = HarassMenu.Add("useW", new CheckBox("Use W"));
                    HarassMenu.AddSeparator(20);

                    _useWmana = HarassMenu.Add("useWmana", new Slider("If Mana % > {0}", 60, 0, 100));
                    HarassMenu.AddSeparator(20);

                    _keepWstacks = HarassMenu.Add("keepWstacks", new Slider("Keep {0} Stacks", 1, 0, 3));
                    HarassMenu.AddSeparator(50);

                    _useE = HarassMenu.Add("useE", new CheckBox("Use E"));
                    HarassMenu.AddSeparator(20);

                    _useEmana = HarassMenu.Add("useEmana", new Slider("If Mana % > {0}", 60, 0, 100));
                }

                public static bool useQ => _useQ.CurrentValue;
                public static int useQmana => _useQmana.CurrentValue;
                public static bool useW => _useW.CurrentValue;
                public static int useWmana => _useWmana.CurrentValue;
                public static bool useE => _useE.CurrentValue;
                public static int useEmana => _useEmana.CurrentValue;
                public static int keepWstacks => _keepWstacks.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class Flee
            {
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;

                static Flee()
                {
                    FleeMenu.AddGroupLabel("Flee");

                    _useW = FleeMenu.Add("useW", new CheckBox("Use W"));
                    FleeMenu.AddSeparator(50);

                    _useE = FleeMenu.Add("useE", new CheckBox("Use E"));
                }

                public static void Initialize()
                {
                }

                public static bool useW => _useW.CurrentValue;
                public static bool useE => _useE.CurrentValue;
            }

            public static class LaneClear
            {
                private static readonly CheckBox _useE;
                private static readonly Slider _useEmana;

                static LaneClear()
                {
                    LaneClearMenu.AddGroupLabel("LaneClear");

                    _useE = LaneClearMenu.Add("useE", new CheckBox("Use Q"));
                    _useEmana = LaneClearMenu.Add("useEmana", new Slider("If Mana % > {0}", 60, 0, 100));

                }

                public static bool useE => _useE.CurrentValue;
                public static int useEmana => _useEmana.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class JungleClear
            {
                static JungleClear()
                {
                    //ToDo: Add JungleClear hu3
                }

                public static void Initialize()
                {
                }
            }

            public static class Skins
            {
                private static readonly CheckBox _useSkin;
                private static readonly ComboBox _skinID;

                static Skins()
                {
                    _useSkin = SkinMenu.Add("useSkin", new CheckBox("Use Skin"));
                    SkinMenu.AddSeparator(10);

                    _skinID = SkinMenu.Add("skinID", new ComboBox("Skin:", 1, "Classic", "Candy Ivern"));
                }

                public static bool useSkin => _useSkin.CurrentValue;
                public static int skinID => _skinID.CurrentValue;

                public static void Initialize()
                {
                }
            }

            public static class LastHit
            {
                static LastHit()
                {
                    LastHitMenu.AddGroupLabel("Nothing here :/");
                }

                public static void Initialize()
                {
                }
            }

            public static class PermaActive
            {
                private static readonly CheckBox _movePet;
                private static readonly ComboBox _petTarget;
                private static readonly CheckBox _jumpTarget;
                private static readonly CheckBox _jumpOnlyCombo;
                private static readonly Slider _jumpEnemiesCount;

                static PermaActive()
                {
                    PermaActiveMenu.AddGroupLabel("PermaActive");
                    _movePet = PermaActiveMenu.Add("movePet", new CheckBox("Move Daisy"));
                    _petTarget = PermaActiveMenu.Add("petTarget",
                        new ComboBox("Daisy's Target:", 0, "My Target", "Closest Target"));
                    PermaActiveMenu.AddSeparator(50);

                    _jumpTarget = PermaActiveMenu.Add("jumpTarget", new CheckBox("Jump to Q buffed Enemies"));
                    _jumpOnlyCombo = PermaActiveMenu.Add("jumpOnlyCombo", new CheckBox("Jump only in Combo mode"));
                    _jumpEnemiesCount = PermaActiveMenu.Add("jumpEnemiesCount",
                        new Slider("if less or equal to {0} enemie(s) around", 1, 0, 5));
                }

                public static void Initialize()
                {
                }

                public static bool movePet => _movePet.CurrentValue;
                public static int petTarget => _petTarget.CurrentValue;
                public static bool jumpTarget => _jumpTarget.CurrentValue;
                public static bool jumpOnlyCombo => _jumpOnlyCombo.CurrentValue;
                public static int jumpEnemiesCount => _jumpEnemiesCount.CurrentValue;
            }

            public static class Drawings
            {
                private static readonly CheckBox _disable;
                private static readonly ComboBox _drawMode;
                private static readonly CheckBox _drawQ;
                private static readonly CheckBox _drawW;
                private static readonly CheckBox _drawE;
                private static readonly CheckBox _drawR;

                static Drawings()
                {
                    DrawMenu.AddGroupLabel("Drawings");

                    _disable = DrawMenu.Add("disable", new CheckBox("Disable all drawings", false));
                    DrawMenu.AddSeparator(50);

                    _drawMode = DrawMenu.Add("skinID", new ComboBox("Draw:", 0, "Only ready", "always"));
                    DrawMenu.AddSeparator(20);

                    _drawQ = DrawMenu.Add("drawQ", new CheckBox("Draw Q"));
                    _drawW = DrawMenu.Add("drawW", new CheckBox("Draw W"));
                    _drawE = DrawMenu.Add("drawE", new CheckBox("Draw E"));
                    _drawR = DrawMenu.Add("drawR", new CheckBox("Draw R"));
                }

                public static bool disable => _disable.CurrentValue;
                public static int drawMode => _drawMode.CurrentValue;
                public static bool drawQ => _drawQ.CurrentValue;
                public static bool drawW => _drawW.CurrentValue;
                public static bool drawE => _drawE.CurrentValue;
                public static bool drawR => _drawR.CurrentValue;

                public static void Initialize()
                {
                }
            }
        }
    }
}