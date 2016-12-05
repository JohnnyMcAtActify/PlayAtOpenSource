// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Actify" file="BooksFileData.cs">
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
//   This is a class for a set of books read in from a file
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace MahAppsWpf1.Models
{
    using System.Collections.Generic;

    using Interfaces;

    /// <summary>
    /// The books file data.
    /// </summary>
    public class BooksFileData : IBooksFileData
   {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooksFileData"/> class.
        /// </summary>
        public BooksFileData()
        {
            this.BooksRead = new List<IBookRead>();
        }

        /// <summary>
        /// Gets or sets the books read list.
        /// </summary>
        public IList<IBookRead> BooksRead { get; set; }
    }
}
