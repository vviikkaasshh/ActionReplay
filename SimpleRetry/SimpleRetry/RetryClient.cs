using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleRetry
{
  public class RetryClient
  {
    private static HttpClient _client;

    public static void GetClient()
    {
      _client = new HttpClient();
    }

    public static void GetInstance(TimeSpan connectionIdleTimeout, TimeSpan connectionLifetime)
    {
      SocketsHttpHandler socketsHttpHandler = new SocketsHttpHandler()
      {
        PooledConnectionIdleTimeout = connectionIdleTimeout,
        PooledConnectionLifetime = connectionLifetime
      };
      _client = new HttpClient(socketsHttpHandler);
    }
  }
}
