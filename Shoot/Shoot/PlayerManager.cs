using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoot
{
    class PlayerManager
    {
        private Dictionary<PlayerIndex, Player> players;

        private InGame game;
        private ContentLoader loader;

        public void Initialize(InGame g, ContentLoader Loader)
        {
            game = g;
            loader = Loader;

            players = new Dictionary<PlayerIndex, Player>();

            loader.LoadAssets(AssetList.Player1);
            loader.LoadAssets(AssetList.Player2);
            loader.LoadAssets(AssetList.Player3);
            loader.LoadAssets(AssetList.Player4);
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
                    AddPlayer(i, temp);
                }
                else if (!InputManager.CheckConnection(i) && players.ContainsKey(i))
                {
                    game.Entities.Remove(players[i]);
                    players.Remove(i);
                }
            }
        }

        private void AddPlayer(PlayerIndex index, Player player)
        {
            if (!players.ContainsKey(index))
            {
                switch(index)
                {
                    case PlayerIndex.One:
                        player.AssetFile = AssetList.Player1;
                        break;
                    case PlayerIndex.Two:
                        player.AssetFile = AssetList.Player2;
                        break;
                    case PlayerIndex.Three:
                        player.AssetFile = AssetList.Player3;
                        break;
                    case PlayerIndex.Four:
                        player.AssetFile = AssetList.Player4;
                        break;
                }

                players.Add(index, player);
                player.Load();
                game.Entities.Add(player);
            }
        }
    }
}
