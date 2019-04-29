using MySchoolLibrary2018.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models
{
    public class TypeInspection
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Inspection> Inspections { get; set; }

        


        /// <summary>
        /// Converti le Model en ViewModel.
        /// </summary>
        /// <returns></returns>
        public TypeInspectionViewModel ToViewModel()
        {
            var model = new TypeInspectionViewModel
            {
                Id = Id,
                Description = Description,
                Inspections = Inspections
            };

            return model;
        }
    }
}
