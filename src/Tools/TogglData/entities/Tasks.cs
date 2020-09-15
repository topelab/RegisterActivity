using System;
using System.Collections.Generic;

namespace TogglData.entities
{
    public partial class Tasks
    {
        public long LocalId { get; set; }
        public long Id { get; set; }
        public long Uid { get; set; }
        public string Name { get; set; }
        public long Wid { get; set; }
        public long? Pid { get; set; }
        public long Active { get; set; }

        public virtual Users U { get; set; }
    }
}
