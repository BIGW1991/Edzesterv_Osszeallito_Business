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
    
    public partial class UnitAmountsMasterData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UnitAmountsMasterData()
        {
            this.TrainingsTrainingPlans = new HashSet<TrainingsTrainingPlan>();
        }
    
        public System.Guid ID { get; set; }
        public string Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainingsTrainingPlan> TrainingsTrainingPlans { get; set; }
    }
}
