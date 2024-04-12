namespace FlightManager.Models
{
    /// <summary>
    /// Represents the view model for displaying error information.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for the error.
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether the request identifier should be displayed.
        /// </summary>
        /// <remarks>
        /// This property returns true if the RequestId property is not null or empty, otherwise, it returns false.
        /// </remarks>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
