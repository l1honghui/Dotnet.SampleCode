## 线程交互或信号

线程交互（或线程信号）表示线程必须等待来自一个或多个线程的通知或信号才能继续。 

例如，如果线程 A 调用线程 B 的 [Thread.Join](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.thread.join) 方法，则线程 A 将被阻止，直到完成线程 B。 前面部分中所述的同步基元提供不同的信号机制：通过释放 lock，一个线程通知另一个线程可以通过获取 lock 来继续。

AutoResetEvent和ManualRestEvent都是控制线程交互类，他们都是继承自EventWaitHandle。[System.Threading.EventWaitHandle](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.eventwaithandle) 类表示一个线程同步事件

同步事件可以处于未发出信号状态或已发出信号状态。 当事件的状态为未发出信号时，调用了事件的 [WaitOne](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.waithandle.waitone) 重载的线程会被阻止，直到事件处于已发出信号状态。 [EventWaitHandle.Set](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.eventwaithandle.set) 方法可将事件的状态设置为已发出信号。

已发出信号的 [EventWaitHandle](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.eventwaithandle) 的行为取决于其重置模式：

- 使用 [EventResetMode.AutoReset](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.eventresetmode#System_Threading_EventResetMode_AutoReset) 标志创建的 [EventWaitHandle](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.eventwaithandle) 会在释放单个等待线程后自动进行重置。 就像旋转栅在每次发出信号时仅允许一个线程通过一样。 派生自 [EventWaitHandle](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.eventwaithandle) 的 [System.Threading.AutoResetEvent](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.autoresetevent) 类表示该行为。
- 在 [Reset](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.eventwaithandle.reset) 方法获得调用前，一直向使用 [EventResetMode.ManualReset](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.eventresetmode#System_Threading_EventResetMode_ManualReset) 标志创建的 [EventWaitHandle](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.eventwaithandle) 发出信号。 就像接收到信号前保持关闭、然后在被关闭前保持打开的大门一样。 派生自 [EventWaitHandle](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.eventwaithandle) 的 [System.Threading.ManualResetEvent](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.manualresetevent) 类表示该行为。 [System.Threading.ManualResetEventSlim](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.manualreseteventslim) 类是 [ManualResetEvent](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.manualresetevent) 的轻量替代项。

## AutoResetEvent

Represents a thread synchronization event that, when signaled, resets automatically after releasing a single waiting thread. 

表示线程同步事件在一个等待线程释放后收到信号时自动重置（Reset）。





## ManualResetEvent 

Represents a thread synchronization event that, when signaled, must be reset manually. 

代表一个线程同步事件，发出信号时，必须手动重置（Reset）。



## Interlocked 类

[System.Threading.Interlocked](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.interlocked) 类提供了可对变量执行简单原子操作的静态方法。 这些原子操作包括添加、递增和递减、交换、取决于比较的条件交换以及读取 64 位整数值的操作。

有关详细信息，请参阅 [Interlocked](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.interlocked) API 参考。



## SpinWait 结构

[System.Threading.SpinWait](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.spinwait) 结构为基于自旋的等待提供支持。 如果线程必须等待事件收到信号或必须满足某种条件，但实际等待时间应短于使用等待句柄或以其他方式阻止线程所需的等待时间，你可能想要使用该结构。 通过使用 [SpinWait](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.spinwait)，你可以指定等待期间要旋转的一小段时间，且只在特定时间不满足条件时让行（例如，通过等待或休眠）。

有关详细信息，请参阅 [SpinWait](https://docs.microsoft.com/zh-cn/dotnet/standard/threading/spinwait) 一文和 [SpinWait](https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.spinwait) API 参考。