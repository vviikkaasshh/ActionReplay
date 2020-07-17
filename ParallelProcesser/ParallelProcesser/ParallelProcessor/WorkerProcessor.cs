using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ParallelProcessor
{
  public class WorkerProcessor<T> : IDisposable where T : class
  {
    private readonly object _locker = new object();
    private readonly Action<T> _action;
    private readonly List<Thread> _workers;
    private readonly Queue<T> _tasks = new Queue<T>();

    public WorkerProcessor(int workercounts, Action<T> items)
    {
      _action = items;
      _workers = new List<Thread>(workercounts);

      foreach (var index in Enumerable.Range(1, workercounts))
      {
        var thread = new Thread(consume) { Name = $"Worker Processor {index}" };
        _workers.Add(thread);
        thread.Start();
      }
    }

    public void EnqueueTask(T task)
    {
      lock (_locker)
      {
        _tasks.Enqueue(task);
        Monitor.PulseAll(_locker);
      }
    }


    private void consume()
    {
      while (true)
      {
        T item;
        lock (_locker)
        {
          while (!_tasks.Any())
          {
            Monitor.Wait(_locker);

          }
          item = _tasks.Dequeue();
        }
        if (default(T)== item)
        {
          return;
        }

        //Run method
        _action(item);
      }
    }

    public void Dispose()
    {
      _workers.ForEach(thread => EnqueueTask(default(T)));

      _workers.ForEach(thread => thread.Join());

    }
  }
}
