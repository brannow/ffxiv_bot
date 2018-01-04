using System;
using System.Windows.Forms;

namespace FFXIV_netBot.Module
{
    public struct CombatConfig
    {
        public GeneralKeys movement;
    }

    public struct GatheringConfig
    {
        public GeneralKeys movement;
        public int matureTree;
        public int lushVegetationPatch;
        public int mineralDeposit;
        public int rockyOutcrop;
    }

    public struct FishingConfig
    {
        public GeneralKeys movement;
        public FishingKeys fishing;
        public int biteDelay;
    }

    public struct GeneralKeys
    {
        public UseableKeys forward; // movement
        public UseableKeys backward; // movement
        public UseableKeys rotateLeft; // movement
        public UseableKeys rotateRight; // movement
        public UseableKeys action; // action
    }

    public struct FishingKeys
    {
        public UseableKeys startFishing; // fishing 
        public UseableKeys catchFish; // fishing 
    }



    public enum UseableKeys : int
    {
        None = 0,
        Tab = Keys.Tab,
        Left = Keys.Left,
        Up = Keys.Up,
        Right = Keys.Right,
        Down = Keys.Down,
        D0 = Keys.D0,
        D1 = Keys.D1,
        D2 = Keys.D2,
        D3 = Keys.D3,
        D4 = Keys.D4,
        D5 = Keys.D5,
        D6 = Keys.D6,
        D7 = Keys.D7,
        D8 = Keys.D8,
        D9 = Keys.D9,
        A = Keys.A,
        B = Keys.B,
        C = Keys.C,
        D = Keys.D,
        E = Keys.E,
        F = Keys.F,
        G = Keys.G,
        H = Keys.H,
        I = Keys.I,
        J = Keys.J,
        K = Keys.K,
        L = Keys.L,
        M = Keys.M,
        N = Keys.N,
        O = Keys.O,
        P = Keys.P,
        Q = Keys.Q,
        R = Keys.R,
        S = Keys.S,
        T = Keys.T,
        U = Keys.U,
        V = Keys.V,
        W = Keys.W,
        X = Keys.X,
        Y = Keys.Y,
        Z = Keys.Z,
        Num0 = Keys.NumPad0,
        Num1 = Keys.NumPad1,
        Num2 = Keys.NumPad2,
        Num3 = Keys.NumPad3,
        Num4 = Keys.NumPad4,
        Num5 = Keys.NumPad5,
        Num6 = Keys.NumPad6,
        Num7 = Keys.NumPad7,
        Num8 = Keys.NumPad8,
        Num9 = Keys.NumPad9,
        F1 = Keys.F1,
        F2 = Keys.F2,
        F3 = Keys.F3,
        F4 = Keys.F4,
        F5 = Keys.F5,
        F6 = Keys.F6,
        F7 = Keys.F7,
        F8 = Keys.F8,
        F9 = Keys.F9,
        F10 = Keys.F10,
        F11 = Keys.F11,
        F12 = Keys.F12
    }

    public class RestoreConfigDefault
    {
        public static FishingConfig defaultFishingConfig()
        {
            FishingConfig defaultFishing = new FishingConfig();
            defaultFishing.biteDelay = (int)0;

            GeneralKeys defaultGeneral = new GeneralKeys();
            defaultGeneral.forward = UseableKeys.W;
            defaultGeneral.backward = UseableKeys.S;
            defaultGeneral.rotateLeft = UseableKeys.A;
            defaultGeneral.rotateRight = UseableKeys.D;
            defaultGeneral.action = UseableKeys.Num0;
            defaultFishing.movement = defaultGeneral;

            FishingKeys defaultFishKeys = new FishingKeys();
            defaultFishKeys.startFishing = UseableKeys.D2;
            defaultFishKeys.catchFish = UseableKeys.D3;
            defaultFishing.fishing = defaultFishKeys;

            return defaultFishing;
        }

        public static GatheringConfig defaultGatheringConfig()
        {
            GatheringConfig defaultGathering = new GatheringConfig();
            defaultGathering.matureTree = 0;
            defaultGathering.lushVegetationPatch = 0;
            defaultGathering.mineralDeposit = 0;
            defaultGathering.rockyOutcrop = 0;

            GeneralKeys defaultGeneral = new GeneralKeys();
            defaultGeneral.forward = UseableKeys.W;
            defaultGeneral.backward = UseableKeys.S;
            defaultGeneral.rotateLeft = UseableKeys.A;
            defaultGeneral.rotateRight = UseableKeys.D;
            defaultGeneral.action = UseableKeys.Num0;
            defaultGathering.movement = defaultGeneral;

            return defaultGathering;
        }
    }
}
