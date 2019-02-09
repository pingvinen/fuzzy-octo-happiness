using ServiceStack;

namespace main.HelloThere
{
    [Route("/hello/{who}")]
    public class HelloThereRequest : IReturn<HelloThereResponse>
    {
        public virtual string Who { get; set; }
    }
}