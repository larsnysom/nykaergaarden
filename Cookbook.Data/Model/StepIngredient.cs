using System;
using System.Runtime.Serialization;
using Nykaergaarden.Cookbook.DomainModel.Enums;

namespace Nykaergaarden.Cookbook.DomainModel.Model
{    
    public class StepIngredient // ValueObject
    {
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public MeasureUnit Measure { get; set; }

        private StepIngredient() { }

        public static StepIngredient Create(string ingredientName, decimal quantity, MeasureUnit measure)
        {
            return new StepIngredient
            {
                Name = ingredientName,
                Measure = measure,
                Quantity = quantity
            };
        }
    }
}