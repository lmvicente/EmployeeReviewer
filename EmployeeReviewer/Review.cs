//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeReviewer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int EmployeeId { get; set; }
        public int ReviewerId { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string Summary { get; set; }
        public Nullable<bool> EmployeeSigned { get; set; }
        public Nullable<bool> EmployerSigned { get; set; }
        public int ReviewType { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Reviewer Reviewer { get; set; }
        public virtual ReviewType ReviewType1 { get; set; }
    }
}