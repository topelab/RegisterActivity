using System;
using System.Collections.Generic;

namespace TogglData.entities
{
    public partial class TimeEntries
    {
        public long LocalId { get; set; }
        public long? Id { get; set; }
        public long Uid { get; set; }
        public string Description { get; set; }
        public long Wid { get; set; }
        public string Guid { get; set; }
        public long? Pid { get; set; }
        public long? Tid { get; set; }
        public long Billable { get; set; }
        public long Duronly { get; set; }
        public long? UiModifiedAt { get; set; }
        public long Start { get; set; }
        public long? Stop { get; set; }
        public long Duration { get; set; }
        public string Tags { get; set; }
        public string CreatedWith { get; set; }
        public long? DeletedAt { get; set; }
        public long? UpdatedAt { get; set; }
        public string ProjectGuid { get; set; }
        public string ValidationError { get; set; }
        public long? PreviousPid { get; set; }
        public long? PreviousProjectGuid { get; set; }
        public long? PreviousTid { get; set; }
        public long? PreviousBillable { get; set; }
        public long? PreviousStart { get; set; }
        public long? PreviousStop { get; set; }
        public long? PreviousDuration { get; set; }
        public string PreviousDescription { get; set; }
        public string PreviousCreatedWith { get; set; }
        public string PreviousTags { get; set; }

        public virtual Users U { get; set; }
    }
}
