// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Actify" file="CountriesReader.cs">
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
//   This reads in the list of countries and their capitals
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable ArrangeThisQualifier
namespace MahAppsWpf1.Readers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.ComponentModel.Composition;

    using CsvHelper;

    using MahAppsWpf1.Interfaces;

    using NLog;

    [Export(typeof(IFileTypeReader))]
    public class CountriesReader : IFileTypeReader
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
            Properties.Settings.Default.CountriesFilePath= previousFilePath;
            Properties.Settings.Default.CountriesFileName = previousFileName;
            Properties.Settings.Default.Save();
            readOk = true;
            failMessage = "";

            return fileData;
        }

        //// local data

        private readonly string _fileExtensions = @"All files (*.*)|*.*|CSV Files (*.csv)|*.csv";
        private readonly string _fileFormatName = "Countries csv file";
        private string previousFilePath;
        private string previousFileName;

        //// static data
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        //// Constructor
        public CountriesReader()
        {

            Logger.Trace("Creating CountriesReader");

            // set up the file paths from the settings
            this.previousFilePath = Properties.Settings.Default.CountriesFilePath;
            this.previousFileName = Properties.Settings.Default.CountriesFileName;
        }

    }
}
