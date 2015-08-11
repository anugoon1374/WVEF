// ***********************************************************************
// Assembly         : BI.Core
// Author           : Anugoon Leelaphattarakij
// Created          : 08-09-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 08-10-2015
// ***********************************************************************
// <copyright file="Base.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>The collection of business information entities.</summary>
// ***********************************************************************

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BI.Core.Models
{
    /// <summary>
    /// Represents the interface for business information attributes.
    /// </summary>
    public class BusinessInfo : DelEntity
    {
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "Permanent Address")]
        public string Address { get; set; }
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Display(Name = "Company Website")]
        public string Website { get; set; }
        [Required]
        [Display(Name = "Business Contact Name")]
        public string ContactName { get; set; }
        [Required]
        [Display(Name = "Business Contact Job Title")]
        public string ContactJobTitle { get; set; }
        [Required]
        [Display(Name = "Contact Detail (ex. Phone, Email, etc,.")]
        [DataType(DataType.MultilineText)]
        public string ContactDescription { get; set; }
        [Required]
        [Display(Name = "Business Detail")]
        public string BusinessDescription { get; set; }
        [Required]
        [Display(Name = "Name of Product or Service I want to sell")]
        public string Sell { get; set; }
        [Display(Name = "Name of Product or Service I want to buy")]
        public string Buy { get; set; }
    }
}
