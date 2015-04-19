using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace WeatherDemo
{
	[Activity (Label = "WeatherDemo", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		//int count = 1;

		RESTHandler objRest;
		//ListView lstWeather
		List<Temperature> tmpWeatherList;


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);


			objRest = new RESTHandler (@"api.openweathermap.org/data/2.5/forecast?q=London,us&mode=xml");
			var response = await objRest.ExecuteRequestAsync ();



		}










	}
}


