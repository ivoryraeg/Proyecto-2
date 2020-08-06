using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using UTalDrawSystem.SistemaGameObject;

namespace UTalDrawSystem.MyGame
{
    public class Automovil : UTGameObject
    {
        Texture2D energyShield;
        UTGameObject shield;

        public int vidas;
        public int puntaje = 0;

        public bool invulnerable;
        public float tiempoInvulnerable;

        Vector2 respawnPos;

        public Automovil(ContentManager content, string imagen, Vector2 pos, float escala, FF_form forma, bool isStatic = false, bool isSuperior = true) : base(imagen, pos, escala, forma, isStatic, isSuperior)
        {
            energyShield = content.Load<Texture2D>("energyShield");

            vidas = 5;
            respawnPos = pos;

            invulnerable = false;
            tiempoInvulnerable = 0;
        }
        public override void Update(GameTime gameTime)
        {
            float vel;
            // 1.57 90 grados 
            // 3.14 180 grados 
            // 4.71 240 grados 
            // 6.28 360 grados 
            if (Keyboard.GetState().IsKeyDown(Keys.X))
            {
                vel = 0;
            }
            else
            {
                vel = 100;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                //Console.WriteLine("D");

                objetoFisico.dibujable.rot = 1.57f;
                objetoFisico.AddVelocity(new Vector2((float)gameTime.ElapsedGameTime.TotalSeconds * vel, 0));
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                objetoFisico.dibujable.rot = 4.71f;
                objetoFisico.AddVelocity(new Vector2(-(float)gameTime.ElapsedGameTime.TotalSeconds * vel, 0));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                objetoFisico.dibujable.rot = 0f;
                objetoFisico.AddVelocity(new Vector2(0, -(float)gameTime.ElapsedGameTime.TotalSeconds * vel));
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                objetoFisico.dibujable.rot = 3.14f;
                objetoFisico.AddVelocity(new Vector2(0, (float)gameTime.ElapsedGameTime.TotalSeconds * vel));
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D) && Keyboard.GetState().IsKeyDown(Keys.W))
            {
                objetoFisico.dibujable.rot = 1.57f / 2f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.W))
            {
                objetoFisico.dibujable.rot = -1.57f / 2f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) && Keyboard.GetState().IsKeyDown(Keys.S))
            {
                objetoFisico.dibujable.rot = 1.57f / 2f + 1.57f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.S))
            {
                objetoFisico.dibujable.rot = -1.57f / 2f - 1.57f;
            }

            if (invulnerable)
            {
                shield.objetoFisico.pos = objetoFisico.pos;

                if (tiempoInvulnerable > 3)
                {
                    shield.Destroy();
                    tiempoInvulnerable = 0;
                    invulnerable = false;
                    objetoFisico.isTrigger = false;
                }
                else
                {
                    tiempoInvulnerable += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
        }

        public override void OnCollision(UTGameObject other)
        {
            Coleccionable col = other as Coleccionable; 
            Agujero obs = other as Agujero;

            if (col != null)
            {
                col.Destroy();
                puntaje++;

                //Console.WriteLine(puntaje);
            }
            if (obs != null)
            {
                if (!invulnerable)
                {
                    invulnerable = true;
                    objetoFisico.pos = Respawn();
                }
            }
        }

        public Vector2 Respawn()
        {
            vidas--;
            respawnPos.X = Game1.INSTANCE.ventanaJuego.camara.pos.X + Game1.INSTANCE.GraphicsDevice.Viewport.Width/2f;
            respawnPos.Y = Game1.INSTANCE.ventanaJuego.camara.pos.Y + Game1.INSTANCE.GraphicsDevice.Viewport.Height;

            objetoFisico.isTrigger = true;
            shield = new UTGameObject("energyShield", objetoFisico.pos, 0.2f, FF_form.Circulo, false, true);
            shield.objetoFisico.isTrigger = true;

            return respawnPos;
        }
    }
}
