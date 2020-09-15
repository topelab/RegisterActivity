using System;
using System.Collections.Generic;

namespace TogglData.entities
{
    public partial class Workspaces
    {
        public long LocalId { get; set; }
        public long Id { get; set; }
        public long Uid { get; set; }
        public string Name { get; set; }
        public long? Premium { get; set; }
        public long OnlyAdminsMayCreateProjects { get; set; }
        public long Admin { get; set; }
        public long IsBusiness { get; set; }
        public long LockedTime { get; set; }
        public long ProjectsBillableByDefault { get; set; }

        public virtual Users U { get; set; }
    }
}
