using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Calligraphy;

namespace DesignLibrary_Tutorial
{
    // Use this to override the entire app font and typeface
    [Application]
    class App : Application
    {
        public App(
               IntPtr javaReference,
               JniHandleOwnership transfer)
             : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            CalligraphyConfig.InitDefault(
              new CalligraphyConfig.Builder()
                .SetDefaultFontPath("MontserratAlternates_Regular.ttf")
                .SetFontAttrId(Resource.Attribute.fontPath)
                .Build()
            );
        }


    }
}