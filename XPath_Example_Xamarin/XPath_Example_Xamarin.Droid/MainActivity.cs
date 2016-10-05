using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Xml;
using System.Net;
using HtmlAgilityPack;


namespace XPath_Example_Xamarin.Droid
{
	[Activity (Label = "XPath_Example_Xamarin.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
            
            TextView textView = FindViewById<TextView> (Resource.Id.textView);

            string url = "http://magtu.ru/novosti/abiturientam/6520-diktant-dlya-starsheklassnikov-write-and-speak-uchi-anglijskij-yazyk.html";
            HtmlDocument document = new HtmlWeb().Load(url);

            string xpath = "//div[@itemprop=\"articleBody\"]";
            HtmlNode node = document.DocumentNode.SelectSingleNode(xpath);
            if (node == null) {
                textView.Text = string.Format("Not found item by xpath: \"{0}\"", xpath);
                return;
            }
            textView.Text = "InnerHtml:\n" + node.InnerHtml + "\n\nInnerText:\n" + node.InnerText;

        }
    }
}


