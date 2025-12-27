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

- --path
- --browser
- --incognito

### Usage examples

- ./batchie-tab
- ./batchie-tab --incognito
- ./batchie-tab --path <path-to-file> --incognito
- ./batchie-tab --path <path-to-file> --browser chrome --incognito

### Implementation status

| Operating system | Browser               | Status  |
|------------------|-----------------------|---------|
| Linux            | Brave                 | ❌      |
| Linux            | Chromium              | ❌      |
| Linux            | Firefox               | ⚠️      |
| Linux            | Google chrome         | ✅      |
| Macos            | Brave                 | ❌      |
| Macos            | Chromium              | ❌      |
| Macos            | Firefox               | ❌      |
| Macos            | Google chrome         | ✅      |
| Windows          | Brave                 | ❌      |
| Windows          | Chromium              | ❌      |
| Windows          | Firefox               | ❌      |
| Windows          | Google chrome         | ❌      |
