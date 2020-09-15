using System;
using System.Collections.Generic;

namespace TogglData.entities
{
    public partial class Sessions
    {
        public long LocalId { get; set; }
        public string ApiToken { get; set; }
        public long Active { get; set; }
        public long? Uid { get; set; }

        public virtual Users U { get; set; }
    }
}
