using System;
using Topelab.RegisterActivity.Domain.Base;
using Topelab.RegisterActivity.Domain.Interfaces;
using Topelab.RegisterActivity.Domain.Dtos;

namespace Topelab.RegisterActivity.Domain.Entities
{
    /// <summary>
    /// Implementation for Winlog
    /// </summary>
    public partial class Winlog : BaseModel<IWinlog>
    {
        /// <summary>
        /// Set function that will be called to test if LocalId can change its value
        /// </summary>
        /// <param name="canChange">new can change function</param>
        /// <param name="joinRelation">relation with previous functions</param>
        public static void WhenLocalIdCanChange(Func<IWinlog, int, bool> canChange, JoinRelationType joinRelation = JoinRelationType.Replace)
            => whenLocalIdCanChange = GetJoinedFunc(whenLocalIdCanChange, canChange, joinRelation);

        /// <summary>
        /// Set action that will be called when LocalId has changed its value
        /// </summary>
        /// <param name="changed">new changed action</param>
        /// <param name="joinRelation">relation with previous actions</param>
        public static void WhenLocalIdChanged(Action<IWinlog> changed, JoinRelationType joinRelation = JoinRelationType.Replace)
            => whenLocalIdChanged = GetJoinedAction(whenLocalIdChanged, changed, joinRelation);

        /// <summary>
        /// Set function that will be called to test if HashCode can change its value
        /// </summary>
        /// <param name="canChange">new can change function</param>
        /// <param name="joinRelation">relation with previous functions</param>
        public static void WhenHashCodeCanChange(Func<IWinlog, int, bool> canChange, JoinRelationType joinRelation = JoinRelationType.Replace)
            => whenHashCodeCanChange = GetJoinedFunc(whenHashCodeCanChange, canChange, joinRelation);

        /// <summary>
        /// Set action that will be called when HashCode has changed its value
        /// </summary>
        /// <param name="changed">new changed action</param>
        /// <param name="joinRelation">relation with previous actions</param>
        public static void WhenHashCodeChanged(Action<IWinlog> changed, JoinRelationType joinRelation = JoinRelationType.Replace)
            => whenHashCodeChanged = GetJoinedAction(whenHashCodeChanged, changed, joinRelation);

        /// <summary>
        /// Set function that will be called to test if Program can change its value
        /// </summary>
        /// <param name="canChange">new can change function</param>
        /// <param name="joinRelation">relation with previous functions</param>
        public static void WhenProgramCanChange(Func<IWinlog, string, bool> canChange, JoinRelationType joinRelation = JoinRelationType.Replace)
            => whenProgramCanChange = GetJoinedFunc(whenProgramCanChange, canChange, joinRelation);

        /// <summary>
        /// Set action that will be called when Program has changed its value
        /// </summary>
        /// <param name="changed">new changed action</param>
        /// <param name="joinRelation">relation with previous actions</param>
        public static void WhenProgramChanged(Action<IWinlog> changed, JoinRelationType joinRelation = JoinRelationType.Replace)
            => whenProgramChanged = GetJoinedAction(whenProgramChanged, changed, joinRelation);

        /// <summary>
        /// Set function that will be called to test if Filename can change its value
        /// </summary>
        /// <param name="canChange">new can change function</param>
        /// <param name="joinRelation">relation with previous functions</param>
        public static void WhenFilenameCanChange(Func<IWinlog, string, bool> canChange, JoinRelationType joinRelation = JoinRelationType.Replace)
            => whenFilenameCanChange = GetJoinedFunc(whenFilenameCanChange, canChange, joinRelation);

        /// <summary>
        /// Set action that will be called when Filename has changed its value
        /// </summary>
        /// <param name="changed">new changed action</param>
        /// <param name="joinRelation">relation with previous actions</param>
        public static void WhenFilenameChanged(Action<IWinlog> changed, JoinRelationType joinRelation = JoinRelationType.Replace)
            => whenFilenameChanged = GetJoinedAction(whenFilenameChanged, changed, joinRelation);

        /// <summary>
        /// Set function that will be called to test if Title can change its value
        /// </summary>
        /// <param name="canChange">new can change function</param>
        /// <param name="joinRelation">relation with previous functions</param>
        public static void WhenTitleCanChange(Func<IWinlog, string, bool> canChange, JoinRelationType joinRelation = JoinRelationType.Replace)
            => whenTitleCanChange = GetJoinedFunc(whenTitleCanChange, canChange, joinRelation);

        /// <summary>
        /// Set action that will be called when Title has changed its value
        /// </summary>
        /// <param name="changed">new changed action</param>
        /// <param name="joinRelation">relation with previous actions</param>
        public static void WhenTitleChanged(Action<IWinlog> changed, JoinRelationType joinRelation = JoinRelationType.Replace)
            => whenTitleChanged = GetJoinedAction(whenTitleChanged, changed, joinRelation);

        /// <summary>
        /// Set function that will be called to test if StartTime can change its value
        /// </summary>
        /// <param name="canChange">new can change function</param>
        /// <param name="joinRelation">relation with previous functions</param>
        public static void WhenStartTimeCanChange(Func<IWinlog, string, bool> canChange, JoinRelationType joinRelation = JoinRelationType.Replace)
            => whenStartTimeCanChange = GetJoinedFunc(whenStartTimeCanChange, canChange, joinRelation);

