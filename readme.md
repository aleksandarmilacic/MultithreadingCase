In this example, we have a scenario where multiple operations need to be executed concurrently, but we want to limit the maximum number of operations that can access a shared resource at the same time. To achieve this, we use a SemaphoreSlim object.

The code starts by creating an array of Task objects to represent the concurrent operations. Each operation is represented by the ProcessAsync method, which takes an id parameter.

In the ProcessAsync method, each operation first waits to enter the semaphore by calling WaitAsync on the semaphoreSlim object. Once entered, it performs a time-consuming task (simulated by the Task.Delay method) and then releases the semaphore by calling Release.

In the Main method, the ProcessAsync tasks are started concurrently using Task.WhenAll, and we await their completion. Finally, a message is displayed to indicate that all operations have completed.