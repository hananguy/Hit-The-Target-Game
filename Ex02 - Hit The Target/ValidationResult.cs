using System;

namespace GameLogic
{
    /// Represents the result of a validation process for a secret code.
    public class ValidationResult
    {
        private bool _isValid;
        private SecretCode _parsedCode;
        private readonly string _errorMessage;

        /// Gets or sets a value indicating whether the validation was successful.
        public bool IsValid
        {
            get => _isValid;
            set => _isValid = value;
        }

        /// Gets or sets the parsed secret code.
        public SecretCode ParsedCode
        {
            get => _parsedCode;
            set => _parsedCode = value;
        }

        /// Gets the error message if the validation failed.
        public string ErrorMessage => _errorMessage;

        /// Initializes a new instance of the <see cref="ValidationResult"/> class.
        public ValidationResult(bool i_IsValid, SecretCode i_ParsedCode, string i_ErrorMessage)
        {
            _isValid = i_IsValid;
            _parsedCode = i_ParsedCode;
            _errorMessage = i_ErrorMessage;
        }
    }
}
