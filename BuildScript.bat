@echo Off
set config=%1
if "%config%" == "" (
   set config=Release
  	
)

set version=
if not "%PackageVersion%" == "" (
   set version=-Version %PackageVersion%
)

set nunit="tools\nunit\nunit-console.exe"

REM Build
"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" TestApplication.sln /p:Configuration="%config%" /p:Platform="Any CPU" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false
if not "%errorlevel%"=="0" goto failure

REM Unit tests
%nunit% TestApplication\TestApplication.Tests\bin\%config%\TestApplication.Tests.dll
if not "%errorlevel%"=="0" goto failure

:success
exit 0

:failure
exit -1