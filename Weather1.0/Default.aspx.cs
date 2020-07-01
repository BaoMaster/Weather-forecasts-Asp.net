using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Weather1._0
{
    public partial class _Default : Page
    {



        public string vari { get; set; }
        
        
        // http://home.openweathermap.org/users/sign_in -- link đăng ký lấy API
        private const string API_KEY = "83033302d9e24bca021e07b29889e547";


        private const string CurrentUrl =
            "http://api.openweathermap.org/data/2.5/weather?" +
            "@QUERY@=@LOC@&mode=xml&units=imperial&APPID=" + API_KEY;
        private const string ForecastUrl =
            "http://api.openweathermap.org/data/2.5/forecast?" +
            "@QUERY@=@LOC@&mode=xml&units=imperial&APPID=" + API_KEY;


        private string[] QueryCodes = { "q", "zip", "id", };
        protected void Page_Load(object sender, EventArgs e)
        {
            
         
        }
        protected void login_click(object sender,EventArgs e)
        {
            string url = ForecastUrl.Replace("@LOC@", bao.Text);
            url = url.Replace("@QUERY@", QueryCodes[DropDownList1.SelectedIndex]);

            //txtCity.Text = bao.Text;
            using (WebClient client = new WebClient())
            {

                try
                {
                    DisplayForecast(client.DownloadString(url));
                }
                catch (WebException ex)
                {
                  //  DisplayError(ex);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Unknown error\n" + ex.Message);
                }
            }


            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string content = sr.ReadToEnd();
            sr.Close();

            XmlReader reader = XmlReader.Create(new StringReader(content));
            reader.ReadToFollowing("forecast");
            reader.ReadToFollowing("time");
            reader.MoveToElement();
            XmlReader r = reader.ReadSubtree();
            r.ReadToFollowing("symbol");
            r.MoveToFirstAttribute();
            r.MoveToNextAttribute();
            r.MoveToNextAttribute();

            vari = "http://openweathermap.org/img/wn/04n@2x.png";


        }
        private void DisplayForecast(string xml)
        {

            XmlDocument xml_doc = new XmlDocument();
            xml_doc.LoadXml(xml);


            XmlNode loc_node = xml_doc.SelectSingleNode("weatherdata/location");
            txtCity.InnerText = loc_node.SelectSingleNode("name").InnerText + "/";
            txtCountry.InnerText = loc_node.SelectSingleNode("country").InnerText;
            txtTimeZone.InnerText = loc_node.SelectSingleNode("timezone").InnerText;
            XmlNode geo_node = loc_node.SelectSingleNode("location");
            txtLat.InnerText = geo_node.Attributes["latitude"].Value;
            txtLong.InnerText = geo_node.Attributes["longitude"].Value;
            txtId.InnerText = geo_node.Attributes["geobaseid"].Value;
            //XmlNode time_node = xml_doc.SelectNodes("time");
            //XmlNode wind_node = time_node.SelectSingleNode("windDirection");

            // lvwForecast.Items.Clear();


            XmlNode fore_node = xml_doc.SelectSingleNode("weatherdata/forecast");
            XmlNode time_node = fore_node.SelectSingleNode("time");
            DateTime time = DateTime.Parse(time_node.Attributes["from"].Value, null, DateTimeStyles.AssumeUniversal);
            timee.InnerText = Convert.ToString(time);
            XmlNode wind_node = time_node.SelectSingleNode("windDirection");
            windDe.InnerText = wind_node.Attributes["deg"].Value+ "°";
            windS.InnerText = wind_node.Attributes["name"].Value;
            XmlNode windspeed_node = time_node.SelectSingleNode("windSpeed ");
            //string winspeed = windspeed_node.Attributes["mps"].Value;
            windspeed.InnerText = windspeed_node.Attributes["mps"].Value+" mph";
            XmlNode temp_node = time_node.SelectSingleNode("temperature");
            double changeTemp=Convert.ToDouble( temp_node.Attributes["value"].Value);
            changeTemp = Change(changeTemp);
          
            temp.InnerText =Convert.ToString(Math.Round(Convert.ToDecimal(changeTemp), 2))+ "°C";
            XmlNode feel_node = time_node.SelectSingleNode("feels_like");
            double stringFeel = Convert.ToDouble(feel_node.Attributes["value"].Value);
            stringFeel = Change(stringFeel);
           
            feel.InnerText = Convert.ToString(Math.Round(Convert.ToDecimal(stringFeel), 2))+ "°C";
            XmlNode press_node = time_node.SelectSingleNode("pressure");
            press.InnerText = press_node.Attributes["value"].Value+" hPa";
            XmlNode hum_node = time_node.SelectSingleNode("humidity ");
            hum.InnerText = hum_node.Attributes["value"].Value + "%";
            XmlNode cloud_node = time_node.SelectSingleNode("clouds ");
            cloud.InnerText = cloud_node.Attributes["value"].Value;
            ValCloud.InnerText = cloud_node.Attributes["all"].Value+"%";
            //char degrees = (char)176;

            //foreach (XmlNode time_node in xml_doc.SelectNodes("//time"))
            //{

            //    DateTime time =
            //        DateTime.Parse(time_node.Attributes["from"].Value,
            //            null, DateTimeStyles.AssumeUniversal);
            //    timee.InnerText =Convert.ToString( time);

            //    XmlNode wind_node = time_node.SelectSingleNode("windDirection");
            //   // windDe.InnerText = wind_node.SelectSingleNode("deg").InnerText;
            //        string wind = wind_node.Attributes["deg"].Value;
            //    windDe.InnerText = wind;
            //    XmlNode windspeed_node = time_node.SelectSingleNode("windSpeed ");
            //    string winspeed = windspeed_node.Attributes["mps"].Value;
            //    windspeed.InnerText = winspeed;

            //    //    string temp = temp_node.Attributes["value"].Value;

            //    //    ListViewItem item = lvwForecast.Items.Add(time.DayOfWeek.ToString());
            //    //    item.SubItems.Add(time.ToShortTimeString());
            //    //    item.SubItems.Add(temp + degrees);
            //}
        }
        public double Change(double a)
        {
            a -= 32;
            a = a / 1.8;
            return a;
        }
    }
}