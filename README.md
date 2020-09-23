# Processor
![Processors](https://imgur.com/eqLRUrX.png)<br>

## Description
A basic replacement for the Task Manager, it includes such features as:
* CPU usage
* Memory usage
* Running time
* Start time
* Threads of a process viewable
* Commenting per process

### Further Feature set:
* Notifications if comments are not saved
* Lists processes, presented by PID + Name
* Shows required attributes when I select a process
* By double clicking, refreshes these attributes
* New dialog opens to show the threads of a process
* Comment are saved in memory
* Always on top option

## Code

Getting and assigning the RAM and CPU values.
```
var ramCounter = new PerformanceCounter("Process", "Private Bytes", _process.ProcessName, true);
var cpuCounter = new PerformanceCounter("Process", "% Processor Time", _process.ProcessName, true);

RamData.Content = (Math.Round(ramCounter.NextValue() / 1024 / 1024, 2)) + " MB";
CpuData.Content = (Math.Round(cpuCounter.NextValue() / Environment.ProcessorCount, 2)) + " %";
```

## Misc

This was a class project that had to be made as per certain requirements.<br>
[Image Source](wallhaven.cc)
## Contributors

[David Adam Schmidt](https://github.com/DavidAdamSchmidt)<br>
[Balint Ats](https://github.com/BalintAts)<br>
[Janos Krizsan](https://github.com/JanosKrizsan)
