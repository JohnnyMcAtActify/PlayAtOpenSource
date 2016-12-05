// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Actify" file="SimpleBookRead.cs">
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
//   This the simple implementation for a book read
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable ArrangeThisQualifier
namespace MahAppsWpf1.Models
{
    using System;

    using Interfaces;

    /// <summary>
    /// The simple book read.
    /// </summary>
    public class SimpleBookRead : IBookRead
    {
        //// local data

        /// <summary>
        /// The is book.
        /// </summary>
        private string isBook;

        /// <summary>
        /// The is comic.
        /// </summary>
        private string isComic;

        /// <summary>
        /// The is audio.
        /// </summary>
        private string isAudio;

        /// <summary>
        /// The book format.
        /// </summary>
        private BookFormat bookFormat;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleBookRead"/> class. 
        /// The creates a simple book read defaulted to a book.
        /// </summary>
        /// Constructor
        public SimpleBookRead()
        {
            this.Format = BookFormat.Book;
        }

        //// implementation of IBookRead

        /// <summary>
        /// Gets or sets the string for the date the book was read
        /// </summary>
        public string DateString { get; set; }

        /// <summary>
        /// Gets or sets the date the book was read
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the author(s) of the book
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the title of the book
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the number of pages in the book
        /// </summary>
        public ushort Pages { get; set; }

        /// <summary>
        /// Gets or sets any special notes about the book
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the nation the author of the book was from
        /// </summary>
        public string Nationality { get; set; }

        /// <summary>
        /// Gets or sets the language the book was originally written in
        /// </summary>
        public string OriginalLanguage { get; set; }

        /// <summary>
        /// Gets or sets the 'x' that says this is a book
        /// </summary>
        public string Book
        {
            get
            {
                return this.isBook;
            }

            set
            {
                this.isBook = value;
                if (!string.IsNullOrEmpty(this.isBook))
                {
                    this.Format = BookFormat.Book;
                }
            }
        }

        /// <summary>
        /// Gets or sets the 'x' that says this is a comic
        /// </summary>
        public string Comic
        {
            get
            {
                return this.isComic;
            }

            set
            {
                this.isComic = value;
                if (!string.IsNullOrEmpty(this.isComic))
                {
                    this.Format = BookFormat.Comic;
                }
            }
        }

        /// <summary>
        /// Gets or sets the 'x' that says this is an audio recording of the book
        /// </summary>
        public string Audio
        {
            get
            {
                return this.isAudio;
            }

            set
            {
                this.isAudio = value;
                if (!string.IsNullOrEmpty(this.isAudio))
                {
                    this.Format = BookFormat.Audio;
                }
            }
        }

        /// <summary>
        /// Gets or sets the book format 
        /// </summary>
        public BookFormat Format
        {
            get
            {
                return this.bookFormat;
            }

            set
            {
                this.bookFormat = value;
                switch (this.bookFormat)
                {
                    case BookFormat.Book:
                        this.isBook = "x";
                        this.isComic = this.isAudio = string.Empty;
                        break;
                    case BookFormat.Audio:
                        this.isAudio = "x";
                        this.isBook = this.isComic = string.Empty;
                        break;
                    case BookFormat.Comic:
                        this.isComic = "x";
                        this.isBook = this.isAudio = string.Empty;
                        break;
                }
            }
        }
    }
}
