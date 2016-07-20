﻿using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Constants;

namespace LazyLucian
{
    public static class CustomEvents
    {
        public static readonly Item Youmuu = new Item((int)ItemId.Youmuus_Ghostblade);
        public static bool PassiveUp { get; set; }

        public static void OnSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender.IsDead || !sender.IsMe) return;
            switch (args.Slot)
            {
                case SpellSlot.Q:
                    Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos.Normalized() * 1);
                    //Core.DelayAction(Orbwalker.ResetAutoAttack, 250);
                    break;
                case SpellSlot.W:
                    Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos.Normalized() * 1);
                    //Core.DelayAction(Orbwalker.ResetAutoAttack, 250);
                    break;
                case SpellSlot.E:
                    Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos.Normalized() * 1);
                    //Core.DelayAction(Orbwalker.ResetAutoAttack, 250);

                    break;
            }
            if (args.IsAutoAttack() || Game.Time - PassiveTimer > 2)
            {
                PassiveUp = false;
            }
        }

        
        public static void OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender.IsDead || !sender.IsMe) return;
            switch (args.Slot)
            {
                case SpellSlot.Q:
                    PassiveUp = true;
                    PassiveTimer = Game.Time;
                    break;
                case SpellSlot.W:
                    PassiveUp = true;
                    PassiveTimer = Game.Time;
                    break;
                case SpellSlot.E:
                    PassiveUp = true;
                    PassiveTimer = Game.Time;
                    break;
                case SpellSlot.R:
                    if (Program.Player.InventoryItems.HasItem((int)ItemId.Youmuus_Ghostblade))
                    {
                        Youmuu.Cast();
                    }
                    break;
            }
        }

        public static float PassiveTimer { get; set; }


        
        public static void OnBuffLose(Obj_AI_Base sender, Obj_AI_BaseBuffLoseEventArgs args)
        {
            if (sender.IsDead || !sender.IsMe) return;
            if (args.Buff.Name == "LucianPassiveBuff")
            PassiveUp = false;
        }

        public static void OnBuffGain(Obj_AI_Base sender, Obj_AI_BaseBuffGainEventArgs args)
        {
            if (sender.IsDead || !sender.IsMe) return;
            if (args.Buff.Name == "LucianPassiveBuff")
                PassiveUp = true;
        }
        

        public static List<Obj_AI_Base> GetBuffedObjects(IEnumerable<Obj_AI_Base> objectList = null)
        {
            var objects =
                ObjectManager.Get<Obj_AI_Base>()
                    .Where(o => o.IsValidTarget(Player.Instance.GetAutoAttackRange(o)) && o.HasBuff("LucianWDebuff"))
                    .ToList();
            return
                objects.Where(o => Program.Player.IsInAutoAttackRange(o))
                    .OrderBy(o => o.Distance(Program.Player))
                    .ToList();
        }
    }
}