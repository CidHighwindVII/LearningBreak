using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningBreakAPI.Extensions
{
    public static class HtmlNodeExtensions
    {
        public static HtmlNodeCollection SelectNodesFromCurrentNode(this HtmlNode currentNode, string xPath)
        {
            return currentNode.SelectNodes(currentNode.XPath + xPath);
        }
        
        public static HtmlNode SelectSingleNodeFromCurrentNode(this HtmlNode currentNode, string xPath)
        {
            return currentNode.SelectSingleNode(currentNode.XPath + xPath);
        }
    }
}
