using System;
using System.Collections.Generic;

namespace TogglData.entities
{
    public partial class OnboardingStates
    {
        public long LocalId { get; set; }
        public long UserId { get; set; }
        public long? CreatedAt { get; set; }
        public long OpenTimelineTabCount { get; set; }
        public long EditTimelineTabCount { get; set; }
        public long IsUseTimelineRecord { get; set; }
        public long IsUseManualMode { get; set; }
        public long IsPresentNewUserOnboarding { get; set; }
        public long IsPresentOldUserOnboarding { get; set; }
        public long IsPresentNewUserSecondTimeOnboarding { get; set; }
        public long IsPresentOldUserSecondTimeOnboarding { get; set; }
        public long IsPresentManualModeOnboarding { get; set; }
        public long IsPresentTimelineTabOnboarding { get; set; }
        public long IsPresentEditTimeentryOnboarding { get; set; }
        public long IsPresentTimelineTimeentryOnboarding { get; set; }
        public long IsPresentTimelineViewOnboarding { get; set; }
        public long IsPresentTimelineActivityOnboarding { get; set; }
        public long IsPresentRecodeActivityOnboarding { get; set; }

        public virtual Users User { get; set; }
    }
}
