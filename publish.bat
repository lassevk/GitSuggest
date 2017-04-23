@echo off
setlocal

for /d %%f in (*.*) do (
    if exist "%%f\bin" rd /s /q "%%f\bin"
    if exist "%%f\obj" rd /s /q "%%f\obj"
)

nuget restore
msbuild /t:Rebuild

cd GitSuggest.CommandLine
dotnet publish

cd ..
robocopy /E /MIR GitSuggest.CommandLine\bin\Debug\netcoreapp1.1\publish Release
if %errorlevel% geq 4 goto eof

robocopy /E GitSuggest.Windows\bin\Debug Release
if %errorlevel% geq 4 goto eof

robocopy /E /MIR Release %DROPBOX%\Tools\GitSuggest
if %errorlevel% geq 4 goto eof

exit /B 0
