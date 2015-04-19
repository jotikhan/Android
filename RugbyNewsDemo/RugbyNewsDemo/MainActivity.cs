using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;




namespace RugbyNewsDemo
{
	[Activity (Label = "RugbyNewsDemo", MainLauncher = true, Icon = "@drawable/icon")]

	public class MainActivity : Activity


	{
		//int count = 1;
		RESTHandler objRest;
		ListView lstNews;

		List<Item> tmpNewsList;


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);


			lstNews = FindViewById<ListView> (Resource.Id.lstNews);
			//lstNews = FindViewById<ListView> (Resource.Id.lstNews);

			LoadRugbyNews ();
			lstNews.ItemClick += OnLstNewsClick;
		}



		//----------------------

		public async void LoadRugbyNews ()
		{
			objRest = new RESTHandler (@"http://rss.nzherald.co.nz/rss/xml/nzhrsscid_000000080.xml");
			var Response = await objRest.ExecuteRequestAsync ();

			lstNews.Adapter = new DataAdapter (this, Response.Channel.Item);
			tmpNewsList = Response.Channel.Item;

		}


		//----------------------


		//----------------------

		public async void LoadFootballNews ()
		{
			objRest = new RESTHandler (@"http://rss.nzherald.co.nz/rss/xml/nzhrsscid_000000086.xml");
			var Response = await objRest.ExecuteRequestAsync ();

			lstNews.Adapter = new DataAdapter (this, Response.Channel.Item);
			tmpNewsList = Response.Channel.Item;

		}


		//----------------------


		//----------------------

		public async void LoadCricketNews ()
		{
			objRest = new RESTHandler (@"http://rss.nzherald.co.nz/rss/xml/nzhrsscid_000000029.xml");
			var Response = await objRest.ExecuteRequestAsync ();

			lstNews.Adapter = new DataAdapter (this, Response.Channel.Item);
			tmpNewsList = Response.Channel.Item;

		}


		//----------------------





		public void OnLstNewsClick(object Sender, AdapterView.ItemClickEventArgs e)

		{


			var NewsItem = tmpNewsList[e.Position];
			//Toast.MakeText (this, NewsItem.Link, ToastLength.Short).Show (); 


			// start a new activity and pass the NewsItem.Link as an Intent

			var NewsArticle = new Intent (this, typeof(Article));
			NewsArticle.PutExtra ("URL", NewsItem.Link);
			StartActivity (NewsArticle);

		}

		//----------------------//


		public override bool OnCreateOptionsMenu(IMenu menu)

		{
			//menu.Add("Add");
			menu.Add("Rugby");
			menu.Add("Football");
			menu.Add("Cricket");

			return base.OnPrepareOptionsMenu(menu);


		}


		//----------------------------------



		//----------------------------------

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			var itemTitle = item.TitleFormatted.ToString();

			switch (itemTitle)
			{

//			case "Search":
//				StartActivity (typeof(SearchNote));
//				break;
//			case "Add":
//				StartActivity (typeof(AddItem));
//				break;
//			case "Create Note Item":
//				StartActivity (typeof(AddNoteItem));
//				break;
			case "Rugby":
				LoadRugbyNews();
				break;
			case "Football":
				LoadFootballNews();
				break;
			case "Cricket":
				LoadCricketNews();
				break;


			}
			return base.OnOptionsItemSelected(item);
		}



		//----------------------------------







	}


}



