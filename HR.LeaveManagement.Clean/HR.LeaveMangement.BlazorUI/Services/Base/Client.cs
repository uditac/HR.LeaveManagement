using System.Net.Http;
using Microsoft.Extensions.Http;

namespace HR.LeaveMangement.BlazorUI.Services.Base;

public partial class Client : IClient
{
    public HttpClient HttpClient
    {
        get
        {
            return HttpClient;
        }
    }
}