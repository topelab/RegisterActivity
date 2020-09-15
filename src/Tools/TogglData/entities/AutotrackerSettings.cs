using System;
using System.Collections.Generic;

namespace TogglData.entities
{
    public partial class AutotrackerSettings
    {
        public long LocalId { get; set; }
        public long Uid { get; set; }
        public string Term { get; set; }
        public long Pid { get; set; }
        public long? Tid { get; set; }

        public virtual Users U { get; set; }
    }
}
