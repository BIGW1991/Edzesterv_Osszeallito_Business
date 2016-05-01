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
    
    public partial class Meal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Meal()
        {
            this.DietsMeals = new HashSet<DietsMeal>();
        }
    
        public System.Guid ID { get; set; }
        public string Name { get; set; }
        public decimal CaloriesPerOneHundredGramms { get; set; }
        public decimal ProteinsPerOneHundredGramms { get; set; }
        public decimal CarboHydratesPerOneHundredGramms { get; set; }
        public decimal FatsPerOneHundredGramms { get; set; }
        public System.Guid UserID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> ModifyingDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DietsMeal> DietsMeals { get; set; }
        public virtual User User { get; set; }
    }
}