using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetHotel.Infrastructure
{
    public  static class CustomHelpers
    {
        public static MvcHtmlString DisplayDictionaryAsList(this HtmlHelper html, Dictionary<string,decimal> list)
        {

            TagBuilder ultag =new TagBuilder("ul");
            foreach (KeyValuePair<string,decimal> li in list )
            {

                TagBuilder litag = new TagBuilder("li");
                litag.SetInnerText(li.Key+":   "+li.Value);
                ultag.InnerHtml += litag.ToString(); 
               
            }
            return new MvcHtmlString(ultag.ToString());


        }


    }
}