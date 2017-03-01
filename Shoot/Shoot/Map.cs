using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shoot
{
    public class Map
    {
        public List<Tile> level { get; private set; }

        private SpriteBatch spriteBatch;

        public void Initialize(SpriteBatch Batch)
        {
            level = new List<Tile>();

            spriteBatch = Batch;
        }

        public void Load()
        {
            LoadMap("Level1.txt");
            
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw()
        {
            foreach (Tile tile in level)
            {
                tile.Draw(spriteBatch);
            }
        }

        private void LoadMap(string levelToLoad)
        {
            string[] lines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, levelToLoad));

            for (int i = 0; i < lines.Length; i++)
            {
                string[] cells = lines[i].Split(',');
                
                for (int j = 0; j < cells.Length; j++)
                {
                    if (int.Parse(cells[j]) != 0)
                    {
                        Tile temp = new Tile();

                        switch (int.Parse(cells[j]))
                        {
                            case 1:
                            temp.Texture = ContentLoader.GetSprite("TempGrass");
                            break;

                            case 2:
                            temp.Texture = ContentLoader.GetSprite("TempDirt");
                            break;
                        }

                        temp.Position = new Vector2(j * temp.Texture.Width, i * temp.Texture.Height);
                        temp.Load();

                        level.Add(temp);

                        ProjectileManager.AddTargetToList(temp);
                    }
                }
            }
        }
    }
}