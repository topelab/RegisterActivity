using System;
using System.Collections.Generic;

namespace TogglData.entities
{
    public partial class Projects
    {
        public long LocalId { get; set; }
        public long Id { get; set; }
        public long Uid { get; set; }
        public string Name { get; set; }
        public string Guid { get; set; }
        public string Color { get; set; }
        public long Wid { get; set; }
        public long? Cid { get; set; }
        public long Active { get; set; }
        public long Billable { get; set; }
        public long IsPrivate { get; set; }
        public string ClientGuid { get; set; }

        public virtual Users U { get; set; }
    }
}
