@ECHO OFF
REM 
REM Execute mocha
REM 
:Init
CALL "C:\Program Files\nodejs\nodevars.bat"
%~d0
CD %~dp0

:Task
node_modules\.bin\mocha-phantomjs ..\test.html