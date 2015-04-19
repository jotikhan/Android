using System;
using RestSharp;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherForecast
{




	public class RestHandler
	{
		private string url;
		private IRestResponse response;
		private RestRequest request;


		public RestHandler ()
		{
			url = "";
		}

		public RestHandler (string lurl)
		{
			url = lurl;
			request = new RestRequest ();
		}


		public void AddParameter (string name, string value)
		{
			if (request != null) {
				request.AddParameter (name, value);
			}


		}

		//----------------

		public RootObject ExeccuteRequest()
		{
			var client = new RestClient (url);

			response = client.Execute (request);

			RootObject objRoot = new RootObject ();
			objRoot = JsonConvert.DeserializeObject<RootObject> (response.Content); 

			return objRoot;

		}

		//-----------------------


		//--------------

		public async Task<RootObject> ExecuteRequestAsync()

		{
			var client = new RestClient (url);
			var request = new RestRequest ();

			response = await client.ExecuteTaskAsync (request);

			RootObject objRoot = new RootObject ();
			objRoot = JsonConvert.DeserializeObject<RootObject> (response.Content); 

			return objRoot;
		}


		//--------------


		//--------------

		public async Task<City> ExecuteRequestAsync1()

		{
			var client = new RestClient (url);
			var request = new RestRequest ();

			response = await client.ExecuteTaskAsync (request);

			City objCity = new City ();
			objCity = JsonConvert.DeserializeObject<City> (response.Content); 

			return objCity;
		}


		//--------------

		//--------------

		public async Task<List> ExecuteRequestAsync2()

		{
			var client = new RestClient (url);
			var request = new RestRequest ();

			response = await client.ExecuteTaskAsync (request);

			List objList = new List ();
			objList = JsonConvert.DeserializeObject<List> (response.Content); 

			return objList;
		}


		//--------------



	}









}

