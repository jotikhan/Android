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



namespace FlickrDemo
{
	[Activity (Label = "Jk Demo Weather", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation=Android.Content.PM.ScreenOrientation.Portrait)]
	public class MainActivity : Activity
	{
		int count = 1;

//		ImageButton btnPrev;
//		ImageButton btnNext;
//		ImageButton btnSave;
//		ImageButton btnShare;
//
		ImageView imgPic;

		RestHandler objRest;
		RootObject objRootList;

		List<Photo> lstPhotos = new List<Photo> ();

		TextView txtTemp;
		TextView txtWeather;
		TextView txtCity;




		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);


			txtCity = FindViewById<TextView> (Resource.Id.txtCity);
			txtTemp = FindViewById<TextView> (Resource.Id.txtTemp);
			txtWeather = FindViewById<TextView> (Resource.Id.txtWeather);



//			btnPrev = FindViewById<ImageButton> (Resource.Id.btnprev);
//			btnNext = FindViewById<ImageButton> (Resource.Id.btnnext);
//			btnSave = FindViewById<ImageButton> (Resource.Id.btnSave);
//
//
//			imgPic = FindViewById<ImageView> (Resource.Id.imageView1);

//			btnNext.Click += OnBtnNextClick;
//			btnPrev.Click += OnBtnPrevClick;
//			btnSave.Click += OnSaveClick;


			// Get our button from the layout resource,
			// and attach an event to it
//			Button button = FindViewById<Button> (Resource.Id.myButton);
			
//			button.Click += delegate {
//				button.Text = string.Format ("{0} clicks!", count++);
//			};
	
			try
			{
			//objRest = new RestHandler (@"https://api.flickr.com/services/rest/?method=flickr.interestingness.getList");
			
			objRest = new RestHandler (@"http://api.openweathermap.org/data/2.5/forecast/daily?id=5506956");


			objRest.AddParameter ("APPID", "d7139997bd5e407bb42efb83f8f6274f");
			objRest.AddParameter ("format", "json");
			objRest.AddParameter ("nojsoncallback", "1");
			
			objRootList = objRest.ExecuteRequest ();
			txtCity.Text = objRootList.city.name;
			//	txtTemp.Text = "Noy";

				//lstPhotos = objRootList.  ;

			//getImage (count);

		} catch (Exception e) {
			Toast.MakeText (this, "Error" +e.Message, ToastLength.Long);
		}

		}

		//--------btnNext-----

		public void OnBtnNextClick(object sender, EventArgs e)
		{
			count = count + 1;
			if (count < 100) {
				getImage (count);
			} 
		}

		//-----end of btnNext-----


		//--------btnPrev-----

		public void OnBtnPrevClick(object sender, EventArgs e)
		{
			count = count - 1;
			if (count > 0) {
				getImage (count);
			} 
		}

		//--------end of btnPrev-----




		//--------GetImage-----

		public void getImage(int index)


		{
			string imgurl;

			try
			{
				var tempmap = lstPhotos[index];
//				imgurl = "http://farm" + tempmap.farm.ToString() + ".staticflickr.com/" + tempmap.server + "/" +tempmap.id + "_" +tempmap.secret + "_b.jpg";
//				Koush.UrlImageViewHelper.SetUrlDrawable (imgPic,imgurl, Resource.Drawable.loading);

				imgurl = "http://farm" + tempmap.farm.ToString() + ".staticflickr.com/" + tempmap.server + "/" +tempmap.id + "_" +tempmap.secret + "_b.jpg";
				Koush.UrlImageViewHelper.SetUrlDrawable (imgPic,imgurl, Resource.Drawable.loading);





			} catch (Exception e) {
				Toast.MakeText (this, "Error" + e.Message, ToastLength.Long);
			}

		}


		//--------end of Get Image-----



		//--------btnSave-----

		public void OnBtnSaveClick1(object sender, EventArgs e)
		{
			var sdCardPath = Android.OS.Environment.ExternalStorageDirectory.Path;
			var filePath = System.IO.Path.Combine (sdCardPath, "MyTextFile.Text");

			if (System.IO.File.Exists (filePath)) {
				var text = System.IO.File.ReadAllText (filePath);

			}

		}

		//--------end of btnSave-----


		//--------Write Text file-----

		public void WriteTextFile()
		{
			var sdCardPath = Android.OS.Environment.ExternalStorageDirectory.Path;
			var filePath = System.IO.Path.Combine (sdCardPath, "MyTextFile.Text");

			if (!System.IO.File.Exists(filePath))

				//using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true));
				
					{
				//writer.Write ("This is the content of my text file ") ;
					}
		}

		//--------end of Write Text File-----



		///------Test BTn Savecode

		public void OnSaveClick (object sender, EventArgs e)
		{

			var fetchedDrawable = imgPic.Drawable;
			BitmapDrawable bitmapDrawable = (BitmapDrawable)fetchedDrawable;
			var bitmap = bitmapDrawable.Bitmap;

			byte[] bitmapData;
			using (var stream = new MemoryStream ()) {
				bitmap.Compress (Bitmap.CompressFormat.Jpeg, 100, stream);
				bitmapData = stream.ToArray ();
			}

			try {

				string localPath = System.IO.Path.Combine (Android.OS.Environment.ExternalStorageDirectory.ToString (), "test2.jpeg");
				File.WriteAllBytes (localPath, bitmapData);
				Toast.MakeText (this, "Image saved", ToastLength.Short).Show ();
			} catch (Exception ex) {
				Toast.MakeText (this, "Not saved!!!", ToastLength.Short).Show ();

			}

		}

		//---End BtnSave  coode----






	}
}


