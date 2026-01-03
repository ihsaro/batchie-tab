# BatchieTab

BatchieTab is a cross-platform CLI tool that opens multiple URLs in your browser
— normal or incognito — with a single command.

## Features

- Open multiple tabs at once.
- Supports multiple browsers (see implementation status below).
- Normal or incognito mode.
- Works on windows, mac, and linux.
- Fast, lightweight CLI.

### Instructions

### Arguments

--path <path-to-file>  
--browser <browser-name> (possible values : chrome, chromium, firefox)  
--incognito  

### Usage examples

./batchie-tab  
./batchie-tab --incognito  
./batchie-tab --path <path-to-file> --incognito  
./batchie-tab --path <path-to-file> --browser chrome --incognito  

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