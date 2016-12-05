// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Actify" file="IBookRead.cs">
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
    using System;

    /// <summary>
    /// This is an interface for a book read in 
    /// </summary>
    public enum BookFormat
    {
        /// <summary>
        /// Physical book, words and pages.
        /// </summary>
        Book = 1,

        /// <summary>
        /// Pictures and text bubbles.
        /// </summary>
        Comic = 2,

        /// <summary>
        /// Was read it aloud.
        /// </summary>
        Audio = 3
    }

    /// <summary>
    /// This is an interface for a book read in 
    /// </summary>
    public interface IBookRead
    {
        /// <summary>
        /// Gets or sets the string for the date the book was read
        /// </summary>
        string DateString { get; set; }

        /// <summary>
        /// Gets or sets the date the book was read
        /// </summary>
        DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the author(s) of the book
        /// </summary>
        string Author { get; set; }

        /// <summary>
        /// Gets or sets the title of the book
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the number of pages in the book
        /// </summary>
        ushort Pages { get; set; }

        /// <summary>
        /// Gets or sets any special notes about the book
        /// </summary>
        string Note { get; set; }

        /// <summary>
        /// Gets or sets the nation the author of the book was from
        /// </summary>
        string Nationality { get; set; }

        /// <summary>
        /// Gets or sets the language the book was originally written in
        /// </summary>
        string OriginalLanguage { get; set; }

        /// <summary>
        /// Gets or sets the 'x' that says this is a book
        /// </summary>
        string Book { get; set; }

        /// <summary>
        /// Gets or sets the 'x' that says this is a comic
        /// </summary>
        string Comic { get; set; }

        /// <summary>
        /// Gets or sets the 'x' that says this is an audio recording of the book
        /// </summary>
        string Audio { get; set; }

        /// <summary>
        /// Gets or sets the book format 
        /// </summary>
        BookFormat Format { get; set; }
    }
}
