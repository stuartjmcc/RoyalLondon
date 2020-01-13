using CustomerClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrivingApplication
{
    public partial class SingleForm : Form
    {
        // Application Properties
        public string BodyTemplateLocation { get; set; }
        public string SourceFileLocation { get; set; }
        public string OutputFolderLocation { get; set; }

        public string StatusInformation { get; set; }

        public SingleForm()
        {
            InitializeComponent();
        }

        #region "Form Events"
        private void SingleForm_Load(object sender, EventArgs e)
        {
            SetProperties();
            UpdateUIElements();
        }

        private void inputBodyTemplateButton_Click(object sender, EventArgs e)
        {
            SetBodyTemplateLocation();
        }

        private void inputSetSourceFileButton_Click(object sender, EventArgs e)
        {
            SetSourceFileLocation();
        }

        private void outputSetResultsFolderButton_Click(object sender, EventArgs e)
        {
            SetOutputFolderLocation();
        }

        private void createOutputButton_Click(object sender, EventArgs e)
        {
            StartProcess();
        }
        #endregion "Form Events"


        #region "Private Functions"
        /// <summary>
        /// Sets the class properties to default values from the Form load event
        /// </summary>
        private void SetProperties()
        {
            // No mention of retrieving previous settings in spec so not implementing that functionality.
            BodyTemplateLocation = "<NOT SET>";
            SourceFileLocation = "<NOT SET>";
            OutputFolderLocation = "<NOT SET>";
            StatusInformation = "";
        }

        /// <summary>
        /// Get path and filename of the Template and update the UI if necessary
        /// </summary>
        private void SetBodyTemplateLocation()
        {
            if (openBodyTemplateFileDialog.ShowDialog() == DialogResult.OK)
            {
                BodyTemplateLocation = openBodyTemplateFileDialog.FileName;
                UpdateUIElements();
            }
        }

        /// <summary>
        /// Get path and filename of the Source input file and update the UI if necessary
        /// </summary>
        private void SetSourceFileLocation()
        {
            if (openSourceFileDialog.ShowDialog() == DialogResult.OK)
            {
                SourceFileLocation = openSourceFileDialog.FileName;
                UpdateUIElements();
            }
        }

        /// <summary>
        /// Get path and filename of the results output folder and update the UI if necessary
        /// </summary>
        private void SetOutputFolderLocation()
        {
            if (outputResultsFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                OutputFolderLocation = outputResultsFolderBrowserDialog.SelectedPath;
                UpdateUIElements();
            }
        }

        /// <summary>
        /// Update all elements of the UI as it is so simple
        /// NOTE: This should be in it's own thread to accomodate user feedback as ths CSV file is parsed
        /// </summary>
        private void UpdateUIElements()
        {
            inputBodyTemplateLabel.Text = BodyTemplateLocation;
            inputSourceFileDisplayLabel.Text = SourceFileLocation;
            outputResultsFolderLabel.Text = OutputFolderLocation;
            toolStripStatusLabel.Text = StatusInformation;
        }

        /// <summary>
        /// Validate the inputs, extract the data and output the results
        /// ASSUMPTION: The output folder may not be empty when the process starts. 
        /// As a customer body file is not written if it already exists I am assuming the application will be running
        /// against multiple CSV files to build up a single set of body text files.
        /// </summary>
        private void StartProcess()
        {
            StatusInformation = "Starting Process";
            UpdateUIElements();

            CustomerHandler CustomerList = new CustomerHandler();

            RecordListStatus recordListStatus = CustomerList.IsValid(BodyTemplateLocation, SourceFileLocation, OutputFolderLocation);
            switch (recordListStatus)
            {
                case RecordListStatus.OK:
                    {
                        // Process Records - TBD
                        CustomerList.ProcessFile(BodyTemplateLocation, SourceFileLocation, OutputFolderLocation);
                        StatusInformation = "Process Complete";
                    }
                    break;
                case RecordListStatus.BAD_TEMPLATE:
                    StatusInformation = "The body template is missing or invalid";
                    break;
                case RecordListStatus.BAD_SOURCEFILE:
                    StatusInformation = "The source file is missing or invalid";
                    break;
                case RecordListStatus.OUTPUT_ERROR:
                    StatusInformation = "The output folder is missing";
                    break;
                default:
                    StatusInformation = "Unknown Error";
                    break;
            }
            UpdateUIElements();
        }



        #endregion "Private Functions"

    }
}
