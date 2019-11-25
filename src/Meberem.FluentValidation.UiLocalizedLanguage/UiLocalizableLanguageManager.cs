using System.Globalization;
using FluentValidation.Resources;

namespace FluentValidation.UiLocalizedLanguage
{
    public class UiLocalizableLanguageManager : ILanguageManager
    {
        private readonly Language _language;

        /// <summary>
        /// Creates a new LanguageManager with just one language, See the static <see cref="Default"/>
        /// property for the Default setup
        /// </summary>
        /// <param name="language">The Language to use</param>
        public UiLocalizableLanguageManager(Language language)
        {
            _language = language;
        }
        public string GetString(string key, CultureInfo culture = null)
        {
            return _language.GetTranslation(key) ?? string.Empty;
        }

        public bool Enabled { get; set; } = true;
        
        /// <summary>
        /// Not used in this implementation
        /// </summary>
        public CultureInfo Culture { get; set; }

        /// <summary>
        /// The Default Language with error messages in the format:
        /// <example>
        /// errorMessages.ERROR_KEY:{"JsonObject":"WithKeyProperties","OnlyIfThe":"MessageNeedsIt"}
        /// </example>
        /// </summary>
        public static UiLocalizableLanguageManager Default => new UiLocalizableLanguageManager(UiLocalizableLanguage.Default);
    }
}
