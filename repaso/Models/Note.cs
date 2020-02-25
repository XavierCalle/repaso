using System;
using System.Collections.Generic;

namespace repaso.Models
{
    public partial class Note
    {
        public int Id { get; set; }
        public string Nota { get; set; }
        public int? Alumno { get; set; }

        public virtual Student AlumnoNavigation { get; set; }
    }
}
