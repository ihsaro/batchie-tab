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

- --path <path-to-file>
- --browser <browser-name> (possible values : chrome, chromium, firefox)
- --incognito

### Usage examples

- ./batchie-tab
- ./batchie-tab --incognito
- ./batchie-tab --path <path-to-file> --incognito
- ./batchie-tab --path <path-to-file> --browser chrome --incognito

### Implementation status

| Operating system | Browser               | Status             |
|------------------|-----------------------|--------------------|
| Linux            | Brave                 | :x:                |
| Linux            | Chromium              | :x:                |
| Linux            | Firefox               | :warning:          |
| Linux            | Google chrome         | :white_check_mark: |
| Macos            | Brave                 | :x:                |
| Macos            | Chromium              | :x:                |
| Macos            | Firefox               | :x:                |
| Macos            | Google chrome         | :white_check_mark: |
| Windows          | Brave                 | :x:                |
| Windows          | Chromium              | :x:                |
| Windows          | Firefox               | :x:                |
| Windows          | Google chrome         | :x:                |
