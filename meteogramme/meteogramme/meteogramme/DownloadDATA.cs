﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace meteogramme
{
    internal class DownloadDATA
    {
        /// <summary>
        /// Declaration of fields
        /// </summary>
        private string _latitude;
        private string _longitude;
        private string _stateDateTime;
        /// <summary>
        /// This will be the url to access the data we need.
        /// </summary>
        private const string DEFAULT_URL = "http://api.met.no/weatherapi/locationforecast/1.9/?";

        Temperature temperature;
        Precipitation precipitation;
        private uint CountIterration;
        private DateTime InitDateTime;

        /// <summary>
        /// Encapsulation of fields
        /// </summary>
        public string Latitude { get => _latitude; set => _latitude = value; }
        public string Longitude { get => _longitude; set => _longitude = value; }
        public string Url { get => DEFAULT_URL + "lat=" + Latitude + ";lon=" + Longitude; }
        public string StateDateTime { get => _stateDateTime; set => _stateDateTime = value; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="lat">This will be the latitude of the location in string</param>
        /// <param name="lon">This will be the longitude of the location in string</param>
        public DownloadDATA(string lat, string lon)
        {
            Latitude = lat;
            Longitude = lon;
            temperature = new Temperature();
            precipitation = new Precipitation();
            ReadAndExtractData();
        }

        /// <summary>
        /// Will read the xml file and extract the data and put them in the differente classes
        /// </summary>
        /// <returns></returns>
        public void ReadAndExtractData()
        {
            CountIterration = 0;
            if (CanRequest(Url))
            {
                try
                {
                    //string attribute = "";           
                    using (XmlReader reader = XmlReader.Create(Url))
                    {
                        while (reader.Read())
                        {
                            switch (reader.Name)
                            {
                                case "model":
                                    //InitDateTime = Convert.ToDateTime(reader)
                                    InitDateTime = reader.MoveToAttribute("from") ? Convert.ToDateTime(reader.Value.Remove(10)).AddDays(3) : DateTime.Now;
                                    break;
                                case "time":
                                    if (reader.MoveToAttribute("to"))
                                    {
                                        if (StateDateTime != null)
                                        {
                                            if (reader.Value == StateDateTime.Remove(StateDateTime.Length - 1))
                                                StateDateTime = StateDateTime.Remove(StateDateTime.Length - 1) + ++CountIterration;
                                            else
                                            {
                                                CountIterration = 0;
                                                StateDateTime = reader.Value + CountIterration;
                                            }
                                        }
                                        else
                                            StateDateTime = reader.Value + CountIterration;
                                    }
                                    break;
                                case "temperature":
                                    if (reader.MoveToAttribute("value"))
                                        temperature.Temp[StateDateTime] = reader.Value;
                                    break;
                                case "precipitation":
                                    if (reader.MoveToAttribute("value"))
                                        precipitation.Value[StateDateTime] = reader.Value;
                                    break;
                                case "symbol":
                                    if (reader.MoveToAttribute("number"))
                                        precipitation.Number[StateDateTime] = reader.Value;
                                    break;
                                case "minTemperature":
                                    if (reader.MoveToAttribute("value"))
                                        temperature.TempMin[StateDateTime] = reader.Value;
                                    break;
                                case "maxTemperature":
                                    if (reader.MoveToAttribute("value"))
                                        temperature.TempMax[StateDateTime] = reader.Value;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    MessageBox.Show("fait");
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Will test if the url is reponding
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private bool CanRequest(string url)
        {
            bool result = false;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception)
            {
                result = false;
                return result;
            }

            // Check that the remote file was found. The ContentType
            // check is performed since a request for a non-existent
            // image file might be redirected to a 404-page, which would
            // yield the StatusCode "OK", even though the image was not
            // found.
            if ((response.StatusCode == HttpStatusCode.OK))
            {
                result = true;
            }
            response.Dispose();
            return result;
        }
    }
}