//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdditionalEducation.Data.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Section
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Section()
        {
            this.Section_Student = new HashSet<Section_Student>();
            this.Section_Teacher = new HashSet<Section_Teacher>();
        }
    
        public int ID { get; set; }
        public string Title { get; set; }
        public int CabinetID { get; set; }
        public Nullable<int> MaxCountOfVisitors { get; set; }
        public int ScheduleID { get; set; }
        public byte[] Image { get; set; }
        public Nullable<bool> isActive { get; set; }
    
        public virtual Cabinet Cabinet { get; set; }
        public virtual Schedule Schedule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Section_Student> Section_Student { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Section_Teacher> Section_Teacher { get; set; }
    }
}
