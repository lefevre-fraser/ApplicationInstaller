if not exist "C:\Temp\Silent" (
    mkdir "C:\Temp\Silent"
)

set outfile="C:\Temp\Silent\ActionLogs.log"

pushd %1

echo %date% %time% >> %outfile%
echo Now Running: %2 >> %outfile%
echo In Directory: %1 >> %outfile%

echo %2 | FindStr /C:".ps1"
set ispower=%errorlevel%
echo %2 | FindStr /C:".msi"
set ismsi=%errorlevel%
echo %2 | FindStr /C:".exe"
set isexe=%errorlevel%

if %ispower% EQU 0 (
    echo PowerShell Execution >> %outfile%
    powershell.exe -ExecutionPolicy bypass -File %2 >> %outfile%
) else if %ismsi% EQU 0 (
    echo MSI Execution >> %outfile%
    msiexec %3 %2 /qn /norestart >> %outfile%
) else if %isexe% EQU 0 (
    echo EXE Execution >> %outfile%
    start /wait "" %2
) else (
    echo Regular Execution >> %outfile%
    cmd /c %2 >> %outfile%
)

echo %time% >> %outfile%
echo. >> %outfile%
echo. >> %outfile%
echo. >> %outfile%
echo. >> %outfile%
echo. >> %outfile%

popd