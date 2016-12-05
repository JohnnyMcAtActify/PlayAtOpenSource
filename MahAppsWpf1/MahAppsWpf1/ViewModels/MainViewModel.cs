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

namespace MahAppsWpf1.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using MahAppsWpf1.Interfaces;

    using NLog;

    using MahAppsWpf1.Models;

    /// <summary>
    /// The Main View Model - links the top level view to the code.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class. 
        /// The constructor for the View Model.
        /// </summary>
        public MainViewModel()
        {
            _logger.Trace("Creating Main View Model");
            mainModel = new MainModel();
        }

        #region INotifyPropertyChanged Members

        void OnPropertyChanged<T>(Expression<Func<T>> sExpression)
        {
            if (sExpression == null) throw new ArgumentNullException("sExpression");

            MemberExpression body = sExpression.Body as MemberExpression;
            if (body == null)
            {
                throw new ArgumentException("Body must be a member expression");
            }
            OnPropertyChanged(body.Member.Name);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members

        #region Private static

        /// <summary>
        /// The _logger for the View Model.
        /// </summary>
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        /// <summary>
        /// The main data model (includes the data readers).
        /// </summary>
        private MainModel mainModel;

        //// public items for binding to 

        /// <summary>
        /// Gets the file readers.
        /// </summary>
        public ObservableCollection<IFileTypeReader> FileReaders => this.mainModel.FileReaders;
    }
}
