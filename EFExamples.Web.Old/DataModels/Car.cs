//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFExamples.Web.Old.DataModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public Nullable<int> PersonId { get; set; }
    
        public virtual Person Person { get; set; }
    }
}
