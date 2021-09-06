//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        /* Para adjudicar esta responsabilidad, segui el patron expert
        Y en base a ese patron, dedcui que la clase mas adecuada para 
        calcular el cosoto total es "Recipe", ya que ella es la unica que
        comoce el cosoto de cada producto, y el costo de cada uno de los pasos
        de la rceceta.*/

        public double GetProductionCost() 
        {
            double SumatoriaInsumos = 0;
            double SumatoriaEquipamiento = 0;
            foreach (Step item in steps)
            {
                var m=item.GetType();
                SumatoriaInsumos+=item.Input.UnitCost;
                SumatoriaEquipamiento+=(item.Equipment.HourlyCost * (item.Time/60));
            }
            double SumatoriaTotal = SumatoriaEquipamiento + SumatoriaInsumos;
            return SumatoriaTotal;
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"El costo total es de {this.GetProductionCost()}");
        }
    }
}