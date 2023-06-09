﻿using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.SolrProvider.SolrNetIntegration;
using SolrNet;
using SolrNet.Commands.Parameters;
using System.Web.Mvc;

namespace SolrGroupDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string searchText = Request.QueryString["text"] ?? string.Empty;

            if (string.IsNullOrEmpty(searchText))
                return View();

            var queryOptions = new QueryOptions
            {
                Grouping = new GroupingParameters
                {
                    Fields = new[] { "booktype_t" },
                    Limit = 10
                }
            };

            var indexName = $"sitecore_{Sitecore.Context.Database.Name}_index";
            var index = ContentSearchManager.GetIndex(indexName);

            SolrQueryResults<SearchResultItem> results;

            using (var context = index.CreateSearchContext())
            {
                results = context.Query<SearchResultItem>($"(booklang_t:{searchText})", queryOptions);
            }
            return View(results);
        }
    }
}