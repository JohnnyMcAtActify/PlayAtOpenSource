/*
 * Copyright (c) 1996 - Present by Actify, Inc.
 * The information contained herein is confidential and proprietary to
 * Actify, Inc., and considered a trade secret as defined under
 * civil and criminal statutes. Actify, Inc. shall pursue its civil
 * and criminal remedies in the event of unauthorized use or misappropriation
 * of its trade secrets. Use of this information by anyone other than
 * authorized employees of Actify, Inc. is granted only under a
 * written non-disclosure agreement, expressly prescribing the scope and
 * manner of such use.
 */
 
namespace MahAppsWpf1.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;
    using System.Linq.Expressions;


    /// <summary>
    /// The Main View Model - links the top level view to the code.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
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
    }
}
