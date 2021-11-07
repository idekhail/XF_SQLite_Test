using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;


namespace XF_MediaPicker
{
    public partial class PickImagePage : ContentPage
        {
            public PickImagePage()
            {
                InitializeComponent();
            }

            async void PickImg_Clicked(System.Object sender, System.EventArgs e)
            {
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Please pick a photo"
                });

                if (result != null)
                {
                    var stream = await result.OpenReadAsync();

                    resultImage.Source = ImageSource.FromStream(() => stream);
                }
            }

            async void TakeImg_Clicked(System.Object sender, System.EventArgs e)
            {
                var result = await MediaPicker.CapturePhotoAsync();

                if (result != null)
                {
                    var stream = await result.OpenReadAsync();

                    resultImage.Source = ImageSource.FromStream(() => stream);
                }
            }
        }
    }