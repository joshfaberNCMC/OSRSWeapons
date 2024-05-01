using System.Text.RegularExpressions;

namespace OSRSWeapons.Utilities
{
    public static class ValidationUtility
    {
        /// <summary>
        /// Validates the provided URL.
        /// </summary>
        /// <param name="url">The URL to validate.</param>
        /// <returns>True if the URL is valid; otherwise, false.</returns>
        public static bool IsValidURL(string? url)
        {
            if (url == null)
            {
                // If URL is null, it's considered valid as it's optional
                return true;
            }
            // Regular expression pattern to match a fully qualified domain name (FQDN)
            string pattern = @"^(https?://)?([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}(\/\S*)?$";

            // Create a regex object with the pattern
            Regex regex = new(pattern);

            // Use reg.IsMatch to check if the URL matches the pattern
            return regex.IsMatch(url);
        }
    }
}