        /// <summary>
        /// Set action that will be called when StartTime has changed its value
        /// </summary>
        /// <param name="changed">new changed action</param>
        /// <param name="joinRelation">relation with previous actions</param>
        public static void WhenStartTimeChanged(Action<IWinlog> changed, JoinRelationType joinRelation = JoinRelationType.Replace)
            => whenStartTimeChanged = GetJoinedAction(whenStartTimeChanged, changed, joinRelation);

        /// <summary>
        /// Set function that will be called to test if EndTime can change its value
        /// </summary>
        /// <param name="canChange">new can change function</param>
        /// <param name="joinRelation">relation with previous functions</param>
        public static void WhenEndTimeCanChange(Func<IWinlog, string, bool> canChange, JoinRelationType joinRelation = JoinRelationType.Replace)
            => whenEndTimeCanChange = GetJoinedFunc(whenEndTimeCanChange, canChange, joinRelation);

        /// <summary>
        /// Set action that will be called when EndTime has changed its value
        /// </summary>
        /// <param name="changed">new changed action</param>
        /// <param name="joinRelation">relation with previous actions</param>
        public static void WhenEndTimeChanged(Action<IWinlog> changed, JoinRelationType joinRelation = JoinRelationType.Replace)
            => whenEndTimeChanged = GetJoinedAction(whenEndTimeChanged, changed, joinRelation);

        /// <summary>
        /// Set function that will be called to test if TotalTime can change its value
        /// </summary>
        /// <param name="canChange">new can change function</param>
        /// <param name="joinRelation">relation with previous functions</param>
        public static void WhenTotalTimeCanChange(Func<IWinlog, int, bool> canChange, JoinRelationType joinRelation = JoinRelationType.Replace)
            => whenTotalTimeCanChange = GetJoinedFunc(whenTotalTimeCanChange, canChange, joinRelation);

        /// <summary>
        /// Set action that will be called when TotalTime has changed its value
        /// </summary>
        /// <param name="changed">new changed action</param>
        /// <param name="joinRelation">relation with previous actions</param>
        public static void WhenTotalTimeChanged(Action<IWinlog> changed, JoinRelationType joinRelation = JoinRelationType.Replace)
            => whenTotalTimeChanged = GetJoinedAction(whenTotalTimeChanged, changed, joinRelation);

        /// <summary>
        /// Set function that will be called to test if Exported can change its value
        /// </summary>
        /// <param name="canChange">new can change function</param>
        /// <param name="joinRelation">relation with previous functions</param>
        public static void WhenExportedCanChange(Func<IWinlog, int?, bool> canChange, JoinRelationType joinRelation = JoinRelationType.Replace)
            => whenExportedCanChange = GetJoinedFunc(whenExportedCanChange, canChange, joinRelation);

        /// <summary>
        /// Set action that will be called when Exported has changed its value
        /// </summary>
        /// <param name="changed">new changed action</param>
        /// <param name="joinRelation">relation with previous actions</param>
        public static void WhenExportedChanged(Action<IWinlog> changed, JoinRelationType joinRelation = JoinRelationType.Replace)
            => whenExportedChanged = GetJoinedAction(whenExportedChanged, changed, joinRelation);

        private static Func<IWinlog, int, bool> whenLocalIdCanChange;
        private static Action<IWinlog> whenLocalIdChanged;
        private void OnLocalIdChanged(IWinlog entity)
        {
            OnLocalIdChanged();
            whenLocalIdChanged?.Invoke(entity);
        }

        private static Func<IWinlog, int, bool> whenHashCodeCanChange;
        private static Action<IWinlog> whenHashCodeChanged;
        private void OnHashCodeChanged(IWinlog entity)
        {
            OnHashCodeChanged();
            whenHashCodeChanged?.Invoke(entity);
        }

        private static Func<IWinlog, string, bool> whenProgramCanChange;
        private static Action<IWinlog> whenProgramChanged;
        private void OnProgramChanged(IWinlog entity)
        {
            OnProgramChanged();
            whenProgramChanged?.Invoke(entity);
        }

        private static Func<IWinlog, string, bool> whenFilenameCanChange;
        private static Action<IWinlog> whenFilenameChanged;
        private void OnFilenameChanged(IWinlog entity)
        {
            OnFilenameChanged();
            whenFilenameChanged?.Invoke(entity);
        }

        private static Func<IWinlog, string, bool> whenTitleCanChange;
        private static Action<IWinlog> whenTitleChanged;
        private void OnTitleChanged(IWinlog entity)
        {
            OnTitleChanged();
            whenTitleChanged?.Invoke(entity);
        }

        private static Func<IWinlog, string, bool> whenStartTimeCanChange;
        private static Action<IWinlog> whenStartTimeChanged;
        private void OnStartTimeChanged(IWinlog entity)
        {
            OnStartTimeChanged();
            whenStartTimeChanged?.Invoke(entity);
        }

        private static Func<IWinlog, string, bool> whenEndTimeCanChange;
        private static Action<IWinlog> whenEndTimeChanged;
        private void OnEndTimeChanged(IWinlog entity)
        {
            OnEndTimeChanged();
            whenEndTimeChanged?.Invoke(entity);
        }

        private static Func<IWinlog, int, bool> whenTotalTimeCanChange;
        private static Action<IWinlog> whenTotalTimeChanged;
        private void OnTotalTimeChanged(IWinlog entity)
        {
            OnTotalTimeChanged();
            whenTotalTimeChanged?.Invoke(entity);
        }

        private static Func<IWinlog, int?, bool> whenExportedCanChange;
        private static Action<IWinlog> whenExportedChanged;
        private void OnExportedChanged(IWinlog entity)
        {
            OnExportedChanged();
            whenExportedChanged?.Invoke(entity);
        }

    }
}
