// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Actify" file="IBooksFileData.cs">
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
//   This is an interface for a set of books read in from a file
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace MahAppsWpf1.Interfaces
{
    using System.Collections.Generic;
    using System.Windows.Documents;

    /// <summary>
    /// This is an interface for any data read in 
    /// </summary>
    public interface IBooksFileData : IFileData
    {
        /// <summary>
        /// Gets the books read.
        /// </summary>
        IList<IBookRead> BooksRead { get; }
    }
}
