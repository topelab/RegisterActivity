using System;
using System.Collections.Generic;

namespace TogglData.entities
{
    public partial class Users
    {
        public Users()
        {
            AutotrackerSettings = new HashSet<AutotrackerSettings>();
            Clients = new HashSet<Clients>();
            OnboardingStates = new HashSet<OnboardingStates>();
            Projects = new HashSet<Projects>();
            Sessions = new HashSet<Sessions>();
            Tags = new HashSet<Tags>();
            Tasks = new HashSet<Tasks>();
            TimeEntries = new HashSet<TimeEntries>();
            TimelineEvents = new HashSet<TimelineEvents>();
            Workspaces = new HashSet<Workspaces>();
        }

        public long LocalId { get; set; }
        public long Id { get; set; }
        public long? DefaultWid { get; set; }
        public long? Since { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public long RecordTimeline { get; set; }
        public long StoreStartAndStopTime { get; set; }
        public string TimeofdayFormat { get; set; }
        public string DurationFormat { get; set; }
        public string OfflineData { get; set; }
        public long? DefaultPid { get; set; }
        public long? DefaultTid { get; set; }
        public long CollapseEntries { get; set; }

        public virtual ICollection<AutotrackerSettings> AutotrackerSettings { get; set; }
        public virtual ICollection<Clients> Clients { get; set; }
        public virtual ICollection<OnboardingStates> OnboardingStates { get; set; }
        public virtual ICollection<Projects> Projects { get; set; }
        public virtual ICollection<Sessions> Sessions { get; set; }
        public virtual ICollection<Tags> Tags { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }
        public virtual ICollection<TimeEntries> TimeEntries { get; set; }
        public virtual ICollection<TimelineEvents> TimelineEvents { get; set; }
        public virtual ICollection<Workspaces> Workspaces { get; set; }
    }
}
