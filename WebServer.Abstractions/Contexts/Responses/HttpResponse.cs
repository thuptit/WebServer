using WebServer.Abstractions.Contexts.Requests;

namespace WebServer.Abstractions.Contexts.Responses
{
    public sealed class HttpResponse
    {
        public HttpResponse()
        {
            Headers = new();
        }
        public int StatusCode { get; set; }
        public HttpHeader Headers { get; set; }
    }
}
