#- Open "Command Prompt" (not PowerShell) using "Run as Administrator
#- bcdedit /set {current} safeboot network
#- shutdown /r /t 0
#- bcdedit /set {current} safeboot network

Get-AppxPackage *WindowsTerminal* | Remove-AppxPackage -Force

$fontKey = "HKCU:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts\*WindowsTerminal*"
Get-Item $fontKey | Remove-Item -Force

$tf = "$ENV:ProgramFiles\WindowsApps\*WindowsTerminal*"
$loc = Get-Item $tf
foreach($item in $loc) {
	takeown /F $item /A /R /D Y
	icacls $item /grant:r everyone:F /T 
	Remove-Item $item -Force -Recurse
}

cmd /K "bcdedit /deletevalue {current} safeboot"

Clear-Host
Write-Output "Script is done"
Write-Output "After you press enter, your computer will reboot into Normal mode"
Write-Output "Reinstall Windows Terminal afterwards"
Write-Output ""
pause

shutdown /r /t 0