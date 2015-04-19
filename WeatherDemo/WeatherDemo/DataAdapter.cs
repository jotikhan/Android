﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Net;
using Android.Graphics;
using Java.IO;
using Android.Graphics.Drawables;
using Android.Util;
using System.Net;
using System.IO;

namespace WeatherDemo
{


	public class DataAdapter : BaseAdapter<Temperature> {

		List<Temperature> items;

		Activity context;
		public DataAdapter(Activity context, List<Temperature> items)
			: base()
		{
			this.context = context;
			this.items = items;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override Temperature this[int position]
		{
			get { return items[position]; }
		}
		public override int Count
		{
			get { return items.Count; }
		}

		//--------------------------------------------//


		public override View GetView(int position, View convertView, ViewGroup parent)//View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = items[position];
			//View view = convertView;
//			if (view == null) // no view to re-use, create new
//				view = context.LayoutInflater.Inflate(Resource.Layout.CustomRow, null);

			view.FindViewById<TextView>(Resource.Id.txtTemp).Text = item.temperature;
			view.FindViewById<TextView>(Resource.Id.txtCity).Text = item.name;

//			if (item.Enclosure != null) {
//			
//				var imageBitmap = GetImageBitmapFromUrl (item.Enclosure.Url);
//				view.FindViewById<ImageView> (Resource.Id.Image).SetImageBitmap (imageBitmap);
//			}
//				return view;


		}

		//--------------------------------------------//


		//--------------------------------------------//

		private Bitmap GetImageBitmapFromUrl(string url)
		{
			Bitmap imageBitmap = null;
			if(!(url=="null"))
				using (var webClient = new WebClient())
				{
					var imageBytes = webClient.DownloadData(url);
					if (imageBytes != null && imageBytes.Length > 0)
					{
						imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
					}
				}

			return imageBitmap;
		}


		//--------------------------------------------//


	}

}
