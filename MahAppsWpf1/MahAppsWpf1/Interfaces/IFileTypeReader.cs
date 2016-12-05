// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Actify" file="IFileTypeReader.cs">
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
//   This is an interface for a book read in
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace MahAppsWpf1.Interfaces
{
    /// <summary>
    /// This is an interface for the file readers 
    /// </summary>
    public interface IFileTypeReader
    {
        /// <summary>
        /// Gets the name of the file format.
        /// </summary>
        string FileTypeName { get; }

        /// <summary>
        /// Gets the extensions for the files that this reads.
        /// </summary>
        string FileExtensions { get; }

        /// <summary>
        /// Gets the path of for the last file that was read.
        /// </summary>
        string PreviousFilePath { get; }

        /// <summary>
        /// Gets the name of for the last file that was read.
        /// </summary>
        string PreviousFileName { get; }

        /// <summary>
        /// Reads a particular file format.
        /// </summary>
        /// <param name="fileName">The file to read.</param>
        /// <param name="readOk">Flag set to true if read ok.</param>
        /// <param name="failMessage">The error message if failed, empty otherwise.</param>
        /// <returns>The data from the files converted to classes</returns>
        IFileData ReadFile(string fileName, out bool readOk, out string failMessage);
    }
}
