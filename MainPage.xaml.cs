using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Media3D;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace test_case_generator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string path;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void b1_Click(object sender, RoutedEventArgs e)
        {
            /*Button b2 = new Button();
            MediaElement mediaElement = new MediaElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("You just clicked the button.");
            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();*/
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.List;
            openPicker.SuggestedStartLocation = PickerLocationId.Desktop;
            openPicker.FileTypeFilter.Add(".cpp");
            openPicker.FileTypeFilter.Add(".c++");
            openPicker.FileTypeFilter.Add(".cxx");
            openPicker.FileTypeFilter.Add(".CPP");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                textBox.Text = file.Path;
                /*StreamReader sr = new StreamReader(file.Path);*/
                FileStream ff = new FileStream(file.Path, FileMode.Open, FileAccess.Read);
                /*string content = await sr.ReadToEndAsync();*/
                long n = ff.Length;
                byte []arr = new byte[n];
                string content = "";
                long r = 0, rt = n;
                while(rt > n)
                {
                    int res = ff.Read(arr, (int)r, (int)rt);
                    if (res == 0)
                        break;
                    r += res;
                    rt -= res;
                }
                for (int i = 0; i < r; i++)
                    content += (char)arr[i];
                Code.Text = content;
            }
            else
            {
                textBox.Text = "Operation cancelled.";
            }
        }

        /*private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox.SelectAll();
        }

        *//*private void previous_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }*/

        private void next_Click(object sender, RoutedEventArgs e)
        {
            var str1 = canva1.ActualHeight.ToString();
            var str2 = canva1.ActualWidth.ToString();
            textBox.Text = str1 + " " + str2;
            Frame.Navigate(typeof(newPage));
            //Frame.Navigate(typeof(newPage));
            /*global::System.Uri resourceLocator = new global::System.Uri("ms-appx:///newPage.xaml");
            global::Windows.UI.Xaml.Application.LoadComponent(this, resourceLocator, global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
            *//*path = textBox.Text;
            string str = "";
            var n = path.Length;
            for (int i = n - 4; i < n; i++)
                str = str + path[i];
            if ((str != ".cpp") && (str != ".cxx") && (str != ".CPP") && (str != ".c++"))
                textBox.Text = "You didn't entered a valid address";*/
        }

        /*private void Finish_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }*/

        private void Code_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Tab)
                Code.Text += "    ";
        }

        /*private void browse_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            *//*# FF39FD66*//*
            browse.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 57, 253, 102));
        }

        private void browse_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            *//*browse.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 69, 138, 255));*//*
        }*/
    }
}
