using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTalDrawSystem.SistemaGameObject;

namespace UTalDrawSystem.MyGame
{
    class Pelota : UTGameObject
    {
        public bool hitByCar;

        public Pelota(string imagen, Vector2 pos, float escala, FF_form forma, bool isStatic = false, bool isSuperior = true) : base(imagen, pos, escala, forma, isStatic, isSuperior = true)
        {
            hitByCar = false;

        }
        public override void OnCollision(UTGameObject other)
        {
            Coleccionable col = other as Coleccionable;
            Agujero obs = other as Agujero;
            Pelota ball = other as Pelota;

            if (ball != null)
            {
                if (ball.hitByCar == true)
                {
                    hitByCar = true;
                }
            }
        }

    }
}
