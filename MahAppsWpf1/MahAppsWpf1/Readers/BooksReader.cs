// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Actify" file="BooksReader.cs">
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
//   The reader for the books csv file
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable ArrangeThisQualifier
namespace MahAppsWpf1.Readers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.IO;
    using System.Linq;
    using System.Text;

    using CsvHelper;
    using NLog;

    using MahAppsWpf1.Interfaces;

    [Export(typeof(IFileTypeReader))]
    public class BooksReader : IFileTypeReader
    {

        //// implementation of IFileTypeReader

        public string FileExtensions => _fileExtensions;

        public string FileTypeName => _fileFormatName;

        public string PreviousFilePath => previousFilePath;

        public string PreviousFileName => previousFileName;


        public IFileData ReadFile(string fileName, out bool readOk, out string failMessage)
        {
            IFileData fileData = null;

            // worked successfully - save the paths and return
            this.previousFilePath = Path.GetDirectoryName(fileName);
            this.previousFileName = fileName;
            Properties.Settings.Default.BooksFilePath = previousFilePath;
            Properties.Settings.Default.BooksFileName = previousFileName;
            Properties.Settings.Default.Save();
            readOk = true;
            failMessage = "";

            return fileData;
        }

        //// local data

        private readonly string _fileExtensions = @"All files (*.*)|*.*|CSV Files (*.csv)|*.csv";
        private readonly string _fileFormatName = "Books csv file";
        private string previousFilePath;
        private string previousFileName;

        //// static data
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        //// Constructor

        public BooksReader()
        {
            Logger.Trace("Creating BooksReader");

            // set up the file paths from the settings
            previousFilePath = Properties.Settings.Default.BooksFilePath;
            previousFileName = Properties.Settings.Default.BooksFileName;
        }
    }
}
