# p'Fisher
Tool for sending payloads by e-mail
<br><br>

## Installation

<ul>
  <li> Installation via powershell (Making new *.zip pFisher folder with files) </li>
</ul>

```bash
  Invoke-Webrequest -OutFile "$home\Desktop\pFisher.zip" -Uri "https://codeload.github.com/Zakrzewiaczek/pFisher/zip/refs/heads/main"
```

<br>
<ul>
  <li> Installation via cmd (Making new *.zip pFisher folder with files) </li>
</ul>

```bash
curl -L -o "%USERPROFILE%\Desktop\pFisher.zip" "https://codeload.github.com/Zakrzewiaczek/pFisher/zip/refs/heads/main"
```
<br>

## Application startup

Go to p'Fisher folder (with Program.cs file)

<ul>
  <li> powershell </li>
</ul>

```bash
Start-Process -NoNewWindow "bin\Debug\p`'Fisher.exe"
```

<ul>
  <li> cmd </li>
</ul>

```bash
start /B bin\Debug\p'Fisher.exe
```
<br>

## Commands

Type ```help``` to show all availabe commands in p'Fisher console. <br>
Type ```help [command]``` to show help about specified command

## Personalize p'Fisher

You can personalize p'Fisher. How?

<ul>
  <li> In Program.cs find lines: 
  <br><br>
    
  ```
    public static string from_email = "";
    public static string password = "";
    public static string smtp = "";
  ```
  You can type your email, password and SMTP server between quotes <br>
    **Remember to compile after saving file!**
  </li><br>
  <li>
    You can use <tt>save_preset</tt> and <tt>read_preset</tt> commands to making and reading presets! <br>
    For example: you set the email title to "email_title", if you save preset and read in other console, settings will be saved
  </li><br>
  <li>
    You can change console elements colors using <tt>change_color</tt> command. <br>
    For more detailed instructions how to use, type <tt>help change_color</tt> command
  </li><br>
  <li>
    You can add your payloads file using <tt>payload add [path] [payload_name]</tt> command. <br>
    If path and payload_name is empty, p'Fisher will show the file selection window and then ask for the payload name. <br><br>
    For more information, type <tt>help payload</tt>
  </li>
</ul>

## Errors

If you see error, please add _new issue_ in _Issue_ tab

<br><br>
# **Enjoy :)**
