@ECHO OFF
REM 
REM Install required node packages from package.json locally
REM 
REM Prerequisites
REM Install Ruby 2.1.5 (x64) http://rubyinstaller.org/ 
REM Install compass http://compass-style.org/install/
REM		- gem update --system
REM		- gem install compass
REM Install grunt (0.3.1) http://gruntjs.com/getting-started 
REM     - npm install -g grunt-cli
REM

:Init
CALL "C:\Program Files\nodejs\nodevars.bat"
CALL "C:\Ruby21-x64\bin\setrbvars.bat"
%~d0
CD %~dp0

:Task
IF EXIST node_modules GOTO Exit
npm install

:Exit
