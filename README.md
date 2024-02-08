# https://github.com/TumenSan/GosusligiSignInPasswordTest

# 1. Установка необходимых инструментов

### Если у вас установлены NuGet Cli и NUnit, вы можете пропустить данный первый пункт и сразу запускать тест

### Если у вас установлен .NET, вы можете пропустить первый подпункт 1)

### 1) Установите .NET 8 или NuGet CLI

Загрузить .NET 8 можно с официального сайта .NET https://dotnet.microsoft.com/en-us/download/dotnet/8.0

Вы можете скачать NuGet CLI из официального сайта NuGet или установить его из командной строки

`curl -o nuget.exe https://dist.nuget.org/win-x86-commandline/latest/nuget.exe`

### 2) Установите библиотеки для тестирования

Установите NUnit 3.13 с помощью команды

`Install-Package NUnit -Version 3.13.0`

Или можно использовать NuGet CLI для установки библиотек для тестирования

`nuget install NUnit`
`nuget install NUnit3TestAdapter`


# 2. Запуск тестов

В папке проекта напишите команду

`dotnet test`