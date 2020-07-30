using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTalDrawSystem.SistemaDibujado
{
    public class Escena
    {
        public List<Dibujable> dibujables { get; private set; } = new List<Dibujable>();
        public static Escena INSTANCIA;

        public Escena()
        {
            INSTANCIA = this;
        }
        public void agregarDib(Dibujable dib)
        {
            dibujables.Add(dib);
        }
        public void removerDib(Dibujable dib)
        {
            dibujables.Remove(dib);
        }
        public virtual void Update(GameTime gameTime)
        {

        }
    }
}
