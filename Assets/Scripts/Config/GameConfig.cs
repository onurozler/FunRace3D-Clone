using Game.LevelSystem.Base;

namespace Config
{
    public static class GameConfig
    {
        public static float CHARACTER_SPEED = 5f;
        
        
        // It can be randomized, just for test cases now.
        public static LevelLength GetLevelLength(int levelindex)
        {
            if (levelindex < 5)
                return LevelLength.SHORT;
            if (levelindex > 5 && levelindex < 15)
                return LevelLength.MEDIUM;
            
            return LevelLength.LONG;
        }

        public static LevelDifficulty GetLevelDifficulty(int levelindex)
        {
            if (levelindex < 5)
                return LevelDifficulty.EASY;
            if (levelindex > 5 && levelindex < 15)
                return LevelDifficulty.MEDIUM;
            
            return LevelDifficulty.HARD;
        }
    }
}
