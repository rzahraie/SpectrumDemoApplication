using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1.Behavior
{
    public class StatusBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            Color clr = Color.Default;

            switch(((Entry)sender).Text)
            {
                case "Failed":
                    clr = Color.Red;
                    break;

                case "Success":
                    clr = Color.LawnGreen;
                    break;

                case "Pending":
                    clr = Color.Yellow;
                    break;

                default:
                    clr = Color.Default;
                    break;
            }

            ((Entry)sender).BackgroundColor = clr;
        }
    }
}
