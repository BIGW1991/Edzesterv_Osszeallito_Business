//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Edzesterv_Osszeallito_Business_Desktop_Client.Models.Generals
{
    using System;
    using System.Collections.Generic;
    
    public partial class DietsMeal
    {
        public System.Guid DietsMealsID { get; set; }
        public System.Guid MealID { get; set; }
        public System.Guid DietID { get; set; }
        public decimal MealGramms { get; set; }
        public System.TimeSpan Time { get; set; }
        public System.Guid UserID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> ModifyingDate { get; set; }
    
        public virtual Diet Diet { get; set; }
        public virtual Meal Meal { get; set; }
    }
}
