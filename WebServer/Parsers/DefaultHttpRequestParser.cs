using System.Buffers;
using System.Text;
using System.Text.Json;
using WebServer.Abstractions;
using WebServer.Abstractions.Contexts.Requests;
using WebServer.Abstractions.HttpProtocols;
using WebServer.Abstractions.Urls;

namespace WebServer.Parsers;

public class DefaultHttpRequestParser : IHttpComponentParser
{
    public HttpRequest ParserHttpRequest(string content)
    {
        var requestContent = content.Split("\r\n\r\n");
        if (requestContent.Length == 0)
            throw new Exception("Request isn't a HTTP Request");
        
        //parser to header
        var header = requestContent[0];
        string[] headerLines = header.Split(new string[] { "\r\n" }, StringSplitOptions.None);
        string requestLine = headerLines[0];
        string[] requestLineParts = requestLine.Split(' ');
        var httpMethod = requestLineParts[0];
        var requestUri = requestLineParts[1];

        var httpRequestHeader = new HttpRequestHeader();
        for (int i = 1; i < headerLines.Length; i++)
        {
            string[] headerParts = headerLines[i].Split(new char[] { ':' }, 2);
            if (headerParts.Length == 2)
            {
                httpRequestHeader.Add(headerParts[0], headerParts[1].Trim());
            }
        }

        return new HttpRequest(
            httpMethod,
            httpRequestHeader,
            requestContent.Length > 1 ? JsonSerializer.Deserialize<object>(requestContent[1]) : null,
            new HttpUrl(requestUri)
        );
    }
}