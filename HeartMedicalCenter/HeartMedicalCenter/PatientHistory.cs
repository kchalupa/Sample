//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kchalupa.Web.HeartMedicalCenter
{
    using System;
    using System.Collections.Generic;
    
    public partial class PatientHistory
    {
        public System.Guid Id { get; set; }
        public string Conditions { get; set; }
        public string Medications { get; set; }
        public string Allergies { get; set; }
        public string Physicians { get; set; }
    
        public virtual Appointment Appointment { get; set; }
    }
}
