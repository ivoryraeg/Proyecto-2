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
        public Pelota(string imagen, Vector2 pos, float escala, FF_form forma, bool isStatic = false, bool isSuperior = true) : base(imagen, pos, escala, forma, isStatic, isSuperior = true)
        {

        }

    }
}
