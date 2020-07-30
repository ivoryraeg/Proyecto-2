using Microsoft.Xna.Framework;
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
    public class Escena2 : Escena
    {
        public Escena2()
        {
            UTGameObjectsManager.Init();
            new Gato("Auto", new Vector2(300, 300), 1, UTGameObject.FF_form.Circulo);
            //new UTGameObject("meow_cookie", new Vector2(700, 500), 1, UTGameObject.FF_form.Circulo);
            new UTGameObject("Muro", new Vector2(1000, 500), 1, UTGameObject.FF_form.Rectangulo, true);
            //new UTGameObject("Muro", new Vector2(500, 800), 1, UTGameObject.FF_form.Rectangulo, true);
            new UTGameObject("Muro", new Vector2(500, 500), 1, UTGameObject.FF_form.Rectangulo, true);
        }
        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D1))
            {
                new EscenaInicial();
            }
        }
    }
}
