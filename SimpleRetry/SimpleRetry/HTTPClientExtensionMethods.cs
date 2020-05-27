using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleRetry
{
  public static class HTTPClientExtensionMethods
  {
    public static Task<HttpResponseMessage> GetAsync(this HttpClient client, string requestUri, TimeSpan timeout)
    {
      var cts = new CancellationTokenSource(timeout);
      return client.GetAsync(requestUri, cts.Token);
    }

    public static Task<HttpResponseMessage> GetAsync(this HttpClient client, Uri requestUri, TimeSpan timeout)
    {
      var cts = new CancellationTokenSource(timeout);
      return client.GetAsync(requestUri, cts.Token);
    }

    public static Task<HttpResponseMessage> PostAsync(this HttpClient client, string requestUri, HttpContent httpContent, TimeSpan timeout)
    {
      var cts = new CancellationTokenSource(timeout);
      return client.PostAsync(requestUri, httpContent, cts.Token);
    }

    public static Task<HttpResponseMessage> PostAsync(this HttpClient client, Uri requestUri, HttpContent httpContent, TimeSpan timeout)
    {
      var cts = new CancellationTokenSource(timeout);
      return client.PostAsync(requestUri, httpContent, cts.Token);
    }

    public static Task<HttpResponseMessage> PutAsync(this HttpClient client, string requestUri, HttpContent httpContent, TimeSpan timeout)
    {
      var cts = new CancellationTokenSource(timeout);
      return client.PutAsync(requestUri, httpContent, cts.Token);
    }

    public static Task<HttpResponseMessage> PutAsync(this HttpClient client, Uri requestUri, HttpContent httpContent, TimeSpan timeout)
    {
      var cts = new CancellationTokenSource(timeout);
      return client.PutAsync(requestUri, httpContent, cts.Token);
    }

    public static Task<HttpResponseMessage> DeleteAsync(this HttpClient client, string requestUri, TimeSpan timeout)
    {
      var cts = new CancellationTokenSource(timeout);
      return client.DeleteAsync(requestUri, cts.Token);
    }

    public static Task<HttpResponseMessage> DeleteAsync(this HttpClient client, Uri requestUri, TimeSpan timeout)
    {
      var cts = new CancellationTokenSource(timeout);
      return client.DeleteAsync(requestUri, cts.Token);
    }
  }
}
