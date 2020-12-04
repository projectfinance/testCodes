//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Finance.Models
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class PurchaseDetail
    {
        [DataMember]
        public int PurchaseID { get; set; }
        [DataMember]
        public Nullable<int> ProductID { get; set; }
        [DataMember]
        public string CardID { get; set; }
        [DataMember]
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        [DataMember]
        public Nullable<int> CustomerID { get; set; }
        [DataMember]
        public Nullable<int> EmiScheme { get; set; }
        [DataMember]
        public Nullable<double> EmiPerMonth { get; set; }
        [DataMember]
        public Nullable<double> EmiPaid { get; set; }
        [DataMember]
        public Nullable<double> EmiLeft { get; set; }
    
        public virtual CardDetail CardDetail { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
