@ECHO OFF
CLS
echo ENC Configuration:
echo 1- Localhost
echo 2- 2.180.29.48
echo.
echo 9- Exit
echo.

Set /p tp= :
IF %tp%==9 GOTO THREE
IF %tp%==2 GOTO TWO
IF %tp%==1 GOTO ONE
:ONE
copy "ENC-Local.Config" "ENC.Config" /Y
echo.
echo.
echo Localhost is default connection.
echo.
echo.
pause
GOTO END
:TWO
copy "ENC-2.180.29.48.Config" "ENC.Config" /Y
echo.
echo.
@echo 2.180.29.48 is default connection.
echo.
echo.
pause
GOTO END
:THREE
REM Exit Program
GOTO END
:END
