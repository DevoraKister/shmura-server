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
    
    public partial class Question
    {
        public int QueId { get; set; }
        public Nullable<int> QueUserId { get; set; }
        public string Question1 { get; set; }
        public string Answer { get; set; }
        public Nullable<int> RavId { get; set; }
        public Nullable<int> QueTopicId { get; set; }
    
        public virtual Rav Rav { get; set; }
        public virtual TopicQuestion TopicQuestion { get; set; }
        public virtual User User { get; set; }
    }
}
