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

| Operating system | Browser        | Status             | Comments                                                                                                                                                                                                           |
|------------------|----------------|--------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Linux            | Brave          | :white_check_mark: |                                                                                                                                                                                                                    |
| Linux            | Chrome         | :white_check_mark: |                                                                                                                                                                                                                    |
| Linux            | Chromium       | :white_check_mark: |                                                                                                                                                                                                                    |
| Linux            | Edge           | :x:                |                                                                                                                                                                                                                    |
| Linux            | Firefox        | :warning:          | Normal mode - opens in 2 windows: n - 1 urls in a window and 1 url in another window; Incognito - Opens n - 1 urls but 1 random url is not opened, but instead is opened in a new tab in the same incognito window |
| Macos            | Brave          | :x:                |                                                                                                                                                                                                                    |
| Macos            | Chrome         | :heavy_check_mark: | All urls are opened except that one additional empty tab is opened.                                                                                                                                                |
| Macos            | Chromium       | :x:                |                                                                                                                                                                                                                    |
| Macos            | Edge           | :x:                |                                                                                                                                                                                                                    |
| Macos            | Firefox        | :x:                |                                                                                                                                                                                                                    |
| Macos            | Safari         | :heavy_check_mark: | All urls are opened except that one additional empty tab is opened.                                                                                                                                                |
| Windows          | Brave          | :white_check_mark: |                                                                                                                                                                                                                    |
| Windows          | Chrome         | :white_check_mark: |                                                                                                                                                                                                                    |
| Windows          | Chromium       | :x:                |                                                                                                                                                                                                                    |
| Windows          | Edge           | :white_check_mark: |                                                                                                                                                                                                                    |
| Windows          | Firefox        | :warning:          | Normal mode - opens in 2 windows : n - 1 urls in a window and 1 url in another window; Incognito - Opens n - 1 urls in a normal window and only 1 url in a new incognito window                                    |

:white_check_mark: - Fully functional.  
:heavy_check_mark: - Mostly functional with some minor caveats.  
:warning: - Partly functional with some caveats.  
:x: - Not functional.