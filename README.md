# xdelta3-dotnet

[![Build status](https://img.shields.io/appveyor/ci/hanabi1224/xdelta3-dotnet/master.svg)](https://ci.appveyor.com/project/hanabi1224/xdelta3-dotnet)
[![MIT License](https://img.shields.io/github/license/hanabi1224/xdelta3-dotnet.svg)](https://github.com/hanabi1224/xdelta3-dotnet/blob/master/LICENSE)
========

This library is a dotnet binding of [xdelta](https://github.com/jmacd/xdelta/)

### dotnet nuget packages

| Runtimes                      | Nuget package                                                                                                                                 |
| ----------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------- |
| xdelta3.net                       | [![NuGet version](https://buildstats.info/nuget/xdelta3.net)](https://www.nuget.org/packages/xdelta3.net)                                             |
| xdelta3.net.redist.windows.x64 | [![NuGet version](https://buildstats.info/nuget/xdelta3.net.redist.windows.x64)](https://www.nuget.org/packages/xdelta3.net.redist.windows.x64) |
| xdelta3.net.redist.linux.x64   | [![NuGet version](https://buildstats.info/nuget/xdelta3.net.redist.linux.x64)](https://www.nuget.org/packages/xdelta3.net.redist.linux.x64)     |

#### Installation
```xml
  <ItemGroup>
    <PackageReference Include="xdelta3.net" />
  </ItemGroup>
```

#### Usage
```c#
var source = new byte[] { 1, 2, 3, 4, 5 };
var target = new byte[] { 5, 4, 3, 2, 1};

var delta = Xdelta3Lib.Encode(source: source, target: target);

var decoded = Xdelta3Lib.Decode(source: source, delta: delta);

decoded.ToArray().Should().BeEquivalentTo(target);
```
