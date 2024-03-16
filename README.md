
<h1 align="center">
  <br>
  <img src="blob:https://github.com/4ca29b5b-2b25-41e0-8100-3b3c9d6569ad">
  <br>
  p'Fisher
  <br>
</h1>

<h4 align="center">A powerful tool for sending phishing emails (write in <a href="https://github.com/search?q=language%3Ac%23&type=repositories" target="_blank">C#</a>).</h4>

<!-- do zmiany na aktualne informacje -->
<p align="center">
  <a href="#installation">Installation</a> •
  <a href="#application-startup">Application startup</a> •
  <a href="#commands">Commands</a> •
  <a href="#personalize-pfisher">Personalize p'Fisher</a> •
  <a href="https://github.com/Zakrzewiaczek/pFisher/issues?q=is%3Aopen+is%3Aissue+label%3Aenhancement">Task To Do</a> •
  <a href="https://github.com/Zakrzewiaczek/pFisher/issues">Errors and new functions ideas</a>
</p>

<!--![screenshot](https://github.com/Zakrzewiaczek/pFisher/blob/main/logo_noBackground.png)-->

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

> [!NOTE]
> You can also download the program using the installer:
> <ul>
>  <li> Change <tt>//#define installer</tt> &nbsp;to: &nbsp;<tt>#define installer</tt> </li>
>  <li> Compile and run program ***with administrator privileges*** </li>
> </ul>

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

```
start /B bin\Debug\p'Fisher.exe
```
<br>

> [!TIP]
> The best solution is to open and compile the program in the IDE

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
  You can type your email, password and SMTP server between quotes</li>
  
  > [!IMPORTANT]
  > Compile program after saving file!
  <br>
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
  </li> <br>

  > [!NOTE]
  > For more information, type <tt>help payload</tt>

  <br>
</ul>

## Task to do

Task to do can be found in the [Issues tab](https://github.com/Zakrzewiaczek/pFisher/issues)

## Errors and new functions ideas

If you see error or have an idea, please add _new issue_ in [Issues tab](https://github.com/Zakrzewiaczek/pFisher/issues) <br>
<br>

# **Enjoy :)**
