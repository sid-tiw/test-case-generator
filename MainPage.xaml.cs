using System;
using System.Collections.Generic;
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
            }
            else
            {
                textBox.Text = "Operation cancelled.";
            }
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox.SelectAll();
        }

        private void previous_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            ControlTemplate t = next.Template;
            Button bn = new Button();
            bn.Template = t;
            var str = bn.ActualTheme.ToString();
            Console.WriteLine(str);
            /*path = textBox.Text;
            string str = "";
            var n = path.Length;
            for (int i = n - 4; i < n; i++)
                str = str + path[i];
            if ((str != ".cpp") && (str != ".cxx") && (str != ".CPP") && (str != ".c++"))
                textBox.Text = "You didn't entered a valid address";*/
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
