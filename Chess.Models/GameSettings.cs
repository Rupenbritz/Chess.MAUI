namespace Chess.Models
{
    public class GameSettings
    {
        public int X { get; set; }
        public int Y { get; set; }

        public GameSettings(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static GameSettings Chess()
        {
            return new GameSettings(8, 8);
        }
    }
}