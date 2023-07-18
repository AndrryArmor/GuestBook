using GuestBook.Application.RequestModels;

namespace GuestBook.Application.Validators
{
    public class CreateUserCommentRequestValidator
    {
        public CreateUserCommentRequestValidator(CreateUserCommentRequest request)
        {
            ValidationErrors = GetValidationErrors(request);
        }

        public bool IsRequestValid => ValidationErrors.Count == 0;

        public List<string> ValidationErrors { get; }

        private List<string> GetValidationErrors(CreateUserCommentRequest request)
        {
            var validationErrors = new List<string>
            {
                ValidateNotEmpty(request.UserName, "Your name"),
                ValidateMinLength(request.UserName, 3, "Your name"),
                ValidateMaxLength(request.UserName, 100, "Your name"),

                ValidateNotEmpty(request.Comment, "Comment"),
                ValidateMinLength(request.Comment, 10, "Comment"),
                ValidateMaxLength(request.Comment, 4000, "Comment"),
            };
            validationErrors.RemoveAll(e => string.IsNullOrEmpty(e));
            return validationErrors;
        }

        private string ValidateNotEmpty(string? property, string propertyNameForError)
        {
            return string.IsNullOrWhiteSpace(property)
                ? $"{propertyNameForError} must not be empty."
                : "";
        }

        private string ValidateMinLength(string? property, int minLength, string propertyNameForError)
        {
            return (property?.Length ?? 0) < minLength
                ? $"{propertyNameForError} must be at least {minLength} characters long."
                : "";
        }

        private string ValidateMaxLength(string? property, int maxLength, string propertyNameForError)
        {
            return (property?.Length ?? 0) > maxLength
                ? $"{propertyNameForError} must not exceed {maxLength} characters."
                : "";
        }
    }
}
