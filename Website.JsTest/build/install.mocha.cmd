@ECHO OFF
REM 
REM Install required node packages from package.json locally
REM 
REM Prerequisites
REM install nodejs, http://nodejs.org/ (0.10.30 (x64)
REM Install grunt (0.3.1) http://gruntjs.com/getting-started 
REM     - npm install -g grunt-cli
REM

:Init
CALL "C:\Program Files\nodejs\nodevars.bat"
%~d0
CD %~dp0

:Task
IF EXIST node_modules GOTO Exit
npm install

:Exit
