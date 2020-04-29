namespace Game.LevelSystem.Base
{
    public enum LevelLength
    {
        SHORT = 5,
        MEDIUM = 10,
        LONG = 15
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
