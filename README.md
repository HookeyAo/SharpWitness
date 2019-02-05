# SharpWitness

SharpWitness is my attempt at cobbling together a C# version of [EyeWitness](https://github.com/FortyNorthSecurity/EyeWitness) by Christopher Truncer.  It still barely functions right now, but will hopefully become more useful once I put some dev time into it.

## Usage

```text
> SharpWitness.exe

  -t, --targets    Required. Text file containing targets to scan, e.g: urls.txt
  -o, --outfile    Required. Outfile, e.g: report.html
  --help           Display this help screen.
  --version        Display version information.
```

```
> type C:\Users\Rasta\Desktop\urls.txt
https://www.bbc.co.uk/news/science_and_environment

> SharpWitness.exe -t C:\Users\Rasta\Desktop\urls.txt -o C:\Users\Rasta\Desktop\report.html
```
## Report

![](https://raw.githubusercontent.com/rasta-mouse/SharpWitness/master/SharpWitness.png)
