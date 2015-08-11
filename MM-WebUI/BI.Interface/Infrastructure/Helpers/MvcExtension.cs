// ***********************************************************************
// Assembly         : BI.Auxiliary.Web
// Author           : Anugoon Leelaphattarkij
// Created          : 04-17-2015
//
// Last Modified By : Anugoon Leelaphattarkij
// Last Modified On : 05-27-2015
// ***********************************************************************
// <copyright file="MvcExtensions.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Extensions for assist ASP.Net MVC development.</summary>
// ***********************************************************************
using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace BI.Interface.Infrastructure.Helpers
{
    /// <summary>
    /// Extensions for assist ASP.Net MVC development.
    /// </summary>
    public static class MvcExtensions
    {
        /// <summary>
        /// Populates the SelectList from enumerable type.
        /// </summary>
        /// <typeparam name="TEnum">IComparable, IFormattable, IConvertible based enumerable type.</typeparam>
        /// <param name="enumObj">The enumerable object.</param>
        /// <returns>SelectList.</returns>
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
           where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                         select new { Id = e, Name = e.ToString(CultureInfo.CurrentCulture) };
            return new SelectList(values, "Id", "Name", enumObj);
        }
    }
}