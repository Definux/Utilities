namespace Definux.Utilities.Objects
{
    public class SimpleResult
    {
        public SimpleResult(bool successed = false)
        {
            Successed = successed;
        }

        public bool Successed { get; set; }
    }
}
