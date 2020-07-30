using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTalDrawSystem.SistemaDibujado;
using UTalDrawSystem.SistemaGameObject;

namespace UTalDrawSystem.MyGame
{
    public class VentanaManager : Escena
    {
        Camara camara;

        SpriteFont titulo;
        SpriteFont mensaje;
        SpriteFont accion;

        public VentanaManager(ContentManager content)
        {        
            UTGameObjectsManager.Init();

            titulo = content.Load<SpriteFont>("Titulo");
            mensaje = content.Load<SpriteFont>("Instrucciones");
            accion = content.Load<SpriteFont>("Accion");

            camara = new Camara(new Vector2(0, 0), .5f, 0);
            camara.HacerActiva();


        }

        public override void Update(GameTime gameTime)
        {
            if (Game1.INSTANCE.ActiveScene == Game1.Scene.Start)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    Game1.INSTANCE.ChangeScene(Game1.Scene.Game);
                    new Juego();
                }
            }
            

            if(Game1.INSTANCE.ActiveScene == Game1.Scene.Start || Game1.INSTANCE.ActiveScene == Game1.Scene.End)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.C))
                {
                    Game1.INSTANCE.ChangeScene(Game1.Scene.Credits);                   
                }
            }

            if(Game1.INSTANCE.ActiveScene == Game1.Scene.End || Game1.INSTANCE.ActiveScene == Game1.Scene.Credits)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.R))
                {
                    Game1.INSTANCE.ChangeScene(Game1.Scene.Start);
                }
            }
        }

        public void Draw(SpriteBatch SB)
        {
            Vector2 tituloPos;
            Vector2 mensajePos;
            Vector2 accionPos;

            if (Game1.INSTANCE.ActiveScene == Game1.Scene.Start)
            {
                tituloPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 10f, SB.GraphicsDevice.Viewport.Height / 10);
                mensajePos = new Vector2(SB.GraphicsDevice.Viewport.Width / 50, SB.GraphicsDevice.Viewport.Height / 4);
                accionPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 3.8f, SB.GraphicsDevice.Viewport.Height / 1.25f);

                SB.DrawString(titulo, "Juego del auto que choca con pelotas, muros y come monedas.\n", tituloPos, Color.Black);
                SB.DrawString(mensaje, "-> Recoge todas las monedas con la menor cantidad de choques y en el menor tiempo \n" +
                    "posible.\n" +
                    "-> Cuidado las fisicas, patinaras como en una pista de hielo y chocar convierte este juego \n" +
                    "en uno de pinball.\n" +
                    "-> El juego tiene mas glitchs que codigo, pero esta hecho con amor.\n" +
                    "->Si por casualidades de la vida sales disparado fuera del mapa cual penal de Higuain, \n" +
                    "presiona 'R', pero no creo que lo necesites (ironia).\n" +
                    "\n-> Movimiento : W-A-S-D\n" +
                    "-> Frenar : X (o no presiones nada, es lo mismo).\n" +
                    "-> Diviertete ;D \n", mensajePos, Color.Black);
                SB.DrawString(accion, "Presiona 'Enter' para comenzar.\n", accionPos, Color.Black);

                accionPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 4f, SB.GraphicsDevice.Viewport.Height / 1.15f);

                SB.DrawString(accion, "Presiona 'C' para ver los creditos.\n", accionPos, Color.Black);
            }
            else if (Game1.INSTANCE.ActiveScene == Game1.Scene.End)
            {
                tituloPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 10f, SB.GraphicsDevice.Viewport.Height / 10);
                mensajePos = new Vector2(SB.GraphicsDevice.Viewport.Width / 3.4f, SB.GraphicsDevice.Viewport.Height / 2.5f);
                accionPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 6f, SB.GraphicsDevice.Viewport.Height / 1.25f);

                SB.DrawString(titulo, "Juego del auto que choca con pelotas, muros y come monedas.\n", tituloPos, Color.Black);
                SB.DrawString(mensaje, "Numero de Colisiones --> " + Game1.INSTANCE.choques + "\n" +
                    "Tiempo Total --> " + Math.Round(Game1.INSTANCE.tiempo, 2) + " Segundos\n", mensajePos, Color.Black);
                SB.DrawString(accion, "Presiona 'R' para volver a la pantalla incial.\n", accionPos, Color.Black);

                accionPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 4f, SB.GraphicsDevice.Viewport.Height / 1.15f);

                SB.DrawString(accion, "Presiona 'C' para ver los creditos.\n", accionPos, Color.Black);
            }
            else if (Game1.INSTANCE.ActiveScene == Game1.Scene.Credits)
            {
                tituloPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 10f, SB.GraphicsDevice.Viewport.Height / 10);
                mensajePos = new Vector2(SB.GraphicsDevice.Viewport.Width / 5f, SB.GraphicsDevice.Viewport.Height / 3.5f);
                accionPos = new Vector2(SB.GraphicsDevice.Viewport.Width / 6f, SB.GraphicsDevice.Viewport.Height / 1.25f);

                SB.DrawString(titulo, "Juego del auto que choca con pelotas, muros y come monedas.\n", tituloPos, Color.Black);
                SB.DrawString(mensaje, "Grupo : 2.\n" +
                    "Integrantes : \n" +
                    "-> Kevin Ignacio Silva Kendall.\n" +
                    "-> Joaquin Rodrigo Ugarte Torres.\n" +
                    "Motor Utilizado : UTalPhysicsAndDrawSystem.\n" +
                    "Creador : Sven Von Brand.\n", mensajePos, Color.Black);
                SB.DrawString(accion, "Presiona 'R' para volver a la pantalla incial.\n", accionPos, Color.Black);
            }
         
        }
    }
}
