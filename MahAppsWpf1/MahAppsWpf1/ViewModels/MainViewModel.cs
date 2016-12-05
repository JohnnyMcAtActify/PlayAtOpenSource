// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Actify" file="MainViewModel.cs">
//
//   The information contained herein is confidential and proprietary to
//   Actify, Inc., and considered a trade secret as defined under
//   civil and criminal statutes.Actify, Inc.shall pursue its civil
//   and criminal remedies in the event of unauthorized use or misappropriation
//   of its trade secrets.Use of this information by anyone other than
//   authorized employees of Actify, Inc. is granted only under a
//   written non-disclosure agreement, expressly prescribing the scope and
//   manner of such use.
//
// </copyright>
// <summary>
//   The Main View Model - links the top level view to the data
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable ArrangeThisQualifier
namespace MahAppsWpf1.ViewModels
{
    using System.Collections.ObjectModel;

    using NLog;

    using Models;
    using Interfaces;

    using MessageBox = System.Windows.MessageBox;
    using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

    /// <summary>
    /// The Main View Model - links the top level view to the code.
    /// </summary>
    public class MainViewModel
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class. 
        /// The constructor for the View Model.
        /// </summary>
        public MainViewModel()
        {
            Logger.Trace("Creating Main View Model");
            mainModel = new MainModel();
            IsLoading = false;
        }
        

        #region Private static

        /// <summary>
        /// The Logger for the View Model.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        /// <summary>
        /// The main data model (includes the data readers).
        /// </summary>
        private MainModel mainModel;

        //// public items for binding to 

        /// <summary>
        /// Gets the file readers.
        /// </summary>
        public ObservableCollection<IFileTypeReader> FileReaders => mainModel.FileReaders;

        public IFileTypeReader SelectedFileReader
        {
            get
            {
                return mainModel.SelectedFileReader;
                    
            }
            set
            {
                mainModel.SelectedFileReader = value;
            }
        }

        public ObservableCollection<IBookRead> BooksRead => mainModel.BooksRead;

        public bool IsLoading { get; set; }

        public void LoadFileType()
        {
            Logger.Trace("Called LoadFileType");

            if (SelectedFileReader == null)
            {
                MessageBox.Show("No File type selected");
                return;
            }
            Logger.Trace("SelectedFileReader = {0} \n previous Path = {1}, previous file {2}", 
                SelectedFileReader.FileTypeName, 
                SelectedFileReader.PreviousFilePath, 
                SelectedFileReader.PreviousFileName);

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.FileName = SelectedFileReader.PreviousFileName;

            fileDialog.Filter = SelectedFileReader.FileExtensions;
            fileDialog.FilterIndex = 4;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == true)
            {

                IsLoading = true;
                string failMessage;
                if (!mainModel.ReadFile(fileDialog.FileName, out failMessage))
                {
                    IsLoading = false;
                    MessageBox.Show("Failed with message {0}", failMessage);
                }
                IsLoading = false;

            }

        }
    }
}
