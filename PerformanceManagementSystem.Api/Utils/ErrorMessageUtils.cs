namespace PerformanceManagementSystem.Api.Utils
{
    public class ErrorMessageUtils
    {

        public const string GeneralErrorMessage = "Error while processing your request";

        public string UniqueErrorMessage(string attribute, string value)
            => $"[{attribute}] must be unique, {value} already exisits";

        public string ForignKeyErrorMessage(string attribute, string child)
            => $"[{attribute}] cannot be deleted due to a relation with [{child}]";
        

    }
}
