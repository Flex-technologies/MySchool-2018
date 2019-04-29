using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models.ModelViews
{
    public class TypeInspectionViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Inspection> Inspections { get; set; }


        /// <summary>
        /// Converti ViewModel en Model.
        /// </summary>
        /// <returns></returns>
        public TypeInspection ToModel()
        {
            var model = new TypeInspection
            {
                Id = Id,
                Description = Description,
                Inspections = Inspections
               
            };

            return model;
        }
    }
}
