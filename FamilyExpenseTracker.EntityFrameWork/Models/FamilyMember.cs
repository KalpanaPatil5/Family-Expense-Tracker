//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FamilyExpenseTracker.EntityFrameWork.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FamilyMember
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FamilyMember()
        {
            this.FamilyExpenses = new HashSet<FamilyExpense>();
        }
    
        public int FamilyMemberId { get; set; }
        public string Name { get; set; }
        public string Cell { get; set; }
        public string Work { get; set; }
        public Nullable<int> Income { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamilyExpense> FamilyExpenses { get; set; }
    }
}
