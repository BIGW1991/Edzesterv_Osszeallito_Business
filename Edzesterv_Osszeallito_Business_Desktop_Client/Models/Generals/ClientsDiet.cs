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
    
    public partial class ClientsDiet
    {
        public System.Guid ClientDietID { get; set; }
        public System.Guid ClientID { get; set; }
        public System.Guid DietID { get; set; }
        public System.DateTime Start { get; set; }
        public System.DateTime End { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Diet Diet { get; set; }
    }
}
