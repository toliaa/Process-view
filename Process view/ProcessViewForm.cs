using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ProcessManager
{
    public partial class ProcessViewForm : Form
    {
        public ProcessViewForm()
        {
            InitializeComponent();
            LoadProcesses(); // Load processes when the form is initialized
        }

        // Method to load and display all running processes in the ListView
        private void LoadProcesses()
        {
            listView1.Items.Clear(); // Clear existing items
            Process[] processes = Process.GetProcesses(); // Get all running processes
            foreach (Process process in processes)
            {
                ListViewItem item = new ListViewItem(process.ProcessName); // Create a new item with the process name
                item.SubItems.Add(process.Id.ToString()); // Add the process ID as a subitem
                item.SubItems.Add(process.MainWindowTitle); // Add the main window title as a subitem
                item.Tag = process; // Store the process object in the item's tag
                listView1.Items.Add(item); // Add the item to the ListView
            }
        }

        // Event handler for the Refresh button click event
        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadProcesses(); // Reload the process list
        }

        // Event handler for the Export button click event
        private void exportButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) // Show the Save File dialog
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName)) // Open a stream to write to the selected file
                {
                    foreach (ListViewItem item in listView1.Items) // Iterate over all items in the ListView
                    {
                        sw.WriteLine($"{item.Text}, {item.SubItems[1].Text}, {item.SubItems[2].Text}"); // Write process details to the file
                    }
                }
            }
        }

        // Event handler for right-click on the ListView
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && listView1.FocusedItem.Bounds.Contains(e.Location))
            {
                contextMenuStrip1.Show(Cursor.Position); // Show the context menu at the mouse position
            }
        }

        // Event handler for the Show Info context menu item click event
        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Process selectedProcess = (Process)listView1.SelectedItems[0].Tag; // Get the selected process
                MessageBox.Show($"Process Name: {selectedProcess.ProcessName}\n" +
                                $"ID: {selectedProcess.Id}\n" +
                                $"Start Time: {selectedProcess.StartTime}\n" +
                                $"Total Processor Time: {selectedProcess.TotalProcessorTime}",
                                "Process Information", MessageBoxButtons.OK, MessageBoxIcon.Information); // Show process information
            }
        }

        // Event handler for the Kill Process context menu item click event
        private void killProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Process selectedProcess = (Process)listView1.SelectedItems[0].Tag; // Get the selected process
                try
                {
                    selectedProcess.Kill(); // Attempt to kill the process
                    MessageBox.Show("Process terminated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // Show success message
                    LoadProcesses(); // Reload the process list
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to terminate process: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message if killing the process fails
                }
            }
        }

        // Event handler for the Show Threads and Modules context menu item click event
        private void showThreadsAndModulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Process selectedProcess = (Process)listView1.SelectedItems[0].Tag; // Get the selected process
                string info = $"Threads:\n";
                foreach (ProcessThread thread in selectedProcess.Threads) // Get and display all threads of the process
                {
                    info += $"ID: {thread.Id}, State: {thread.ThreadState}\n";
                }
                info += "\nModules:\n";
                foreach (ProcessModule module in selectedProcess.Modules) // Get and display all modules of the process
                {
                    info += $"Name: {module.ModuleName}, Path: {module.FileName}\n";
                }
                MessageBox.Show(info, "Threads and Modules Information", MessageBoxButtons.OK, MessageBoxIcon.Information); // Show threads and modules information
            }
        }

        private void ProcessViewForm_Load(object sender, EventArgs e)
        {

        }
    }
}
