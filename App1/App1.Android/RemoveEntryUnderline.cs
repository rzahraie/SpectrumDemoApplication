using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using App1.Droid;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(RemoveEntryUnderline), nameof(App1.Droid.RemoveEntryUnderline))]
namespace App1.Droid
{
    public class RemoveEntryUnderline : PlatformEffect
        {
        protected override void OnAttached()
        {
            var editText = this.Control as EditText;

            if (editText is null)
                throw new NotImplementedException();

            editText.Background = null;
            editText.SetBackgroundColor(Android.Graphics.Color.Transparent);
           
        }

        protected override void OnDetached()
        {
        }
    }
}
