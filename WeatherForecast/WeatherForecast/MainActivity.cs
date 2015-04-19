using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android.Graphics;
using Android.Graphics.Drawables;
using System.Net;

namespace WeatherForecast
{
	[Activity (Label = "JK Weather", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class MainActivity : Activity
	{
		//int count = 1;


		RestHandler objRest;
		RootObject objRootList;
		City objCityList;
		List objList;


		TextView txtCity;
		TextView txtDate;
		TextView txtTemp;
		TextView txtWeather;
		TextView txtMax;
		TextView txtMin;



		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

		

			try
			{
				//objRest = new RestHandler (@"https://api.flickr.com/services/rest/?method=flickr.interestingness.getList");
				objRest = new RestHandler (@"api.openweathermap.org/data/2.5/forecast/daily?q=Auckland&mode=xml&units=metric&cnt=7");


				objRest.AddParameter ("api_key", "d7139997bd5e407bb42efb83f8f6274f");
				objRest.AddParameter ("format", "json");
				objRest.AddParameter ("nojsoncallback", "1");
				//objRest.AddParameter ("api_sig", "71007d2a60efd2ea3b59db622103aa23");

				objRootList = objRest.ExeccuteRequest ();



				txtCity.FindViewById<TextView> (Resource.Id.txtCity);
				txtDate.FindViewById<TextView> (Resource.Id.txtDate);
				txtTemp.FindViewById<TextView> (Resource.Id.txtTemp);
				txtWeather.FindViewById<TextView> (Resource.Id.txtWeather);
				txtMax.FindViewById<TextView> (Resource.Id.txtMax);
				txtMin.FindViewById<TextView> (Resource.Id.txtMin);


				txtCity.Text = objCityList.name;
			//	txtDate.Text = objRootList.
				txtTemp.Text = (Convert.ToString(objList.temp));



				//LoadWeather ();

			} catch (Exception e) {
				Toast.MakeText (this, "Error" +e.Message, ToastLength.Long);
			}




		}


//		public void LoadWeather()
//
//		objRest = new RESTHandler (@"api.openweathermap.org/data/2.5/forecast/daily?q=Auckland&mode=xml&units=metric&cnt=7")
//			{	var Response - objRest.ExecuteRequest();
//			txtCity.Text = Response.Channel.Item.City;
//		}




	}
}


