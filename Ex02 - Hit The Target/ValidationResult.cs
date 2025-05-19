using System;

namespace GameLogic
{
    /// Represents the result of a validation process for a secret code.
    public class ValidationResult
    {
        private bool m_IsValid;
        private SecretCode m_ParsedCode;
        private readonly string m_ErrorMessage;

        /// Gets or sets a value indicating whether the validation was successful.
        public bool IsValid
        {
            get => m_IsValid;
            set => m_IsValid = value;
        }

        /// Gets or sets the parsed secret code.
        public SecretCode ParsedCode
        {
            get => m_ParsedCode;
            set => m_ParsedCode = value;
        }

        /// Gets the error message if the validation failed.
        public string ErrorMessage => m_ErrorMessage;

        /// Initializes a new instance of the <see cref="ValidationResult"/> class.
        public ValidationResult(bool isValid, SecretCode parsedCode, string errorMessage)
        {
            this.m_IsValid = isValid;
            this.m_ParsedCode = parsedCode;
            this.m_ErrorMessage = errorMessage;
        }
    }
}
