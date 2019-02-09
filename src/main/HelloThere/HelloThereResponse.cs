using ServiceStack;

namespace main.HelloThere
{
    public class HelloThereResponse : IHasResponseStatus
    {
        public virtual string Message { get; set; }
        public virtual string SomethingConfig { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
}