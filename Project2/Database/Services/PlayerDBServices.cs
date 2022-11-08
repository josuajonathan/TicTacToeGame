using Database.Models;

namespace Database.Services
{
    public class PlayerDBServices
    {
        static List<PlayerDB> Player { get; }
        static PlayerDBServices()
        {
            Player = new List<PlayerDB>
            {
            new PlayerDB { id = 1, score = 0},
            new PlayerDB { id = 2, score = 0}
            };
        }

        public static List<PlayerDB> GetAll() => Player;
        public static PlayerDB? Get(int id) => Player.FirstOrDefault(p => p.id == id);

        public static void Update(PlayerDB db)
        {
            var index = Player.FindIndex(p => p.id == db.id);
            if (index == -1)
                return;

            Player[index] = db;
        }
    }
}