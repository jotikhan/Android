using System;
using RestSharp;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using AndroidHUD;



namespace RugbyNewsDemo

{


	public class RESTHandler
	{
		private string url;
		private IRestResponse response;


		public RESTHandler ()
		{
			url = "";

		}

		public RESTHandler (string lurl)

		{
			url = lurl;

		}


		public Rss ExecuteRequest()

		{
			var client = new RestClient (url); 
			var request = new RestRequest ();

			response = client.Execute(request);

			XmlSerializer serializer = new XmlSerializer (typeof(Rss));

			Rss objRss;
			TextReader sr = new StringReader(response.Content);

			objRss = (Rss) serializer.Deserialize (sr);
			return objRss;

		}




		// Async version of App--------------------

		public async Task<Rss> ExecuteRequestAsync()

		{
			var client = new RestClient (url); 
			var request = new RestRequest ();

			response = await client.ExecuteTaskAsync (request);

			XmlSerializer serializer = new XmlSerializer (typeof(Rss));

			Rss objRss;
			TextReader sr = new StringReader(response.Content);

			objRss = (Rss) serializer.Deserialize (sr);
			return objRss;

		}



		// End of async version ----------------------



	}

}

