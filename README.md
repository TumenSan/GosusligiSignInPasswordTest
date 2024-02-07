# 1. Установка необходимых инструментов

### Если у вас установлены NuGet Cli и NUnit, вы можете пропустить данный первый пункт и сразу запускать тест

### Если у вас установлен .NET, вы можете пропустить первый подпункт 1)

### 1) Установите NuGet CLI

Вы можете скачать NuGet CLI из официального сайта NuGet или установить его из командной строки

`curl -o nuget.exe https://dist.nuget.org/win-x86-commandline/latest/nuget.exe`

### 2) Установите библиотеки для тестирования

Используйте NuGet CLI для установки библиотек для тестирования

`nuget install NUnit`
`nuget install NUnit3TestAdapter`


# 2. Запуск тестов

В папке проекта напишите команду

`dotnet test`