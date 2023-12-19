using MoreMountains.InventoryEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class simdata : MonoBehaviour
    {
        public static int Exit_Direction;

        //230929
        public static int EntryPoint = 4;

        public static int[,] EntryPoints;

        //231003
        public static int[,] ExitPoint;

        public static bool isExitTrue = false;

        //231003
        public static int createmazeflag;

        //231004
        public static int pastExitPointx, pastExitPointy;

        //231006
        public static int Score = 0;

        //231010
        public static bool isFinished = false;
        public static float CurrentTime = 0f;

        //231020
        public static int[,,] RandomMapNum;

        //231112
        public static bool isLeftGunDeath = false;
        public static bool isRightGunDeath = false;

        public static GameObject BossGameObject;

        //231114
        public static List<Inventory> RegisteredInventories;

        public static bool isInventorySaved;

        //231122
        public static int bossOrb = 0;
        public static int characterLevel = 1;
    }

