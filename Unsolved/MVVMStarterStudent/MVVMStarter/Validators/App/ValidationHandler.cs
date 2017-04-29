using System;
using System.Runtime.CompilerServices;

namespace MVVMStarter.Validators.App
{
    public class ValidationHandler
    {
        public static ValidationOutcome Validate<TValue>(TValue value, Func<TValue, bool> isValid, string message)
        {
            return (isValid(value) ? null : new ValidationOutcome(message));
        }

        public static void ThrowOnInvalid<TValue>(Func<TValue, ValidationOutcome> validator, TValue value)
        {
            ValidationOutcome vo = validator(value);
            if (vo != null)
            {
                throw new ValidationException(vo.Message);
            }
        }

        public static ValidationOutcome ValidateStringMinLength(string value, int minLength,
            [CallerMemberName] string propertyName = null)
        {
            string message = propertyName + " " + " must contain at least " + minLength  + " characters";
            return Validate<string>(value, (v => v.Length >= minLength), message);
        }

        public static ValidationOutcome ValidateStringMaxLength(string value, int maxLength,
            [CallerMemberName] string propertyName = null)
        {
            string message = propertyName + " " + " must contain at most " + maxLength + " characters";
            return Validate<string>(value, (v => v.Length <= maxLength), message);
        }

        public static ValidationOutcome ValidateStringContains(string value, string containedString,
            [CallerMemberName] string propertyName = null)
        {
            string message = propertyName + " " + " must contain \"" + containedString + "\"";
            return Validate<string>(value, v => v.Contains(containedString), message);
        }

        public static ValidationOutcome ValidateStringContainsNot(string value, string containedString,
            [CallerMemberName] string propertyName = null)
        {
            string message = propertyName + " " + " must not contain \"" + containedString + "\"";
            return Validate<string>(value, v => !v.Contains(containedString), message);
        }

        public static ValidationOutcome ValidateIntInInterval(int value, int minValue, int MaxValue,
            [CallerMemberName] string propertyName = null)
        {
            string message = propertyName + " " + " must be a number between " + minValue + " and " + MaxValue;
            return Validate<int>(value, v => (v >= minValue && v <= MaxValue), message);
        }
    }
}
