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
    
    public partial class Section_Student
    {
        public int SectionID { get; set; }
        public int StudentID { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual Section Section { get; set; }
    }
}
