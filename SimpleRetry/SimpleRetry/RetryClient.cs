using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleRetry
{
  public class RetryClient
  {
    private static HttpClient _client;

    public static HttpClient GetClient()
    {
      if (null == _client)
        _client = new HttpClient();
      return _client;
    }

    public static HttpClient GetInstance(TimeSpan connectionIdleTimeout, TimeSpan connectionLifetime)
    {
      if (null == _client)
      {
        SocketsHttpHandler socketsHttpHandler = new SocketsHttpHandler()
        {
          PooledConnectionIdleTimeout = connectionIdleTimeout,
          PooledConnectionLifetime = connectionLifetime
        };
        _client = new HttpClient(socketsHttpHandler);
      }
      return _client;
    }
  }
}
