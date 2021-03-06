using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FreiplatzApp.Helper
{
    public class Animator
    {
        public static async void ImageTransition(Image image, string icon)
        {
            uint transitionTime = 100;

            await Task.WhenAll(image.ScaleTo(1.3, transitionTime, Easing.Linear));
            await Task.WhenAll(image.ScaleTo(0.7, transitionTime, Easing.Linear));
            await Task.WhenAll(image.ScaleTo(1.15, transitionTime, Easing.Linear));

            image.Source = ImageSource.FromFile(icon);

            await Task.WhenAll(image.ScaleTo(0.85, transitionTime, Easing.Linear));
            await Task.WhenAll(image.ScaleTo(1, transitionTime, Easing.Linear));
          
        }

        public static async void TapAnimation(Image image)
        {
            uint transitionTime = 70;

            await Task.WhenAll(image.ScaleTo(1.2, transitionTime, Easing.Linear));
            await Task.WhenAll(image.ScaleTo(0.8, transitionTime, Easing.Linear));
            await Task.WhenAll(image.ScaleTo(1.1, transitionTime, Easing.Linear));
            await Task.WhenAll(image.ScaleTo(0.9, transitionTime, Easing.Linear));
            await Task.WhenAll(image.ScaleTo(1, transitionTime, Easing.Linear));

        }
    }
}
