//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp2.AppDate
{
    using System;
    using System.Collections.Generic;
    
    public partial class RecipeIngredients
    {
        public int RecipeingredientID { get; set; }
        public int RecipeID { get; set; }
        public int IngredientID { get; set; }
        public int Quantity { get; set; }
    
        public virtual Ingredients Ingredients { get; set; }
        public virtual Recipes Recipes { get; set; }
    }
}
