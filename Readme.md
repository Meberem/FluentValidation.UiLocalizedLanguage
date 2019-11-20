# Ui Localized Language (Manager) for Fluent Validation

For when you need to localized the error messages on the Client rather than the server, this will return a JSON object that can be decoded on the client and displayed appropriately

For example a Precision validation message will be a string that can be decoded to look like so:

```
{
	"key": "scalePrecision",
	"expectedPrecision": "4",
	"expectedScale": "2",
	"digits": "3",
	"actualScale":"5"
}
```

Instead of
```
"'PropertyName' must not be more than 4 digits in total, with allowance for 2 decimals. 3 digits and 5 decimals were found."
```

## Usage

Somewhere in your startup code

```
using FluentValidation;
using FluentValidation.UiLocalizedLanguage;
...

ValidatorOptions.LanguageManager = UiLocalizableLanguageManager.Default;
```
