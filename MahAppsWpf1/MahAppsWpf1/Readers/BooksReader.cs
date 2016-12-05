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
    using System.ComponentModel.Composition;
    using System.Globalization;
    using System.IO;
    using System.Text;

    using CsvHelper;
    using NLog;

    using Interfaces;
    using Models;

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
            IBooksFileData fileData = new BooksFileData();

            if (!ReadFromFile(fileName, ref fileData, out failMessage))
            {
                readOk = false;
                return null;
            }

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

        //// private methods

        private bool ReadFromFile(string filename, ref IBooksFileData fileData, out string failMessage)
        {
            failMessage = string.Empty;
            try
            {
                using (var sr = new StreamReader(filename, Encoding.Default))
                {
                    var csv = new CsvReader(sr);

                    fileData.BooksRead.Clear();

                    // Date,DD/MM/YYYY,Author,Title,Pages,Note,Nationality,Original Language,Book,Comic,Audio
                    while (csv.Read())
                    {
                        var stringFieldDate = csv.GetField<string>(0);
                        // ReSharper disable once InconsistentNaming
                        var stringFieldDDMMYYYY = csv.GetField<string>(1);
                        var stringFieldAuthor = csv.GetField<string>(2);
                        var stringFieldTitle = csv.GetField<string>(3);
                        var stringFieldPages = csv.GetField<string>(4);
                        var stringFieldNote = csv.GetField<string>(5);
                        var stringFieldNationality = csv.GetField<string>(6);
                        var stringFieldOriginalLanguage = csv.GetField<string>(7);
                        var stringFieldBook = csv.GetField<string>(8);
                        var stringFieldComic = csv.GetField<string>(9);
                        var stringFieldAudio = csv.GetField<string>(10);

                        DateTime dateForBook;
                        if (DateTime.TryParseExact(stringFieldDDMMYYYY, "d/M/yyyy",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out dateForBook))
                        {
                            UInt16 pages;
                            UInt16.TryParse(stringFieldPages, out pages);
                            SimpleBookRead book = new SimpleBookRead
                            {
                                DateString = stringFieldDate,
                                Date = dateForBook,
                                Author = stringFieldAuthor,
                                Title = stringFieldTitle,
                                Pages = pages,
                                Note = stringFieldNote,
                                Nationality = stringFieldNationality,
                                OriginalLanguage = stringFieldOriginalLanguage,
                                Audio = stringFieldAudio,
                                Book = stringFieldBook,
                                Comic = stringFieldComic,
                            };

                            fileData.BooksRead.Add(book);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                failMessage = 
                    e.Message + "\n StackTrace = \n" + 
                    e.StackTrace + "\n InnerException = \n" +
                    e.InnerException;
            }

            return true;
        }
    }
}
