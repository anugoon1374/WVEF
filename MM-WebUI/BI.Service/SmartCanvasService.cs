// ***********************************************************************
// Assembly         : BI.Service
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 04-30-2015
// ***********************************************************************
// <copyright file="DataLogic.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summaryThe facade/service locator for data access service.</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BI.Auxiliary;
using BI.Core.Models;
using BI.Core.Service;
using BI.Infrastructure;

namespace BI.Service
{
    public class SmartCanvasService : ISmartCanvasService
    {
        private readonly Uri _apiUrl;
        private readonly string _clientId;
        private readonly string _clientToken;

        public SmartCanvasService(string apiUrl, string clientId, string clientToken)
        {
            _apiUrl = new Uri(apiUrl);
            _clientId = clientId;
            _clientToken = clientToken;
        }

        public async Task GetAsync(string uid)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _apiUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-client-id", _clientId);
                client.DefaultRequestHeaders.Add("x-access-token", _clientToken);

                // HTTP GET
                var response = await client.GetAsync(uid);
                if (response.IsSuccessStatusCode)
                {
                    //Product product = await response.Content.ReadAsAsync > Product > ();
                    //Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
                }
            }
        }

        public async Task CreateAsync(SmartCanvas newCanvas)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _apiUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-client-id", _clientId);
                client.DefaultRequestHeaders.Add("x-access-token", _clientToken);

                // HTTP POST
                var response = await client.PostAsJsonAsync("application/json", newCanvas);
                if (response.IsSuccessStatusCode)
                {
                    //Product product = await response.Content.ReadAsAsync > Product > ();
                    //Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
                }
            }
        }
    }
}