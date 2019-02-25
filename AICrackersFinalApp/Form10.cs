using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Capture;
using System.Windows.Storage;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech.Intent;

using System.Windows.Input;
//using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
//using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;

using Microsoft.Rest;
using System.Net.Http;
using System.Threading;

using System.Net;
using System.Text.RegularExpressions;
using System;
using System.Windows;
using System.Windows.Forms;
using Ozeki.Media;
using Ozeki.Media.IPCamera;
using Ozeki.Media.MediaHandlers.Video;
using Ozeki.Media.MediaHandlers;

namespace AICrackersFinalApp
{
    public partial class Form10 : Form
    {
        static Form2 f2;
        static string speech_recorded = "";
        private const string apiKey = "bf5337af36e2445c9d98030c93c47005";
        private const string sentimentUri = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment";
        private const string keyPhrasesUri = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/keyPhrases";
        private const string languageUri = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/languages";
        private const string SubscriptionKey = "e074bf56d56e4347bb69997dd5493456"; //Insert your Text Anaytics subscription key
        private IIPCamera _camera;
        private DrawingImageProvider _drawingImageProvider;
        private MediaConnector _connector;
        private FolderBrowserDialog _folderBrowserDialog;
        private SnapshotHandler _snapshotHandler;

        class ApiKeyServiceClientCredentials : ServiceClientCredentials
        {
            public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                request.Headers.Add("Ocp-Apim-Subscription-Key", SubscriptionKey);
                return base.ProcessHttpRequestAsync(request, cancellationToken);
            }
        }

        static async Task RecognizeIntentAsync()
        {

            var config = SpeechConfig.FromSubscription("e074bf56d56e4347bb69997dd5493456", @"westus");

            // Creates a speech recognizer using microphone as audio input.
            using (var recognizer = new SpeechRecognizer(config))
            {
                // Starts recognizing

                // Performs recognition. RecognizeOnceAsync() returns when the first utterance has been recognized,
                // so it is suitable only for single shot recognition like command or query. For long-running
                // recognition, use StartContinuousRecognitionAsync() instead.
                var result = await recognizer.RecognizeOnceAsync().ConfigureAwait(false);

                // Checks result.
                if (result.Reason == ResultReason.RecognizedSpeech)
                {
                  
                    speech_recorded = result.Text;
                }
                else if (result.Reason == ResultReason.NoMatch)
                {
                   
                }
                else if (result.Reason == ResultReason.Canceled)
                {
                    var cancellation = CancellationDetails.FromResult(result);
                    

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                       
                    }
                }
            }
        }

        static void initTextAnalysis()
        {

            var sampleText = speech_recorded;
            if (sampleText.Length == 0)
                sampleText = "No Text";
            var client = new WebClient();
            client.Headers.Add("Ocp-Apim-Subscription-Key", apiKey);
            client.Headers.Add("Content-Type", "application/json");
            client.Headers.Add("Accept", "application/json");
            var postData1 = @"{""documents"":[{""id"":""1"", ""text"":""@sampleText""}]}".Replace("@sampleText", sampleText);
            var response1 = client.UploadString(languageUri, postData1);
            var language = new Regex(@"""iso6391Name"":""(\w+)""").Match(response1).Groups[1].Value;

            // Determine sentiment
            var postData2 = @"{""documents"":[{""id"":""1"", ""language"":""@language"", ""text"":""@sampleText""}]}".Replace("@sampleText", sampleText).Replace("@language", language);
            var response2 = client.UploadString(sentimentUri, postData2);
            var sentimentStr = new Regex(@"""score"":([\d.]+)").Match(response2).Groups[1].Value;
            var sentiment = Convert.ToDouble(sentimentStr, System.Globalization.CultureInfo.InvariantCulture);

            // Detemine key phrases
            var postData3 = postData2;
            var response3 = client.UploadString(keyPhrasesUri, postData2);
            var keyPhrases = new Regex(@"""keyPhrases"":(\[[^\]]*\])").Match(response3).Groups[1].Value;

            //Console.WriteLine("Text: {0}", sampleText);
            //Console.WriteLine("Language: {0}", language);
            f2.speech_score = sentiment;
            //Console.WriteLine("Key phrases: {0}", keyPhrases);
        }

        public Form10()
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
            //videoViewer.Start();
            InitializeComponent();
        }

        public Form10(Form2 f)
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
            //videoViewer.Start();
            InitializeComponent(); ;
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

        private void Form10_Load(object sender, EventArgs e)
        {
            label1.Text = "What would you like to study in University? Make you long story short and speak loud.";

        }

        private void button1_Click(object sender, EventArgs e)
        {
             CreateSnapShot(@"C: \Users\dell\source\repos\AICrackersFinalApp\AICrackersFinalApp\Resources\");
            
        }
    }
}
