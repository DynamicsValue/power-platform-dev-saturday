namespace web.Models
{
    public class GenericResult 
    {
        public bool Succeeded { get; set; }
        public string ErrorMessage { get; set;}

        public static GenericResult Succeed() => new GenericResult() { Succeeded = true };
        public static GenericResult FailWith(string errorMessage) => new GenericResult() { Succeeded = false, ErrorMessage = errorMessage };
    }
}