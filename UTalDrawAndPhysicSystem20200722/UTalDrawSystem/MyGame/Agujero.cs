using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using UTalDrawSystem.SistemaGameObject;

namespace UTalDrawSystem.MyGame
{
    class Agujero : UTGameObject
    {
        public Agujero(string imagen, Vector2 pos, float escala, FF_form forma, bool isStatic = false) : base(imagen, pos, escala, forma, isStatic)
        {
            objetoFisico.isTrigger = true;

            objetoFisico.agregarFFCirculo(25f, new Vector2(1,1));

        
                 
        }
        public void Colisiona(UTGameObject objeto_1, UTGameObject objeto_2)
        {
            UTGameObject obj1 = objeto_1 as UTGameObject;


            if (objeto_2.objetoFisico.Colisiona(objeto_1.objetoFisico))
            {
                objeto_1.Destroy();
            }
        }
        public override void OnCollision(UTGameObject other)
        {
            Coleccionable col = other as Coleccionable;
            Pelota ball = other as Pelota;

            

            if (col != null)
            {
                col.Destroy();                

                //Console.WriteLine(puntaje);
            }

            if (ball != null )
            {
               
                ball.Destroy();
                //objetoFisico.pos = respawnPos;
            }

        }
    }
}
