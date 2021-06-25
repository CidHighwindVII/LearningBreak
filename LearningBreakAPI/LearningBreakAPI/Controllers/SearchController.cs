using HtmlAgilityPack;
using LearningBreakAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningBreakAPI.Extensions;
using Microsoft.Extensions.Configuration;
using LearningBreakAPI.ImdbLogic;
namespace LearningBreakAPI.Controllers
{
    public class SearchController : BaseApiController
    {
        private readonly IConfiguration _config;
        public SearchController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<List<SearchResultToReturnDto>>> Search([FromQuery] string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return BadRequest("Missing query");
            }

            List<SearchResultToReturnDto> resultList = new List<SearchResultToReturnDto>();
            string site = ImdbQueries.GetSearchQuery(_config, query);
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = await web.LoadFromWebAsync(site);

            try
            {
                if (doc.DocumentNode.SelectSingleNode("//*[@class='findNoResults']") == null)
                {
                    foreach (var section in doc.DocumentNode.SelectNodes("//*[@class='findSection']/h3[text()='Titles']/../table/tr"))
                    {
                        SearchResultToReturnDto result = new SearchResultToReturnDto();
                        result.ImageLink = section.SelectSingleNodeFromCurrentNode("//*[@class='primary_photo']/a/img").Attributes.FirstOrDefault(x => x.Name == "src").Value;
                        result.Name = section.SelectSingleNodeFromCurrentNode("//*[@class='result_text']").InnerText;
                        result.Link = section.SelectSingleNodeFromCurrentNode("//*[@class='result_text']/a").Attributes.FirstOrDefault(x => x.Name == "href").Value;

                        resultList.Add(result);
                    }
                }
            } 
            catch (Exception ex)
            {

            }           

            return resultList;
        }
    }
}
