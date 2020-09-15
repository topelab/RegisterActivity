using System;
using System.Collections.Generic;

namespace TogglData.entities
{
    public partial class Clients
    {
        public long LocalId { get; set; }
        public long Id { get; set; }
        public long Uid { get; set; }
        public string Name { get; set; }
        public string Guid { get; set; }
        public long Wid { get; set; }

        public virtual Users U { get; set; }
    }
}
