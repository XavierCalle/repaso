using System;
using System.Collections.Generic;

namespace repaso.Models
{
    public partial class Teacher
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public int? Materia { get; set; }

        public virtual Materia MateriaNavigation { get; set; }
    }
}
