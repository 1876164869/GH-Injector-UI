# GH Injector UI

一个基于 WinForms 的 GH Injector 图形界面封装，用于选择目标进程、选择待注入 DLL，并调用 GH Injector 的原生注入库完成注入。

本项目本身不包含 GH Injector 的 Release 二进制文件。运行或发布时，需要从 GH Injector 开源项目的 Release 中取得对应架构的文件，并放到本程序输出目录。

## 依赖

- Windows
- .NET 8 Windows Desktop Runtime，或使用自包含发布
- GH Injector Release 文件

## 构建

使用 Visual Studio 打开 `Injector.sln`，选择对应平台后构建：

- `Debug|x86` / `Release|x86`
- `Debug|x64` / `Release|x64`

也可以使用命令行：

```powershell
dotnet build .\Injector.sln -c Release -p:Platform=x86
dotnet build .\Injector.sln -c Release -p:Platform=x64
```

## 发布文件需求

当前发布至少需要以下文件。

### x86

将这些文件放在同一个目录中：

```text
Injector-x86.exe
Injector-x86.dll
Injector-x86.deps.json
Injector-x86.runtimeconfig.json
GH Injector - x86.dll
```

其中 `GH Injector - x86.dll` 来自 GH Injector 的 Release。

### x64

将这些文件放在同一个目录中：

```text
Injector-x64.exe
Injector-x64.dll
Injector-x64.deps.json
Injector-x64.runtimeconfig.json
GH Injector - x64.dll
GH Injector SM - x86.exe
```

其中 `GH Injector - x64.dll` 和 `GH Injector SM - x86.exe` 来自 GH Injector 的 Release。

## 使用

1. 按目标架构准备发布目录。
2. 从 GH Injector Release 中复制对应架构文件到发布目录。
3. 运行 `Injector-x86.exe` 或 `Injector-x64.exe`。
4. 选择要注入的 DLL。
5. 选择目标进程和注入参数。
6. 执行注入。

请确保程序架构、GH Injector DLL 架构和目标进程架构匹配。

## 致谢

本项目依赖 GH Injector 开源项目提供的注入能力。请遵守 GH Injector 原项目的许可证和使用条款。

## 注意

本项目仅作为 GH Injector 的 UI 封装示例。请只在你拥有授权的环境和目标进程中使用，使用者需自行承担相关风险。
