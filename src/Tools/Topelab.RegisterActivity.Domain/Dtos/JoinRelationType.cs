namespace Topelab.RegisterActivity.Domain.Dtos
{
    /// <summary>
    /// Type of join for calls to actions or functions
    /// </summary>
    public enum JoinRelationType
    {
        /// <summary>
        /// Replace relation
        /// </summary>
        Replace,
        /// <summary>
        /// And relation
        /// </summary>
        And,
        /// <summary>
        /// Or relation
        /// </summary>
        Or
    }
}
