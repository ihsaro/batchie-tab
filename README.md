# BatchieTab

BatchieTab is a cross-platform CLI tool that opens multiple URLs in your browser
— normal or incognito — with a single command.

## Features

- Open multiple tabs at once.
- Supports multiple browsers (see implementation status below).
- Normal or incognito mode.
- Works on windows, mac, and linux.
- Fast, lightweight CLI, compiled to Native AOT.

### Arguments

--help  
--path <path to file>  
--browser <browser name> (possible values : chrome, chromium, firefox, safari, edge, brave)  
--incognito

### Instructions

#### Basic mode

1. Download the script from the github releases.  
2. Create a file called batchie-tab-file, no extension, in the same folder that you downloaded the above-mentioned script.  
3. Insert a list of urls, separated by a newline in that file.  
4. Execute the script using the following :  

- For windows : batchie-tab-win-x64.exe  
- For linux : ./batchie-tab-linux-x64  
- For macos : ./batchie-tab-osx-arm64  

If you do that, you should see the list of tabs open up in a new browser instance of your default browser.

#### Advanced / Parametrized mode

1. Download the script from the github releases.
2. Create a file using any name you want, no extension, anywhere you want in your system.
3. Insert a list of urls, separated by a newline in that file.
4. Execute the script using the following :

- For windows : ./batchie-tab-win-x64.exe --browser <browser of your choice : accepted values are chrome, firefox, edge, safari, brave, chromium> --incognito --path <path to your urls file>
- For linux : ./batchie-tab-linux-x64 --browser <browser of your choice : accepted values are chrome, firefox, edge, safari, brave, chromium> --incognito --path <path to your urls file>
- For macos : ./batchie-tab-osx-arm64 --browser <browser of your choice : accepted values are chrome, firefox, edge, safari, brave, chromium> --incognito --path <path to your urls file>

If you do that, you should see the list of tabs open up in a new incognito browser instance of the browser that you specified. This full command demonstrates the complete ability of the script.

All parameters are optional, meaning:

1. If you don't specify which browser to use, it would simply use your default web browser.
2. If you don't specify incognito, it would open all urls in normal tabs.
3. If you don't specify the file path, it would default to the "batchie-tab-file", as explained above.

**A last, but very important note : DO NOT use any file that someone sends you without inspecting the content first, I have yet to assess the security aspect of this script. I do not take any responsibility in case of system hacking / corruption due to unsafe files containing malicious content. A normal url file would be as follows:**

https://www.google.com  
https://www.gmail.com  
https://www.facebook.com  
https://www.youtube.com

### Usage examples

./batchie-tab  
./batchie-tab --incognito  
./batchie-tab --path <path to file> --incognito  
./batchie-tab --path <path to file> --browser chrome --incognito  

### Implementation status

| Operating system | Browser  | Installation method | Status             | Comments                                                                                                                                                                                                            |
|------------------|----------|---------------------|--------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Linux            | Brave    | deb / rpm           | :white_check_mark: |                                                                                                                                                                                                                     |
| Linux            | Brave    | flatpak             | :white_check_mark: |                                                                                                                                                                                                                     |
| Linux            | Brave    | snap                | :white_check_mark: |                                                                                                                                                                                                                     |
| Linux            | Chrome   | deb / rpm           | :white_check_mark: |                                                                                                                                                                                                                     |
| Linux            | Chrome   | flatpak             | :white_check_mark: |                                                                                                                                                                                                                     |
| Linux            | Chromium | deb / rpm           | :white_check_mark: |                                                                                                                                                                                                                     |
| Linux            | Chromium | flatpak             | :white_check_mark: |                                                                                                                                                                                                                     |
| Linux            | Chromium | snap                | :white_check_mark: |                                                                                                                                                                                                                     |
| Linux            | Edge     | deb / rpm           | :white_check_mark: |                                                                                                                                                                                                                     |
| Linux            | Edge     | flatpak             | :white_check_mark: |                                                                                                                                                                                                                     |
| Linux            | Firefox  | deb / rpm           | :warning:          | Normal mode - opens in 2 windows: n - 1 urls in a window and 1 url in another window; Incognito - Opens n - 1 urls but 1 random url is not opened, but instead is opened in a new tab in the same incognito window. |
| Linux            | Firefox  | flatpak             | :warning:          | Normal mode - opens in 2 windows: n - 1 urls in a window and 1 url in another window; Incognito - Opens n - 1 urls but 1 random url is not opened, but instead is opened in a new tab in the same incognito window. |
| Linux            | Firefox  | snap                | :warning:          | Normal mode - opens in 2 windows: n - 1 urls in a window and 1 url in another window; Incognito - Opens n - 1 urls but 1 random url is not opened, but instead is opened in a new tab in the same incognito window. |
| Macos            | Brave    |                     | :heavy_check_mark: | All urls are opened except that one additional empty tab is opened.                                                                                                                                                 |
| Macos            | Chrome   |                     | :heavy_check_mark: | All urls are opened except that one additional empty tab is opened.                                                                                                                                                 |
| Macos            | Chromium |                     | :x:                |                                                                                                                                                                                                                     |
| Macos            | Edge     |                     | :heavy_check_mark: | All urls are opened except that one additional empty tab is opened.                                                                                                                                                 |
| Macos            | Firefox  |                     | :warning:          | Normal mode - opens in 2 windows: n - 1 urls in a window and 1 url in another window; Incognito - Opens n - 1 urls but 1 random url is not opened, but instead is opened in a new tab in the same incognito window. |
| Macos            | Safari   |                     | :heavy_check_mark: | All urls are opened except that one additional empty tab is opened.                                                                                                                                                 |
| Windows          | Brave    |                     | :white_check_mark: |                                                                                                                                                                                                                     |
| Windows          | Chrome   |                     | :white_check_mark: |                                                                                                                                                                                                                     |
| Windows          | Chromium |                     | :white_check_mark: |                                                                                                                                                                                                                     |
| Windows          | Edge     |                     | :white_check_mark: |                                                                                                                                                                                                                     |
| Windows          | Firefox  |                     | :warning:          | Normal mode - opens in 2 windows : n - 1 urls in a window and 1 url in another window; Incognito - Opens n - 1 urls in a normal window and only 1 url in a new incognito window                                     |

:white_check_mark: - Fully functional.  
:heavy_check_mark: - Mostly functional with some minor caveats.  
:warning: - Partly functional with some caveats.  
:x: - Not functional.