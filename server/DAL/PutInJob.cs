//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class PutInJob
    {
        public int PutId { get; set; }
        public Nullable<int> PutJobId { get; set; }
        public Nullable<int> PutUserId { get; set; }
        public Nullable<System.DateTime> PutDate { get; set; }
    
        public virtual Job Job { get; set; }
        public virtual User User { get; set; }
    }
}
