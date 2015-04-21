using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WindowsGame1.GameComponents;

namespace WindowsGame1.BadGuys
{
    public class SnowEngine
    {
        Random rnd;
        public Vector2 emitterLocation;
        List<Particle> listParticle;
        List<Texture2D> listTexture;

        public SnowEngine(List<Texture2D> listTexture,Vector2 location)
        {
            emitterLocation = location;
            this.listTexture = listTexture;
            this.listParticle = new List<Particle>();
            rnd = new Random();
        }

        private Particle GenerateNewParticle()
        {
            Texture2D texture = listTexture[rnd.Next(listTexture.Count)];
            Vector2 position = emitterLocation;
            //Vector2 velocity = new Vector2(
            //1f * (float)(rnd.NextDouble() * 2 - 1),
            //1f * (float)(rnd.NextDouble() * 2 - 1));

            Vector2 velocity = new Vector2(
            1f * (float)(rnd.NextDouble() * 2 - 1),
            1f * (float)(rnd.NextDouble() * 2 - 1));

            float angle = 0;
            float angularVelocity =0.1f * (float)(rnd.NextDouble() * 2- 1);
            Color color = new Color(255, 255, 255);
                    //(float)rnd.NextDouble(),
                    //(float)rnd.NextDouble(),
                    //(float)rnd.NextDouble());
            float size = 1f*(float)rnd.NextDouble();
            int ttl = 20 + rnd.Next(20);

            return new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl);
        }


        public void Update()
        {
            int total = 10;

            for (int i = 0; i < total; i++)
            {
                listParticle.Add(GenerateNewParticle());
            }

            for (int particle = 0; particle < listParticle.Count; particle++)
            {
                listParticle[particle].Update();
                if (listParticle[particle].TTL <= 0)
                {
                    listParticle.RemoveAt(particle);
                    particle--;
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            
            for (int index = 0; index < listParticle.Count; index++)
            {
                listParticle[index].Draw(spriteBatch);
            }
           
        }

    }
}
