//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPFTest
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class person
    {
        public int id_person { get; set; }
        public string person_name { get; set; }
        public int id_city { get; set; }
    
        public virtual city city { get; set; }
    }
}
