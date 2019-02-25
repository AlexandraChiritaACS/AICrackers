using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Windows;
using System.Windows.Forms;
using Ozeki.Media;
using Ozeki.Media.IPCamera;
using Ozeki.Media.MediaHandlers.Video;
using Ozeki.Media.MediaHandlers;

namespace AICrackersFinalApp
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : System.Windows.Controls.UserControl
    {
        Form2 f2;
        private IIPCamera _camera;
        private DrawingImageProvider _drawingImageProvider;
        private MediaConnector _connector;
        private FolderBrowserDialog _folderBrowserDialog;
        private SnapshotHandler _snapshotHandler;

        public UserControl1()
        {
            _drawingImageProvider = new DrawingImageProvider();
            _connector = new MediaConnector();
            //videoViewer.SetImageProvider(_drawingImageProvider);
            _folderBrowserDialog = new FolderBrowserDialog();
            _snapshotHandler = new SnapshotHandler();
            _camera = IPCameraFactory.GetCamera("192.168.115.175:8080", "admin", "admin");
            _connector.Connect(_camera.VideoChannel, _drawingImageProvider);
            _connector.Connect(_camera.VideoChannel, _snapshotHandler);
            _camera.Start();
            videoViewer.Start();
            InitializeComponent();
        }

        private void CreateSnapShot(string path)
        {
            var date = DateTime.Now.Year + "y-" + DateTime.Now.Month + "m-" + DateTime.Now.Day + "d-" +
                       DateTime.Now.Hour + "h-" + DateTime.Now.Minute + "m-" + DateTime.Now.Second + "s";
            string currentpath;
            if (String.IsNullOrEmpty(path))
                currentpath = date + ".jpg";
            else
                currentpath = path + "\\" + date + ".jpg";

            var snapShotImage = _snapshotHandler.TakeSnapshot().ToImage();
            snapShotImage.Save(currentpath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        
        public UserControl1(Form2 f)
        {
            f2 = f;
            _drawingImageProvider = new DrawingImageProvider();
            _connector = new MediaConnector();
            //videoViewer.SetImageProvider(_drawingImageProvider);
            _folderBrowserDialog = new FolderBrowserDialog();
            _snapshotHandler = new SnapshotHandler();
            _camera = IPCameraFactory.GetCamera("192.168.115.175:8080", "admin", "admin");
            _connector.Connect(_camera.VideoChannel, _drawingImageProvider);
            _connector.Connect(_camera.VideoChannel, _snapshotHandler);
            _camera.Start();
            videoViewer.Start();
            InitializeComponent();
        }

        private void Btn_Snapshot_Click(object sender, RoutedEventArgs e)
        {
            CreateSnapShot(@"C: \Users\dell\source\repos\AICrackersFinalApp\AICrackersFinalApp\Resources\");
        }
    }
}
