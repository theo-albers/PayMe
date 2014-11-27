@ECHO OFF
REM 
REM Install required bower packages from bower.json locally
REM 
REM Prerequisites
REM install nodejs, http://nodejs.org/ (0.10.30 (x64)
REM

:Init
CALL "C:\Program Files\nodejs\nodevars.bat"
%~d0
CD %~dp0

:Task
IF EXIST node_modules GOTO Exit
node_modules\.bin\bower install

:Exit
