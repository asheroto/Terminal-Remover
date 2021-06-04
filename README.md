# Windows Terminal Remover

This was mainly created because I found that uninstalling Windows Terminal did not actually remove it entirely.

I was having an issue launching Windows Terminal: `The network location cannot be reached` when launching Windows Terminal. Once I figured out the fix, I created this app.

Running this completely wipes out Windows Terminal. Afterwards, simply reinstall Windows Terminal and most bugs related to accessing Terminal will be gone.

# What it Does

- Removes Appx package
- Removes `$ENV:ProgramFiles\WindowsApps\*WindowsTerminal*` folders (which requires taking ownership, granting permissions, removing in use files and some registry keys)

# Instructions

Just open it up and read! 😀

# Screenshot

![Main Window](https://github.com/asheroto/Terminal-Remover/blob/master/screenshots/1.png)