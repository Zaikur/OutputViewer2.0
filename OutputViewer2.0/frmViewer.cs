using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OutputViewer2._0
{
    public partial class frmViewer : Form
    {
        public frmViewer()
        {
            InitializeComponent();
        }

        // Declare variables for filepath
        private string? iniFilePath;
        private int maxRows;
        private int boardMMTally = 0;
        private string boardFeetTally = "";
        private int partCount = 0;

        //Declare the _debounceTimer variable and list of cut objects for the gridviewer
        private System.Threading.Timer _debounceTimer;
        private BindingList<Cut> cutList = new BindingList<Cut>();

        private void frmViewer_Load(object sender, EventArgs e)
        {
            //Set gridviewer datasource
            LoadSettings();

            try
            {
                // Create FileSystemWatcher object and set its properties
                var watcher = new FileSystemWatcher(Path.GetDirectoryName(iniFilePath), Path.GetFileName(iniFilePath))
                {
                    EnableRaisingEvents = true,
                    NotifyFilter = NotifyFilters.LastWrite
                };

                // Register event handler to handle file changes
                watcher.Changed += (sender, e) =>
                {
                    // Use the Debounce method to delay the execution of the PopulateIniDataGrid method by 100 milliseconds
                    Debounce(PopulateCutList, 100);
                };

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Select a valid filepath");
                SetFilePath();
            }

        }

        //.ini file line extraction
        private void PopulateCutList()
        {
            //Reads .ini file using WriteSafeReadAllLines Method, and extracts data to an array
            var iniFileLines = WriteSafeReadAllLines(iniFilePath);

            Cut cut = new Cut();
            var passLength = "";

            foreach (var line in iniFileLines)
            {

                (string key, string value) = KeyValue(line);

                switch (key)
                {
                    case "": break;

                    case "BvNr": //Job
                        cut.Job = value; break;

                    case "Name":  //Name
                        cut.Name = value; break;

                    case "Paket":   //Part
                        cut.Part = value; break;

                    case "Laenge":  //Length
                        passLength = value;
                        cut.Length = Convert(value); break;

                    case "QuY":     //Width
                        cut.Width = Convert(value); break;

                    case "QuZ":     //Height
                        cut.Height = Convert(value); break;

                    case "SK":  //Grade
                        cut.Grade = value; break;

                    case "Ausstosser":  //Stack
                        cut.Stack = value; break;

                    default: break;
                }
            }

            if (cut != null)
            {
                //If rowcount is greater than maxRows
                if (cutList.Count > maxRows)
                {
                    while (cutList.Count > maxRows)
                    {
                        //Delete object at index[0]
                        this.Invoke(new Action(() => { cutList.RemoveAt(0); }));
                    }
                }
                this.Invoke(new Action(() => { cutList.Add(cut); }));

                UpdateTally(cut.Stack, passLength);
            }
        }

        //KeyValue method accepts a string and returns a tuple of the specified key and value from that line
        private (string key, string value) KeyValue(string line)
        {
            //Attempt to extract the key and value
            var keyValuePair = Regex.Match(line, @"^(?<key>.+?)\s*=\s*(?<value>.+?)$");
            string key, value;

            if (keyValuePair.Success)
            {
                key = keyValuePair.Groups["key"].Value;
                value = keyValuePair.Groups["value"].Value;

                return (key, value);
            }
            else
            {
                //Return "" to end case early
                key = "";
                value = "";
                return (key, value);
            }
        }

        // Convert method converts mm to feet-inches-sixteenths
        private string Convert(string imperial)
        {
            // Copy string from imperial variable
            double.TryParse(imperial, out double value);

            // Perform calculation to get feet-inches-sixteenths
            var inches = (value / 25.4);
            var feet = (inches / 12);

            var feetInt = (int)feet;
            var inchesInt = (int)((feet - feetInt) * 12);
            var sixteenthsInt = (int)((inches - (feetInt * 12) - inchesInt) * 16);

            imperial = feetInt.ToString() + "-" + inchesInt.ToString() + "-" + sixteenthsInt.ToString() + "";

            return imperial;
        }

        //UpdateTally method updates the part count and board feet
        private void UpdateTally(string stack, string length)
        {
            //Parse the stack
            int.TryParse(stack, out int value);

            //Add stack count to the partCount
            partCount += value;

            //Parse the length, multiply by stack, add to board tally
            int.TryParse(length, out int valueMm);
            valueMm = value * valueMm;
            boardMMTally += valueMm;
            boardFeetTally = Convert(boardMMTally.ToString());

            UpdateLabels();
        }

        //UpdateLabels method updates the labels to display the new part count and board feet
        private void UpdateLabels()
        {
            //update the counts
            this.Invoke(new Action(() => { lblBoardFeet.Text = boardFeetTally + " feet"; }));
            this.Invoke(new Action(() => { lblDailyPartCount.Text = partCount.ToString(); }));
        }


        private void SetFilePath()
        {
            // Create new openFileDialog object
            var openFileDialog = new OpenFileDialog
            {
                // File type filters for openFileDialog and set default directory to MyDocuments
                Filter = "INI files (*.ini)|*.ini|All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            // If Successful
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Save the new filepath
                iniFilePath = openFileDialog.FileName;
                Properties.Settings.Default.FilePath = iniFilePath;
                Properties.Settings.Default.Save();
            }
        }

        // Debounce method delays watcher to avoid PopulateIniDataGrid method from being called when the        
        // application reads the file (otherwise this triggers the watcher)
        private void Debounce(Action action, int milliseconds)
        {
            // Cancel any pending debounced actions
            _debounceTimer?.Dispose();

            // Execute the given action after the specified amount of time
            _debounceTimer = new System.Threading.Timer(
                _ => action(),
                null,
                milliseconds,
                Timeout.Infinite
            );
        }

        // LoadSettings method restores last user settings from the settings file
        private void LoadSettings()
        {
            //Load last window size and location
            Height = Properties.Settings.Default.MainFormHeight;
            Width = Properties.Settings.Default.MainFormWidth;
            Location = Properties.Settings.Default.MainFormLocation;

            //Load last font selection for cells
            dgvSawOutput.DefaultCellStyle.Font = Properties.Settings.Default.Font;

            //Load max rows
            maxRows = Properties.Settings.Default.rowsToKeep;

            //Load last used file path and bind it to the Grid Viewer
            iniFilePath = Properties.Settings.Default.FilePath;
            dgvSawOutput.DataSource = cutList;

            //Load font
            dgvSawOutput.DefaultCellStyle.Font = Properties.Settings.Default.Font;
        }

        // SaveSettings method saves current form settings
        private void SaveSettings()
        {
            // Save user font selections
            Properties.Settings.Default.Font = dgvSawOutput.DefaultCellStyle.Font;

            // Save user window size and location
            Properties.Settings.Default.MainFormHeight = Height;
            Properties.Settings.Default.MainFormWidth = Width;
            Properties.Settings.Default.MainFormLocation = Location;

            // Save last used FilePath
            Properties.Settings.Default.FilePath = iniFilePath;

            //Save max rows
            Properties.Settings.Default.rowsToKeep = maxRows;

            //Save Column widths
            Properties.Settings.Default.jobWidth = dgvSawOutput.Columns["Job"].Width;
            Properties.Settings.Default.stackWidth = dgvSawOutput.Columns["Stack"].Width;
            Properties.Settings.Default.nameWidth = dgvSawOutput.Columns["Name"].Width;
            Properties.Settings.Default.partWidth = dgvSawOutput.Columns["Part"].Width;
            Properties.Settings.Default.lengthWidth = dgvSawOutput.Columns["Length"].Width;
            Properties.Settings.Default.widthWidth = dgvSawOutput.Columns["Width"].Width;
            Properties.Settings.Default.heightWidth = dgvSawOutput.Columns["Height"].Width;
            Properties.Settings.Default.gradeWidth = dgvSawOutput.Columns["Grade"].Width;

            // Save all of the above
            Properties.Settings.Default.Save();
        }

        // WriteSafeReadAllLines method 
        private string[] WriteSafeReadAllLines(string path)
        {
            // Allow reading file when open/used by another application
            using (var csv = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(csv))
            {
                List<string> file = new List<string>();
                while (!sr.EndOfStream)
                {
                    //Add line to file Array
                    file.Add(sr.ReadLine());
                }

                //Copy the elements of the file array to a new array when returned
                return file.ToArray();
            }
        }

        private void frmViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void tsmSetFilePath_Click(object sender, EventArgs e)
        {
            SetFilePath();
        }

        private void tsmChangeFont_Click(object sender, EventArgs e)
        {
            // Set FontMustExist to true, which causes message box error
            // if the user enters a font that does not exist. 
            fontDialog1.FontMustExist = true;

            // Associate the method handling the Apply event with the event.
            fontDialog1.Apply += new System.EventHandler(FontDialog1_Apply);

            // Set a minimum and maximum size to be
            // shown in the FontDialog.
            fontDialog1.MaxSize = 32;
            fontDialog1.MinSize = 18;

            // Show the Apply button in the dialog.
            fontDialog1.ShowApply = true;

            // Save the existing font.
            System.Drawing.Font oldFont = this.Font;

            //Show the dialog, and get the result
            DialogResult result = fontDialog1.ShowDialog();

            // If the OK button in the Font dialog box is clicked, 
            // set all the controls' fonts to the chosen font by calling
            // the FontDialog1_Apply method.
            if (result == DialogResult.OK)
            {
                FontDialog1_Apply(this.AcceptButton, new System.EventArgs());
            }
            // If Cancel is clicked, set the font back to
            // the original font.
            else if (result == DialogResult.Cancel)
            {
                this.Font = oldFont;
                foreach (Control containedControl in this.Controls)
                {
                    containedControl.Font = oldFont;
                }
            }
        }

        private void FontDialog1_Apply(object sender, System.EventArgs e)
        {
            dgvSawOutput.DefaultCellStyle.Font = fontDialog1.Font;

            Properties.Settings.Default.Font = fontDialog1.Font;
            Properties.Settings.Default.Save();
        }

        private void maxRowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create a new instance of the frmMaxRows and execute the GetMax method from that form
            frmMaxRows editMax = new frmMaxRows();
            int max = editMax.GetMax(maxRows);

            if (max != 0)
            {
                maxRows = max;

                Properties.Settings.Default.rowsToKeep = (int)max;
                Properties.Settings.Default.Save();
            }
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            //Close the form and end the application
            this.Close();
        }

        private void dgvSawOutput_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //After databinding is complete, set the column widths
            dgvSawOutput.Columns["Job"].Width = Properties.Settings.Default.jobWidth;
            dgvSawOutput.Columns["Stack"].Width = Properties.Settings.Default.stackWidth;
            dgvSawOutput.Columns["Name"].Width = Properties.Settings.Default.nameWidth;
            dgvSawOutput.Columns["Part"].Width = Properties.Settings.Default.partWidth;
            dgvSawOutput.Columns["Length"].Width = Properties.Settings.Default.lengthWidth;
            dgvSawOutput.Columns["Width"].Width = Properties.Settings.Default.widthWidth;
            dgvSawOutput.Columns["Height"].Width = Properties.Settings.Default.heightWidth;
            dgvSawOutput.Columns["Grade"].Width = Properties.Settings.Default.gradeWidth;
        }

        private void brnResetPartCount_Click(object sender, EventArgs e)
        {
            partCount = 0;
            UpdateLabels();
        }

        private void btnResetBoardFeet_Click(object sender, EventArgs e)
        {
            boardFeetTally = "0";
            UpdateLabels();
        }
    }
}