// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Actify" file="MainModel.cs">
//   The information contained herein is confidential and proprietary to
//   Actify, Inc., and considered a trade secret as defined under
//   civil and criminal statutes.Actify, Inc.shall pursue its civil
//   and criminal remedies in the event of unauthorized use or misappropriation
//   of its trade secrets.Use of this information by anyone other than
//   authorized employees of Actify, Inc. is granted only under a
//   written non-disclosure agreement, expressly prescribing the scope and
//   manner of such use.
// </copyright>
// <summary>
//   This the main data model for the books read app
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable ArrangeThisQualifier
namespace MahAppsWpf1.Models
{
    using System.Collections.ObjectModel;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Linq;
    using System.Reflection;

    using Interfaces;

    using NLog;

    public class MainModel
    {
        /// <summary>
        /// Uses MEF to load the importers & then keeps a list of the items
        /// </summary>
        public MainModel()
        {

            Logger.Trace("Creating MainModel");

            // bootstrap MEF - search our executing assembly
            using (var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly()))
            {
                var container = new CompositionContainer(catalog);

                // Fill the imports of this object
                container.ComposeParts(this);
            }

            Logger.Trace("Number of file readers = {0}", 
                FileReaders?.LongCount().ToString() ?? "null");

            if (FileReaders != null && FileReaders.Count != 0) SelectedFileReader = FileReaders[0];

            BooksRead = new ObservableCollection<IBookRead>();
        }
        
        //// static data
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets or sets the file readers.
        /// </summary>
        [ImportMany(typeof(IFileTypeReader))]
        public ObservableCollection<IFileTypeReader> FileReaders { get; set; }

        public IFileTypeReader SelectedFileReader { get; set; }

        public ObservableCollection<IBookRead> BooksRead { get; private set; }

        public bool ReadFile(string fileName, out string failMessage)
        {
            bool readOk;
            IFileData fileData = SelectedFileReader.ReadFile(fileName, out readOk, out failMessage);
            if (readOk)
            {
                if (fileData is IBooksFileData)
                {
                    BooksRead.Clear();
                    foreach (var book in (fileData as IBooksFileData).BooksRead)
                    {
                        BooksRead.Add(book);
                    }
                    Logger.Trace("Read in {0} Books", BooksRead.Count);
                }
            }

            return readOk;
        }
    }
}
