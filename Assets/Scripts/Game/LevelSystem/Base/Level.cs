namespace Game.LevelSystem.Base
{
    public enum LevelLength
    {
        SHORT = 3,
        MEDIUM = 7,
        LONG = 10
    }
    
    public enum LevelDifficulty
    {
        EASY = 30,
        MEDIUM = 50,
        HARD = 70
    }
    
    public class Level
    {
        public int LevelIndex;
        public LevelLength LevelLength;
        public LevelDifficulty LevelDifficulty;

        public Level(int index, LevelLength levelLength, LevelDifficulty levelDifficulty)
        {
            LevelIndex = index;
            LevelLength = levelLength;
            LevelDifficulty = levelDifficulty;
        }
    }
}
