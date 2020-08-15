using System;
using System.Collections.Generic;
using System.Text;

namespace DL.NetCore.EmptySolution.Data.EFCore.Entities
{
    public class WorkPackageEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }

        public int? ParentId { get; set; }
        public WorkPackageEntity Parent { get; set; }

        public ICollection<WorkPackageEntity> Children { get; set; }
    }
}
