@echo off
call .\config.bat
if %configstatus%==ERR goto builderror
For /f "tokens=1-3 delims=/ " %%a in ('date /t') do (set mydate=%%c-%%b-%%a)
For /f "tokens=1-2 delims=/:" %%a in ('time /t') do (set mytime=%%a%%b)
@echo Clearing build folder...
del .\Build\*.* /Q /F /S >NUL
@echo Building ZIPs...
@echo MonoBehaviour Template...
"%zip%" a ".\Build\Templates\ItemTemplates\C#\Unity Mod MonoBehaviour Class.zip" ".\Templates\ItemTemplates\C#\Unity Mod MonoBehaviour Class\*.*" >NUL
@echo Plugin Template...
"%zip%" a ".\Build\Templates\ItemTemplates\C#\Unity Mod BepInEx Plugin Class.zip" ".\Templates\ItemTemplates\C#\Unity Mod BepInEx Plugin Class\*.*" >NUL
@echo Utils Template...
"%zip%" a ".\Build\Templates\ItemTemplates\C#\Unity Mod Utils Class.zip" ".\Templates\ItemTemplates\C#\Unity Mod Utils Class\*.*" >NUL
@echo Patch Template...
"%zip%" a ".\Build\Templates\ItemTemplates\C#\Unity Mod Harmony Patch Class.zip" ".\Templates\ItemTemplates\C#\Unity Mod Harmony Patch Class\*.*" >NUL
@echo Project Template...
"%zip%" a -r ".\Build\Templates\ProjectTemplates\C#\Unity Mod (BepInEx).zip" ".\Templates\ProjectTemplates\C#\Unity Mod (BepInEx)\*.*" >NUL
@echo ZIP final file...
"%zip%" a ".\Release\UnityModTemplateRelease_%mydate%_%mytime%.zip" ".\Build\Templates" >NUL
@echo Clearing build folder...
del .\Build\*.* /Q /F /S >NUL
@echo Done!
if %1.==. goto builddone
@echo Deploying...
call deploy.bat ".\Release\UnityModTemplateRelease_%mydate%_%mytime%.zip"
@echo All done!
goto builddone
:builderror
@echo Build failed. Check for errors above.
:builddone