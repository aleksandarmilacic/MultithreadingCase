namespace MultithreadingCase
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class Program
    {
        private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1);

        public static async Task Main(string[] args)
        {
            // Simulating multiple concurrent operations
            var tasks = new Task[5];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = ProcessAsync(i + 1);
            }

            await Task.WhenAll(tasks);
            Console.WriteLine("All operations completed.");
        }

        public static async Task ProcessAsync(int id)
        {
            Console.WriteLine($"Operation {id} waiting to enter the semaphore.");
            await semaphoreSlim.WaitAsync();

            try
            {
                Console.WriteLine($"Operation {id} entered the semaphore.");

                // Simulating time-consuming operation
                await Task.Delay(2000);

                Console.WriteLine($"Operation {id} exiting the semaphore.");
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }
    }

}