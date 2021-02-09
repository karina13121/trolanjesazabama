using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using SharpDX;
using System;

namespace zablje_trolovanje
{
    class Program
    {
        static EnsoulSharp.SDK.MenuUI.Menu menu, fountain, chat, follow, solo;
        static Spell Q, W, E, R;
        static bool b = false;
        static bool a = false;
        static void Main(string[] args)
        {
            GameEvent.OnGameLoad += GameEvent_OnGameLoad;
            Game.OnUpdate += Game_OnUpdate;
        }

        private static void Game_OnUpdate(EventArgs args)
        {


            foreach (var ally in GameObjects.AllyHeroes)
            {
                if (follow.GetValue<MenuBool>(ally.CharacterName).Enabled)
                {
                    GameObjects.Player.IssueOrder(GameObjectOrder.MoveTo, ally.Position);
                }
            }

            Vector3 redPos = new Vector3();
            redPos.X = 14286;
            redPos.Y = 14270;
            redPos.Z = 171;
            Vector3 bluePos = new Vector3();
            bluePos.X = 410;
            bluePos.Y = 416;
            bluePos.Z = 182;

            if (solo.GetValue<MenuBool>("solodragon").Enabled)
            {
                Vector3 dragonPos = new Vector3();
                if (!ObjectManager.Player.IsDead)
                {
                    dragonPos.X = 9878;
                    dragonPos.Y = 4406; // x = 9878 y = 4406 z = 2406
                    dragonPos.Z = 2406;
                    ObjectManager.Player.IssueOrder(GameObjectOrder.MoveTo, dragonPos);
                }
                if (ObjectManager.Player.Position.X == 9878)
                {
                    Vector2 vp = new Vector2();
                    vp.X = ObjectManager.Player.Position.X;
                    vp.Y = ObjectManager.Player.Position.Y;
                    Q.Cast(vp);
                    W.Cast(vp);
                    E.Cast();
                    R.Cast(vp);
                    
                }
            }
            if (solo.GetValue<MenuBool>("solobaron").Enabled)
            {
                Vector3 baronPos = new Vector3();
                if (!ObjectManager.Player.IsDead)
                {
                    baronPos.X = 4844;
                    baronPos.Y = 10334;
                    baronPos.Z = -71;
                    // 4844 / 10334 / -71
                    ObjectManager.Player.IssueOrder(GameObjectOrder.MoveTo, baronPos);
                }
                if (ObjectManager.Player.Position.X == 4844)
                {
                    Vector2 vpz = new Vector2();
                    vpz.X = ObjectManager.Player.Position.X;
                    vpz.Y = ObjectManager.Player.Position.Y;
                    Q.Cast(vpz);
                    W.Cast(vpz);
                    E.Cast(vpz);
                    R.Cast(vpz);
                }
            }

            if (fountain.GetValue<EnsoulSharp.SDK.MenuUI.MenuBool>("blue").Enabled)
            {
                if (!ObjectManager.Player.IsDead)
                {
                    ObjectManager.Player.IssueOrder(GameObjectOrder.MoveTo, redPos);
                }
            }
            if (fountain.GetValue<EnsoulSharp.SDK.MenuUI.MenuBool>("red").Enabled)
            {
                if (!ObjectManager.Player.IsDead)
                {
                    ObjectManager.Player.IssueOrder(GameObjectOrder.MoveTo, bluePos);
                }
            }
            if (chat.GetValue<MenuBool>("enabled1").Enabled)
            {
                if (chat.GetValue<MenuBool>("toall").Enabled)
                {
                    if (chat.GetValue<MenuList>("list").Index == 0)
                    {
                        Game.Say("EZ", true);
                    }
                    if (chat.GetValue<MenuList>("list").Index == 1)
                    {
                        Game.Say("KYS", true);
                    }
                    if (chat.GetValue<MenuList>("list").Index == 2)
                    {
                        Game.Say("FUCK U RETARDS", true);
                    }
                    if (chat.GetValue<MenuList>("list").Index == 3)
                    {
                        Game.Say("GYPSIES", true);
                    }
                    if (chat.GetValue<MenuList>("list").Index == 4)
                    {
                        Game.Say("FUCK U MUSLIMS", true);
                    }
                    if (chat.GetValue<MenuList>("list").Index == 5)
                    {
                        Game.Say("DIE IRL KYS MOTHERFUCKERS", true);
                    }
                }
                else if (!chat.GetValue<MenuBool>("toall").Enabled)
                {
                    if (chat.GetValue<MenuList>("list").Index == 0)
                    {
                        Game.Say("EZ", false);
                    }
                    if (chat.GetValue<MenuList>("list").Index == 1)
                    {
                        Game.Say("KYS", false);
                    }
                    if (chat.GetValue<MenuList>("list").Index == 2)
                    {
                        Game.Say("FUCK U RETARDS", false);
                    }
                    if (chat.GetValue<MenuList>("list").Index == 3)
                    {
                        Game.Say("GYPSIES", false);
                    }
                    if (chat.GetValue<MenuList>("list").Index == 4)
                    {
                        Game.Say("FUCK U MUSLIMS", false);
                    }
                    if (chat.GetValue<MenuList>("list").Index == 5)
                    {
                        Game.Say("DIE IRL KYS MOTHERFUCKERS", false);
                    }
                }
            }
        }

        private static void GameEvent_OnGameLoad()
        {
            Q = new Spell(SpellSlot.Q);
            W = new Spell(SpellSlot.W);
            E = new Spell(SpellSlot.E);
            R = new Spell(SpellSlot.R);
            Game.Print("zablje trolovanje za nidzu loudovano");
            Menu();
        }
        private static void Menu()
        {
            menu = new EnsoulSharp.SDK.MenuUI.Menu("menu", "Zablje Trolovanje", true);
            fountain = new EnsoulSharp.SDK.MenuUI.Menu("fountain", "Fontana :D", false);
            chat = new EnsoulSharp.SDK.MenuUI.Menu("chat", "Chat", false);
            follow = new Menu("follow", "prati timmejte :D", false);
            solo = new Menu("solo", "Solo :D", false);
            var splitter = new EnsoulSharp.SDK.MenuUI.MenuSeparator("sep", "nidzo ako si plavi tim tikuj blue da intas, red obrnuto");
            var mbool = new EnsoulSharp.SDK.MenuUI.MenuBool("blue", "Plavi", false);
            var rbool = new EnsoulSharp.SDK.MenuUI.MenuBool("red", "Crveni", false);
            var toall = new MenuBool("toall", "Sendati /all?", true);
            var enabled = new MenuBool("enabled1", "Ukljuceno?", false);
            var list = new MenuList("list", "Lista", new string[] { "EZ", "KYS", "FUCK U RETARDS", "GYPSIES", "FUCK U MUSLIMS", "DIE IRL KYS MOTHERFUCKERS" }, 0);
            var solodragon = new MenuBool("solodragon", "Solo zmaj :D", false);
            var solobaron = new MenuBool("solobaron", "Solo baron :D", false);
            foreach (var ally in GameObjects.AllyHeroes)
            {
                follow.Add(new MenuBool(ally.CharacterName, $"prati: {ally.CharacterName} :D", false));
            }
            menu.Add(fountain);
            menu.Add(solo);
            solo.Add(solodragon);
            solo.Add(solobaron);
            fountain.Add(splitter);
            chat.Add(enabled);
            chat.Add(toall);
            chat.Add(list);
            menu.Add(chat);
            menu.Add(follow);
            fountain.Add(mbool);
            fountain.Add(rbool);
            menu.Attach();
        }
    }
}
