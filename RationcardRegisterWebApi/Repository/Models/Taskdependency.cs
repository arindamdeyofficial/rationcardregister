using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Taskdependency
    {
        public Guid Nexttaskid { get; set; }
        public Guid Prevtaskid { get; set; }

        public virtual Task Nexttask { get; set; }
        public virtual Task Prevtask { get; set; }
    }
}
