﻿using System;
using System.Text;

using ConsoleRPG.Creatures.NPC;
using ConsoleRPG.Creatures.Heros;
using ConsoleRPG.Engine;
using ConsoleRPG.Items;

using static ConsoleRPG.Utils.InputOutput;
using static ConsoleRPG.Utils.GameGraphics;
using static ConsoleRPG.Utils.Animation;
using static ConsoleRPG.Utils.Resources;
using static ConsoleRPG.Utils.Generator;
using ConsoleRPG.Utils;
using ConsoleRPG.Creature;
using System.Security.Cryptography;
using System.Threading;

namespace ConsoleRPG
{
    internal class ConsoleRPG
    {
        public static GameEngine Engine;

        private static void CreateNewPlayer()
        {
            PrintByCords("[Меню створення персонажа]", (Console.WindowWidth - 25) / 2, 0);

            PrintByCords("Введіть ім'я персонажу: ", (Console.WindowWidth - 20) / 2, Console.WindowHeight / 2);
            string name = InputValue();

            Console.Clear();

            PrintByCords("[Меню створення персонажа]", (Console.WindowWidth - 25) / 2, 0);

            PrintArrayByCords(new string[] { "[1] Варвар", "[2] Танк", "[3] Бандит\n" }, (Console.WindowWidth - 10) / 2, (Console.WindowHeight - 3) / 2);
            Print("Виберіть тип: ", AlignPrint.Center);
            int type = InputInt();

            Engine.CreatePlayer(name, type);
        }

        private static void PlayGame()
        {
            Engine = new GameEngine();

            CreateNewPlayer();

            Monster monster = Engine.GetMonster();

            while (Engine.Battle(monster) == 1)
            {
                WinScreen();
                Console.ReadKey();

                monster = Engine.GetMonster();
            }

            DeadScreen();
            Console.ReadKey();
        }

        private static int MainScreen()
        {
            Console.Clear();

            DrawMenuBanner();

            string[] menu = { "Натисніть відповідну клавішу:", "[S] Start Game", "[X] Exit" };
            PrintArrayByCords(menu, (Console.WindowWidth - MaxLenInStringArray(menu)) / 2, (Console.WindowHeight - menu.Length) / 2);

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.X:
                    Console.Clear();
                    return 1;
                default:
                    Console.Clear();
                    PlayGame();
                    return 0;
            }
        }

        private static void LoadingScreen()
        {
            DrawGameBanner();

            PrintByCords("[", 1, Console.WindowHeight - 1);
            PrintByCords("]", Console.WindowWidth - 1, Console.WindowHeight - 1);
            for (int i = 0; i < Console.WindowWidth - 3; i++)
            {
                PrintByCords("#", i + 2, Console.WindowHeight - 1);
                Thread.Sleep(30);
            }

            Console.Clear();
        }

        static void Main(string[] args)
        {
            Item item = new Item("ads", 1);
            item.Name = "tito";

            return;
            // Enable support Unicode input and output
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            PrintByCords("Для комфортної гри натисніть [F11], після [Space]", (Console.WindowWidth - 34) / 2, Console.WindowHeight / 2);
            Console.ReadKey();

            LoadingScreen();

            int exit;
            do
            {
                exit = MainScreen();
            } while (exit != 1);

            Console.Clear();
        }
    }
}

