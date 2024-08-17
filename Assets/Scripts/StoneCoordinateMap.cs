/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2024, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */

using System.Collections.Generic;


namespace Assets.Scripts
{
    public class StoneCoordinateMap
    {
        public const string TopStone = "TopStone";
        public const string LeftStone = "LeftStone";
        public const string InnerLeftStone = "InnerLeftStone";
        public const string InnerRightStone = "InnerRightStone";
        public const string RightStone = "RightStone";
        public const string MidLeftStone = "MidLeftStone";
        public const string MidRightStone = "MidRightStone";
        public const string BottomStone = "BottomStone";
        public const string LastLeftStone = "LastLeftStone";
        public const string LastRightStone = "LastRightStone";

        public const string TopMovePlate = "TopMovePlate";
        public const string LeftMovePlate = "LeftMovePlate";
        public const string InnerLeftMovePlate = "InnerLeftMovePlate";
        public const string InnerRightMovePlate = "InnerRightMovePlate";
        public const string RightMovePlate = "RightMovePlate";
        public const string MidLefMovePlate = "MidLefMovePlate";
        public const string MidRightMovePlate = "MidRightMovePlate";
        public const string BottomMovePlate = "BottomMovePlate";
        public const string LastLeftMovePlate = "LastLeftMovePlate";
        public const string LastRightMovePlate = "LastRightMovePlate";

        public static string UnknownStone = "UnknownStone";

        public static Dictionary<string, StoneModel> StoneDictionary = new()
        {
            {TopStone, new StoneModel(TopStone, -7.33f, -3.27f, 2.62f)},
            {LeftStone, new StoneModel(LeftStone, -7.75f, -3.70f, 3.21f)},
            {InnerLeftStone, new StoneModel(InnerLeftStone, -7.72f, -3.70f, 2.75f)},
            {InnerRightStone, new StoneModel(InnerRightStone, -7.68f, -3.69f, 2.44f)},
            {RightStone, new StoneModel(RightStone, -7.68f, -3.69f, 1.98f)},
            {MidLeftStone, new StoneModel(MidLeftStone, -7.99f, -3.97f, 2.84f)},
            {MidRightStone, new StoneModel(MidRightStone, -7.94f, -3.95f, 2.34f)},
            {BottomStone, new StoneModel(BottomStone, -8.11f, -4.13f, 2.58f)},
            {LastLeftStone, new StoneModel(LastLeftStone, -8.35f, -4.39f, 2.95f)},
            {LastRightStone, new StoneModel(LastRightStone, -8.32f, -4.36f, 2.19f)}
        };

        public static Dictionary<string, MovePlateModel> MovePlateDictionary = new()
        {
            {TopStone, new MovePlateModel(TopMovePlate, -7.27f, -3.28f, 2.63f)},
            {LeftStone, new MovePlateModel(LeftMovePlate, -7.68f, -3.70f, 3.23f) },
            {InnerLeftStone, new MovePlateModel(InnerLeftMovePlate, -7.66f, -3.70f, 2.76f)},
            {InnerRightStone, new MovePlateModel(InnerRightMovePlate, -7.66f, -3.695f, 2.454f)},
            {RightStone, new MovePlateModel(RightMovePlate, -7.63f, -3.70f, 1.975f) },
            {MidLeftStone, new MovePlateModel(MidLefMovePlate, -7.91f, -3.97f, 2.845f)},
            {MidRightStone, new MovePlateModel(MidRightMovePlate, -7.91f, -3.966f, 2.338f)},
            {BottomStone, new MovePlateModel(BottomMovePlate,-8.065f, -4.146f, 2.587f)},
            {LastLeftStone, new MovePlateModel(LastLeftMovePlate, -8.306f, -4.407f, 2.96f)},
            {LastRightStone, new MovePlateModel(LastRightMovePlate, -8.305f, -4.393f, 2.197f)}
        };

        public static string GetStoneName(float x, float y, float z)
        {
            foreach (KeyValuePair<string, StoneModel> stone in StoneDictionary)
            {
                if (stone.Value.X == x && stone.Value.Y == y && stone.Value.Z == z)
                {
                    return stone.Key;
                }
            }

            return UnknownStone;
        }
    }

    public class StoneModel
    {
        public StoneModel(string name, float x, float y, float z)
        {
            Name = name;
            X = x;
            Y = y;
            Z = z;
        }

        public string Name { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }

    public class MovePlateModel
    {
        public MovePlateModel(string name, float x, float y, float z)
        {
            Name = name;
            X = x;
            Y = y;
            Z = z;
        }

        public string Name { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }
}