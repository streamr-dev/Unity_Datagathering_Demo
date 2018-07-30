namespace Mapbox.Unity.Location
{
    using System;
    using Mapbox.Unity.Utilities;
    using Mapbox.Utils;
    using UnityEngine;
    using Mapbox.Unity.Map;
    using UnityEngine.Networking;
    using System.Collections;
    using System.Collections.Generic;
    using SimpleHTTP;

    /// <summary>
    /// The EditorLocationProvider is responsible for providing mock location and heading data
    /// for testing purposes in the Unity editor.
    /// </summary>
    public class EditorLocationProvider : AbstractEditorLocationProvider
	{
		/// <summary>
		/// The mock "latitude, longitude" location, respresented with a string.
		/// You can search for a place using the embedded "Search" button in the inspector.
		/// This value can be changed at runtime in the inspector.
		/// </summary>
		[SerializeField]
		[Geocode]
		string _latitudeLongitude;

		/// <summary>
		/// The transform that will be queried for location and heading data & ADDED to the mock latitude/longitude
		/// Can be changed at runtime to simulate moving within the map.
		/// </summary>
		[SerializeField]
		Transform _targetTransform;

		//[SerializeField]
		AbstractMap _map;

		bool _mapInitialized;

        IEnumerator coroutine;

#if UNITY_EDITOR
		protected virtual void Start()
		{
			LocationProviderFactory.Instance.mapManager.OnInitialized += Map_OnInitialized;
			//_map.OnInitialized += Map_OnInitialized;

			if (_targetTransform == null)
			{
				_targetTransform = transform;
			}

			base.Awake();
		}
#endif

		void Map_OnInitialized()
		{
			LocationProviderFactory.Instance.mapManager.OnInitialized -= Map_OnInitialized;
			//_map.OnInitialized -= Map_OnInitialized;
			_mapInitialized = true;
			_map = LocationProviderFactory.Instance.mapManager;
		}

		Vector2d LatitudeLongitude
		{
			get
			{
				if (_mapInitialized)
				{
					var startingLatLong = Conversions.StringToLatLon(_latitudeLongitude);
					var position = Conversions.GeoToWorldPosition(
						startingLatLong,
						_map.CenterMercator,
						_map.WorldRelativeScale
					).ToVector3xz();
					position += _targetTransform.position;
					return position.GetGeoPosition(_map.CenterMercator, _map.WorldRelativeScale);
				}

				return Conversions.StringToLatLon(_latitudeLongitude);
			}
		}

		protected override void SetLocation()
		{
			_currentLocation.UserHeading = _targetTransform.eulerAngles.y;
			_currentLocation.LatitudeLongitude = LatitudeLongitude;
			_currentLocation.Accuracy = _accuracy;
			_currentLocation.Timestamp = UnixTimestampUtils.To(DateTime.UtcNow);
			_currentLocation.IsLocationUpdated = true;
			_currentLocation.IsUserHeadingUpdated = true;
			_currentLocation.IsLocationServiceEnabled = true;
            //coroutine = Post(_currentLocation.LatitudeLongitude);
            //StartCoroutine(coroutine);
		}

        //IEnumerator Post(double lat, double lng, float? speed)
        //{
        //    // Let's say that this the object you want to create
        //    Post post = new Post("Test", latlong.ToString(), 1);
        //    // Create the request object and use the helper function `RequestBody` to create a body from JSON
        //    Request request = new Request("https://www.streamr.com/api/v1/streams/fcerTRt_TYG5NgTMPVuGMQ/data")
        //        .AddHeader("Authorization", "token _pTG8EVHTjOZwbVCWprixg89zWAaEYSqS7WRsmO8f8rA")
        //        .Post(RequestBody.From<Post>(post));
        //    //Debug.Log(request.Body() == null);
        //    //Debug.Log(BitConverter.ToString(RequestBody.From<Post>(post).Body()).Replace("-", string.Empty).ToLower());
        //    // Instantiate the client
        //    Client http = new Client();
        //    // Send the request
        //    yield return http.Send(request);
        //    // Use the response if the request was successful, otherwise print an error
        //    if (http.IsSuccessful())
        //    {
        //        Response resp = http.Response();
        //        Debug.Log("status: " + resp.Status().ToString() + "\nbody: " + resp.Body());
        //    }
        //    else
        //    {
        //        Debug.Log("error: " + http.Error());
        //    }
        //}
	}
}
