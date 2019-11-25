using FluentValidation.Resources;
using FluentValidation.Validators;

namespace FluentValidation.UiLocalizedLanguage
{
    public class UiLocalizableLanguage : Language
    {
        public override string Name => "Ui Localizable";

        /// <summary>
        /// <remarks>You probably want the <see cref="Default"/> property</remarks>
        /// Creates a Ui Localizable Language using the Error Messages defined
        /// in the <see cref="ErrorMessages"/>
        /// </summary>
        /// <param name="errorMessages">The error messages to use</param>
        public UiLocalizableLanguage(ErrorMessages errorMessages)
        {
            Translate<EmailValidator>(errorMessages.Email);
            Translate<GreaterThanOrEqualValidator>(errorMessages.GreaterThanOrEqual);
            Translate<GreaterThanValidator>(errorMessages.GreaterThan);
            Translate<LengthValidator>(errorMessages.Length);
            Translate<MinimumLengthValidator>(errorMessages.MinLength);
            Translate<MaximumLengthValidator>(errorMessages.MaxLength);
            Translate<LessThanOrEqualValidator>(errorMessages.LessThanOrEqual);
            Translate<LessThanValidator>(errorMessages.LessThan);
            Translate<NotEmptyValidator>(errorMessages.NotEmpty);
            Translate<NotEqualValidator>(errorMessages.NotEqual);
            Translate<NotNullValidator>(errorMessages.NotEmpty);
            Translate<PredicateValidator>(errorMessages.Predicate);
            Translate<AsyncPredicateValidator>(errorMessages.Predicate);
            Translate<RegularExpressionValidator>(errorMessages.Regex);
            Translate<EqualValidator>(errorMessages.Equal);
            Translate<ExactLengthValidator>(errorMessages.ExactLength);
            Translate<InclusiveBetweenValidator>(errorMessages.InclusiveBetween);
            Translate<ExclusiveBetweenValidator>(errorMessages.ExclusiveBetween);
            Translate<CreditCardValidator>(errorMessages.CreditCard);
            Translate<ScalePrecisionValidator>(errorMessages.ScalePrecision);
            Translate<EmptyValidator>(errorMessages.Empty);
            Translate<NullValidator>(errorMessages.Empty);
            Translate<EnumValidator>(errorMessages.Enum);
            // Additional fallback messages used by clientside validation integration.
            Translate("Length_Simple", errorMessages.SimpleLength);
            Translate("MinimumLength_Simple", errorMessages.SimpleMinLength);
            Translate("MaximumLength_Simple", errorMessages.SimpleMaxLength);
            Translate("ExactLength_Simple", errorMessages.SimpleExactLength);
            Translate("InclusiveBetween_Simple", errorMessages.SimpleInclusiveBetween);
        }

        public static Language Default => new UiLocalizableLanguage(ErrorMessages.Default);
    }
}