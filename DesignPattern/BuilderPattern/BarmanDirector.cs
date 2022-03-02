using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BuilderPattern
{
    public class BarmanDirector
    {
        private IBuilder _builder;

        public BarmanDirector(IBuilder builder)
        {
            _builder = builder;
        }

        public IBuilder Builder
        {
            set
            {
                _builder = value;
            }
        }

        public void PrepareMargarita()
        {
            _builder.Reset();
            _builder.SetAlcohol(9);
            _builder.SetWater(30);
            _builder.AddIngredients("2 limones");
            _builder.AddIngredients("Pizca de sal");
            _builder.AddIngredients("1/2 taza de tequila");
            _builder.AddIngredients("3/4 taza de licor de naranja");
            _builder.AddIngredients("4 cubos de hielo");
            _builder.Mix();
            _builder.Rest(1000);
        }
        
        public void PreparePinaColada()
        {
            _builder.Reset();
            _builder.SetAlcohol(20);
            _builder.SetWater(10);
            _builder.SetMilk(500);
            _builder.AddIngredients("1/2 taza de ron");
            _builder.AddIngredients("1/2 taza de crema de coco");
            _builder.AddIngredients("3/4 taza de jugo de piña");
            _builder.Mix();
            _builder.Rest(2000);
        }
    }
}
