using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace FreiplatzApp.Assets
{
    class AssetHandler
    {
        public AssetHandler()
        {
            string resourcePrefix = "WorkingWithFiles.Droid.";

            if (Device.RuntimePlatform == Device.iOS)
            {
                resourcePrefix = "WorkingWithFiles.iOS.";
            }

            Debug.WriteLine("Using this resource prefix: " + resourcePrefix);
            // note that the prefix includes the trailing period '.' that is required
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(FreiplatzApp)).Assembly;
            Stream stream = assembly.GetManifestResourceStream
                (resourcePrefix + "SharedTextResource.txt");
        }
    }
}
