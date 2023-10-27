# Todo application

This is a minimalist command-line TODO application that integrates with Trello. Easily add tasks to your Trello board directly from your terminal.

## Features

- Add tasks to a specific Trello board and list.
- Configuration via a YAML file located in your home directory.
- Extensible design to potentially support other services/formats in the future.

## Alias

It can be nice to add a PowerShell alias:

`Set-Alias todo -Value "E:\..\Todo.CLI\bin\Release\net8.0\Todo.CLI.exe"`

This will allow a simple usage:

`todo \"Get food\"`