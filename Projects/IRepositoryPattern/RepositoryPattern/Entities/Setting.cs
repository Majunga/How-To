namespace RepositoryPattern.Entities
{
    using RepositoryPattern.Interfaces;

    /// <summary>
    /// Setting - Key Value pair
    /// </summary>
    public class Setting : IEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets setting Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets setting Value
        /// </summary>
        public string Value { get; set; }
    }
}
