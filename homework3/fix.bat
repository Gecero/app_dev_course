@echo off
for /f "delims=*" %%a in ('dir /b /s *') do (
	REM fix the case sensitive file system stuff
	@fsutil file setCaseSensitiveInfo "%%a" disable > NUL
)