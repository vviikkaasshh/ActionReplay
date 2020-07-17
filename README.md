# ActionReplay/SimpleRetry
* A simplified HTTP mechanism for retrying requests based on exception or/and HTTP status code.
* Creates single HTTPClient based on user input and keep opens TCP socket for specified time span

## ActionReplay/ParallelProcess
* Notion to create: Any thing which takes more than 0.5 second should be on separate thread according to Microsoft.
* A simplified parallel processor which takes number of workers and action item to process.
* Caller will decide number of threads.
* Helps in system where number of threads need to be used carefully.
* Avoid pitfalls for C# Parallel.forEach which uses Thread Pool threads and starve even in case of max specified parallelism
* Will add more functionality like segragation for IO bound and CPU bound operations( Currently best suited for CPU bound)

