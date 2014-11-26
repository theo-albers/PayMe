@ECHO OFF
REM 
REM Execute grunt tasks defined in Gruntfile.js
REM 
:Init
CALL "C:\Program Files\nodejs\nodevars.bat"
CALL "C:\Ruby21-x64\bin\setrbvars.bat"
%~d0
CD %~dp0

:Task
grunt
