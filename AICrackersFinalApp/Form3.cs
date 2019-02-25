using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms;
using Ozeki.Media;
using Ozeki.Media.IPCamera;
using Ozeki.Media;
using Ozeki.Media.MediaHandlers.Video;
using Ozeki.Media.MediaHandlers;
using Ozeki.Media.Video.Controls;

namespace AICrackersFinalApp
{
    public partial class Form3 : Form
    {
        private IIPCamera _camera;
        private DrawingImageProvider _imageProvider;
        private MediaConnector _connector;
        private VideoViewerWF _videoViewerWf;
        private SnapshotHandler _snapshotHandler;

        private void SetVideoViewer()
        {
            //CameraBox.Controls.Add(_videoViewerWf);
            _videoViewerWf.Size = new Size(260, 180);
            _videoViewerWf.BackColor = Color.Black;
            _videoViewerWf.TabStop = false;
            _videoViewerWf.Location = new Point(14, 19);
            _videoViewerWf.Name = "_videoViewerWf";
        }

        private void StartCamera()
        {
            _camera = IPCameraFactory.GetCamera("192.168.115.175:8080", "admin", "admin");
            _connector.Connect(_camera.VideoChannel, _imageProvider);
            _connector.Connect(_camera.VideoChannel, _snapshotHandler);
            _videoViewerWf.SetImageProvider(_imageProvider);
            _videoViewerWf.Start();
            _camera.Start();
        }

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
