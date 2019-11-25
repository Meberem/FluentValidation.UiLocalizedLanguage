using Shouldly;
using Xunit;

namespace FluentValidation.UiLocalizedLanguage.Tests
{
    public class UiLocalizableLanguageTests
    {
        static UiLocalizableLanguageTests()
        {
            ValidatorOptions.LanguageManager = UiLocalizableLanguageManager.Default;
        }

        [Fact]
        public void Email_error_string_is_correct()
        {
            // Arrange
            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.StringProp).EmailAddress();

            // Act
            var result = validator.Validate(new TestDto
            {
                StringProp = "definitely not an email"
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe($@"{{""key"":""email""}}");
        }

        [Fact]
        public void GreaterThanOrEqual_to_error_string_is_correct()
        {
            // Arrange
            const int expectedNumber = 100;
            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.IntProp).GreaterThanOrEqualTo(expectedNumber);

            // Act
            var result = validator.Validate(new TestDto
            {
                IntProp = expectedNumber - 1,
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe(
                $@"{{""key"":""greaterThanOrEqual"",""comparisonValue"":""{expectedNumber}""}}");
        }

        [Fact]
        public void GreaterThan_to_error_string_is_correct()
        {
            // Arrange
            const int expectedNumber = 100;
            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.IntProp).GreaterThan(expectedNumber);

            // Act
            var result = validator.Validate(new TestDto
            {
                IntProp = expectedNumber - 1,
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe(
                $@"{{""key"":""greaterThan"",""comparisonValue"":""{expectedNumber}""}}");
        }

        [Fact]
        public void Length_error_string_is_correct()
        {
            // Arrange
            const int minLength = 2;
            const int maxLength = 5;
            const int entered = maxLength + 1;
            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.StringProp).Length(minLength, maxLength);

            // Act
            var result = validator.Validate(new TestDto
            {
                StringProp = new string('a', entered),
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe(
                $@"{{""key"":""length"",""minLength"":""{minLength}"",""maxLength"":""{maxLength}"",""entered"":""{entered}""}}");
        }

        [Fact]
        public void MinLength_error_string_is_correct()
        {
            // Arrange
            const int minLength = 5;
            const int entered = minLength - 1;
            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.StringProp).MinimumLength(minLength);

            // Act
            var result = validator.Validate(new TestDto
            {
                StringProp = new string('a', entered),
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe(
                $@"{{""key"":""minLength"",""minLength"":""{minLength}"",""entered"":""{entered}""}}");
        }

        [Fact]
        public void MaxLength_error_string_is_correct()
        {
            // Arrange
            const int maxLength = 3;
            const int entered = maxLength + 1;
            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.StringProp).MaximumLength(maxLength);

            // Act
            var result = validator.Validate(new TestDto
            {
                StringProp = new string('a', entered),
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe(
                $@"{{""key"":""maxLength"",""maxLength"":""{maxLength}"",""entered"":""{entered}""}}");
        }

        [Fact]
        public void LessThanOrEqual_error_string_is_correct()
        {
            // Arrange
            const int limit = 3;
            const int entered = limit + 1;
            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.IntProp).LessThanOrEqualTo(limit);

            // Act
            var result = validator.Validate(new TestDto
            {
                IntProp = entered
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe(
                $@"{{""key"":""lessThanOrEqual"",""comparisonValue"":""{limit}""}}");
        }

        [Fact]
        public void LessThan_error_string_is_correct()
        {
            // Arrange
            const int limit = 3;
            const int entered = limit;
            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.IntProp).LessThan(limit);

            // Act
            var result = validator.Validate(new TestDto
            {
                IntProp = entered
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe(
                $@"{{""key"":""lessThan"",""comparisonValue"":""{limit}""}}");
        }

        [Fact]
        public void NotEmpty_error_string_is_correct()
        {
            // Arrange
            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.StringProp).NotEmpty();

            // Act
            var result = validator.Validate(new TestDto
            {
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe(
                $@"{{""key"":""notEmpty""}}");
        }

        [Fact]
        public void NotNull_error_string_is_correct()
        {
            // Arrange
            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.StringProp).NotNull();

            // Act
            var result = validator.Validate(new TestDto
            {
                StringProp = null
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe(
                $@"{{""key"":""notEmpty""}}");
        }

        [Fact]
        public void NotPredicate_error_string_is_correct()
        {
            // Arrange
            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.StringProp).Must(x => false);

            // Act
            var result = validator.Validate(new TestDto
            {
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe(
                $@"{{""key"":""predicate""}}");
        }

        [Fact]
        public void Regex_error_string_is_correct()
        {
            // Arrange
            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.StringProp).Matches(@"\d+");

            // Act
            var result = validator.Validate(new TestDto
            {
                StringProp = "a",
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe(
                $@"{{""key"":""regex""}}");
        }

        [Fact]
        public void Equal_error_string_is_correct()
        {
            // Arrange
            const int target = 3;
            const int entered = target + 1;
            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.IntProp).Equal(target);

            // Act
            var result = validator.Validate(new TestDto
            {
                IntProp = entered
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe(
                $@"{{""key"":""equal"",""comparisonValue"":""{target}""}}");
        }
        
        [Fact]
        public void ExactLength_error_string_is_correct()
        {
            // Arrange
            const int limit = 3;
            const int entered = limit + 1;
            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.StringProp).Length(limit);

            // Act
            var result = validator.Validate(new TestDto
            {
                StringProp = new string('a', entered),
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe(
                $@"{{""key"":""exactLength"",""length"":""{limit}"",""entered"":""{entered}""}}");
        }

        [Fact]
        public void InclusiveBetween_error_string_is_correct()
        {
            // Arrange
            const int lower = 3;
            const int upper = 5;
            const int entered = upper + 1;

            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.IntProp).InclusiveBetween(lower, upper);

            // Act
            var result = validator.Validate(new TestDto
            {
                IntProp = entered,
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe(
                $@"{{""key"":""inclusiveBetween"",""from"":""{lower}"",""to"":""{upper}"",""entered"":""{entered}""}}");
        }

        [Fact]
        public void ExclusiveBetween_error_string_is_correct()
        {
            // Arrange
            const int lower = 3;
            const int upper = 5;
            const int entered = upper + 1;

            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.IntProp).ExclusiveBetween(lower, upper);

            // Act
            var result = validator.Validate(new TestDto
            {
                IntProp = entered,
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe(
                $@"{{""key"":""exclusiveBetween"",""from"":""{lower}"",""to"":""{upper}"",""entered"":""{entered}""}}");
        }

        [Fact]
        public void CreditCard_error_string_is_correct()
        {
            // Arrange
            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.StringProp).CreditCard();

            // Act
            var result = validator.Validate(new TestDto
            {
                StringProp = "1111"
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe(
                $@"{{""key"":""creditCard""}}");
        }

        [Fact]
        public void ScalePrecision_error_string_is_correct()
        {
            // Arrange
            const int expectedPrecision = 4;
            const int expectedScale = 2;
            var validator = new InlineValidator<ScalePrecisionDto>();
            validator.RuleFor(x => x.DecimalProp).ScalePrecision(expectedScale,expectedPrecision);

            // Act
            var result = validator.Validate(new ScalePrecisionDto
            {
                DecimalProp = 123.45678m
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe(
                $@"{{""key"":""scalePrecision"",""expectedPrecision"":""{expectedPrecision}"",""expectedScale"":""{expectedScale}"",""digits"":""3"",""actualScale"":""5""}}");
        }

        [Fact]
        public void Empty_error_string_is_correct()
        {
            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.StringProp).Empty();

            // Act
            var result = validator.Validate(new TestDto
            {
                StringProp = "I am not empty",
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe($@"{{""key"":""empty""}}");
        }

        [Fact]
        public void Enum_error_string_is_correct()
        {
            var validator = new InlineValidator<EnumDto>();
            validator.RuleFor(x => x.EnumProp).IsInEnum();
            var expected = 2;

            // Act
            var result = validator.Validate(new EnumDto
            {
                EnumProp = (EnumDto.TestEnum)expected,
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe($@"{{""key"":""enum"",""propertyValue"":""{expected}""}}");
        }

        [Fact]
        public void SimpleLength_error_string_is_correct()
        {
            // Arrange
            const int minLength = 2;
            const int maxLength = 3;
            const int entered = maxLength + 1;
            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.StringProp)
                .Length(minLength, maxLength)
                .WithErrorCode("Length_Simple");

            // Act
            var result = validator.Validate(new TestDto
            {
                StringProp = new string('a', entered),
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe($@"{{""key"":""simpleLength"",""minLength"":""{minLength}"",""maxLength"":""{maxLength}""}}");
        }

        [Fact]
        public void SimpleMinLength_error_string_is_correct()
        {
            // Arrange
            const int minLength = 2;
            const int entered = minLength - 1;
            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.StringProp)
                .MinimumLength(minLength)
                .WithErrorCode("MinimumLength_Simple");

            // Act
            var result = validator.Validate(new TestDto
            {
                StringProp = new string('a', entered),
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe($@"{{""key"":""simpleMinLength"",""minLength"":""{minLength}""}}");
        }

        [Fact]
        public void SimpleMaxLength_error_string_is_correct()
        {
            // Arrange
            const int maxLength = 2;
            const int entered = maxLength + 1;
            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.StringProp)
                .MaximumLength(maxLength)
                .WithErrorCode("MaximumLength_Simple");

            // Act
            var result = validator.Validate(new TestDto
            {
                StringProp = new string('a', entered),
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe($@"{{""key"":""simpleMaxLength"",""maxLength"":""{maxLength}""}}");
        }

        [Fact]
        public void SimpleExactLength_error_string_is_correct()
        {
            // Arrange
            const int limit = 2;
            const int entered = limit + 1;
            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.StringProp)
                .Length(limit)
                .WithErrorCode("ExactLength_Simple");

            // Act
            var result = validator.Validate(new TestDto
            {
                StringProp = new string('a', entered),
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe($@"{{""key"":""simpleExactLength"",""length"":""{limit}""}}");
        }

        [Fact]
        public void SimpleInclusiveBetween_error_string_is_correct()
        {
            // Arrange
            const int min = 2;
            const int max = 4;
            var validator = new InlineValidator<TestDto>();
            validator.RuleFor(x => x.IntProp)
                .InclusiveBetween(min, max)
                .WithErrorCode("InclusiveBetween_Simple");

            // Act
            var result = validator.Validate(new TestDto
            {
                IntProp = max + min,
            });

            // Assert
            result.Errors[0].ErrorMessage.ShouldBe($@"{{""key"":""simpleInclusiveBetween"",""from"":""{min}"",""to"":""{max}""}}");
        }

        public class TestDto
        {
            public string StringProp { get; set; }
            public int IntProp { get; set; }
        }

        public class ScalePrecisionDto
        {
            public decimal DecimalProp { get; set; }
        }

        public class EnumDto
        {
            public TestEnum EnumProp { get; set; }

            public enum TestEnum
            {
                None = 0,
                One = 1,
            }
        }
    }
}
