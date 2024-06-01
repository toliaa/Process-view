# Process View

Process View is a Windows Forms application built using C#. This application allows users to view all running processes, gather information about them, terminate processes, and export process details to a text file. Additionally, it provides functionality to display threads and modules associated with a process.

## Features

- **View Running Processes**: Displays a list of all currently running processes.
- **Process Information**: Provides detailed information about a selected process, including its ID, start time, and total processor time.
- **Terminate Process**: Allows users to terminate a selected process.
- **Refresh Process List**: Refreshes the list of currently running processes.
- **Export Process List**: Exports the list of processes to a text file.
- **Threads and Modules**: Displays detailed information about threads and modules of a selected process.


## Getting Started

### Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/) with .NET Desktop Development workload installed.
- Windows operating system.

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/Process-view.git
    ```
2. Open the solution file (`Process view.sln`) in Visual Studio.
3. Build the solution to restore dependencies and compile the project.

### Usage

1. Run the application from Visual Studio by pressing `F5` or `Ctrl+F5`.
2. Use the Refresh button to update the list of running processes.
3. Right-click on a process to:
    - Show information about the process.
    - Terminate the process.
    - Show threads and modules associated with the process.
4. Use the Export button to save the list of processes to a text file.

## Code Structure

- **ProcessViewForm.cs**: Contains the main logic for loading, displaying, and managing processes.
- ***ProcessViewForm.Designer.cs**: Contains the designer-generated code for UI layout and component initialization.
- **Program.cs**: Entry point of the application, starting the `Form1` form.


## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.




