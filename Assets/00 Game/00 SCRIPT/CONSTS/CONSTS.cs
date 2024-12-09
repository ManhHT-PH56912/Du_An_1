using UnityEngine;

namespace Consts
{
    public static class Scenes
    {
        public const string MAIN_MENU = "MainMenu";
        public const string MAP1 = "Map1";
        public const string MAP2 = "Map2";
        public const string MAP3 = "Map3";
        public const string MAP4 = "Map4";
        public const string MAP5 = "Map5";
    }

    public static class Tags
    {
        public static string PLAYER_TAG = "Player";
        public static string ENEMY_TAGS = "Enemy";
        public static string COINS_TAG = "Coins";
        public static string GROUND_TAG = "Ground";
        public static string TRAP_TAG = "Trap";
        public static string MEXT_lEVEL_TAG = "NextLevel";
        public static string CHECKPOINT_TAG = "CheckPoint";
        public static string WATER_TAG = "Water";

    }

    public static class Layers
    {
        public static LayerMask player = LayerMask.GetMask("Player");
        public static LayerMask Enemy = LayerMask.GetMask("Enemy");
        public static LayerMask ground = LayerMask.GetMask("Ground");
        public static LayerMask wall = LayerMask.GetMask("Wall");
    }
}
