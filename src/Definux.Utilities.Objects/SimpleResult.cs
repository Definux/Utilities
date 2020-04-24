namespace Definux.Utilities.Objects
{
    public class SimpleResult
    {
        public SimpleResult(bool success = false)
        {
            Success = success;
        }

        public bool Success { get; set; }
    }
}
