namespace Patas.Em.Harmonia.Domain.UI
{
    /// <summary>
    /// Class to use data from appsettings.json "Settings" field
    /// </summary>
    public class ApiSettings
    {
        /// <summary>
        /// Database connection string
        /// </summary>
        public string DatabaseConnectionString { get; set; } = String.Empty;
    }
}
