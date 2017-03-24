using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoot
{
    class PlayerManager
    {
        private Dictionary<PlayerIndex, Player> players;

        private InGame game;

        public void Initialize(InGame g)
        {
            game = g;

            players = new Dictionary<PlayerIndex, Player>();
        }

        public void Update()
        {
            CheckConnections();
        }

        private void CheckConnections()
        {
            for (PlayerIndex i = PlayerIndex.One; i <= PlayerIndex.Four; i++)
            {
                if (InputManager.CheckConnection(i) && !players.ContainsKey(i))
                {
                    Player temp = new Player(i);
                    players.Add(i, temp);
                    game.Entities.Add(temp);
                }
                else if (!InputManager.CheckConnection(i) && players.ContainsKey(i))
                {
                    players.Remove(i);
                    game.Entities.Remove(players[i]);
                }
            }
        }

        private void AddPlayer(PlayerIndex index, Player player)
        {
            if(!players.ContainsKey(index))
            {
                players.Add(index, player);
            }
        }
    }
}
