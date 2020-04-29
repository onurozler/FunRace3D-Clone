namespace Game.LevelSystem.Base
{
    public enum LevelLength
    {
        SHORT = 5,
        MEDIUM = 10,
        LONG = 15
    }
    
    public class Level
    {
        public int LevelIndex;
        public LevelLength LevelLength;

        public Level(int index, LevelLength levelLength)
        {
            LevelIndex = index;
            LevelLength = levelLength;
        }
    }
}
