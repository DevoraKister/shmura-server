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
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.PutInJob = new HashSet<PutInJob>();
            this.Question = new HashSet<Question>();
            this.Recomend = new HashSet<Recomend>();
            this.Request = new HashSet<Request>();
            this.Sign = new HashSet<Sign>();
        }
    
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserTel { get; set; }
        public string UserMail { get; set; }
        public Nullable<int> UserCityId { get; set; }
        public Nullable<int> UserSubId { get; set; }
        public Nullable<bool> UserIsChizuk { get; set; }
        public Nullable<bool> UserIsUpdate { get; set; }
        public Nullable<int> UserPartId { get; set; }
        public string UserPassword { get; set; }
        public Nullable<bool> UserIsSmartAgent { get; set; }
        public Nullable<int> UserSmartAgentTime { get; set; }
    
        public virtual City City { get; set; }
        public virtual Part Part { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PutInJob> PutInJob { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Question { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recomend> Recomend { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Request { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sign> Sign { get; set; }
        public virtual SubjectJob SubjectJob { get; set; }
    }
}
