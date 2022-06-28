using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lidar
{
    public partial class Form1 : Form
    {
        private List<PointLatLng> _points;
        public Form1()
        {
            

            InitializeComponent();
            _points= new List<PointLatLng>();
        }

        private void btnLoadIntoMap_Click(object sender, EventArgs e)
        {
            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.GoogleMap;
            double lat = Convert.ToDouble(txtlat.Text);
            double lng = Convert.ToDouble(txtlng.Text);
            map.Position = new GMap.NET.PointLatLng(lat, lng);
            map.MinZoom = 2;
            map.MaxZoom = 18;
            map.Zoom = 13;
            PointLatLng point = new PointLatLng(lat, lng);
            GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.green); ;

            GMapOverlay markers = new GMapOverlay("markers");

            markers.Markers.Add(marker);
            map.Overlays.Add(markers);



        }

        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            _points.Add(new PointLatLng(Convert.ToDouble(txtlat.Text), Convert.ToDouble(txtlng.Text)));
            MessageBox.Show(string.Join(",",_points));
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            _points.Clear();
        }

        private void btnGetRouteİnfo_Click(object sender, EventArgs e)
        {


            PointLatLng route1 = _points[0];
            PointLatLng route2 = _points[1];
         


            var route = GoogleMapProvider.Instance.GetRoute(route1, route2, false, false,14);
            var r = new GMapRoute(route.Points, "my route");
            
            var routes = new GMapOverlay("routers");
            routes.Routes.Add(r);
            map.Overlays.Add(routes);
                {
                Pen Stroke = new Pen(Color.DarkRed, 5);
            };

        }

        private void txtlat_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtlng_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
