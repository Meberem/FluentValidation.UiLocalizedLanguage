using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FluentValidation.UiLocalizedLanguage
{
    public class ErrorMessages
    {
        public string Email { get; set; }
        public string GreaterThanOrEqual { get; set; }
        public string GreaterThan { get; set; }
        public string Length { get; set; }
        public string MinLength { get; set; }
        public string MaxLength { get; set; }
        public string LessThanOrEqual { get; set; }
        public string LessThan { get; set; }
        public string NotEmpty { get; set; }
        public string NotEqual { get; set; }
        public string Predicate { get; set; }
        public string Regex { get; set; }
        public string Equal { get; set; }
        public string ExactLength { get; set; }
        public string InclusiveBetween { get; set; }
        public string ExclusiveBetween { get; set; }
        public string CreditCard { get; set; }
        public string ScalePrecision { get; set; }
        public string Empty { get; set; }
        public string Enum { get; set; }
        public string SimpleLength { get; set; }
        public string SimpleMinLength { get; set; }
        public string SimpleMaxLength { get; set; }
        public string SimpleExactLength { get; set; }
        public string SimpleInclusiveBetween { get; set; }
        private static readonly Lazy<Dictionary<string, string>> DefaultFromEmbeddedJson = new Lazy<Dictionary<string, string>>(() =>
        {
            using (var stream = typeof(ErrorMessages).Assembly.GetManifestResourceStream("FluentValidation.UiLocalizedLanguage.DefaultErrorMessages.json"))
            using (var readStream = new StreamReader(stream))
            using (var reader = new JsonTextReader(readStream))
            {
                var serializer = new JsonSerializer();
                return serializer
                    .Deserialize<Dictionary<string, JObject>>(reader)
                    .ToDictionary(x => x.Key, x => JsonConvert.SerializeObject(x.Value));
            }
        });
        public static ErrorMessages Default
        {
            get
            {
                var defaults = DefaultFromEmbeddedJson.Value;
                return new ErrorMessages
                {
                    Email = defaults[nameof(Email)],
                    GreaterThanOrEqual = defaults[nameof(GreaterThanOrEqual)],
                    GreaterThan = defaults[nameof(GreaterThan)],
                    Length = defaults[nameof(Length)],
                    MinLength = defaults[nameof(MinLength)],
                    MaxLength = defaults[nameof(MaxLength)],
                    LessThanOrEqual = defaults[nameof(LessThanOrEqual)],
                    LessThan = defaults[nameof(LessThan)],
                    NotEmpty = defaults[nameof(NotEmpty)],
                    NotEqual = defaults[nameof(NotEqual)],
                    Predicate = defaults[nameof(Predicate)],
                    Regex = defaults[nameof(Regex)],
                    Equal = defaults[nameof(Equal)],
                    ExactLength = defaults[nameof(ExactLength)],
                    InclusiveBetween = defaults[nameof(InclusiveBetween)],
                    ExclusiveBetween = defaults[nameof(ExclusiveBetween)],
                    CreditCard = defaults[nameof(CreditCard)],
                    ScalePrecision = defaults[nameof(ScalePrecision)],
                    Empty = defaults[nameof(Empty)],
                    Enum = defaults[nameof(Enum)],
                    SimpleLength = defaults[nameof(SimpleLength)],
                    SimpleMinLength = defaults[nameof(SimpleMinLength)],
                    SimpleMaxLength = defaults[nameof(SimpleMaxLength)],
                    SimpleExactLength = defaults[nameof(SimpleExactLength)],
                    SimpleInclusiveBetween = defaults[nameof(SimpleInclusiveBetween)],
                };
            }
        }
    }
}