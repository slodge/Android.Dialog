﻿using System;
using Android.Content;
using Android.Widget;

namespace MonoDroid.Dialog
{
    public class DialogHelper
    {
        private Context context;
        private RootElement formLayer;

        //public event Action<Section, Element> ElementClick;
        //public event Action<Section, Element> ElementLongClick;

        public RootElement Root { get; set; }

        private DialogAdapter DialogAdapter { get; set; }

        public DialogHelper(Context context, ListView dialogView, RootElement root)
        {
            this.Root = root;
            this.Root.Context = context;

            dialogView.Adapter = this.DialogAdapter = new DialogAdapter(context, this.Root);
            dialogView.ItemClick += new EventHandler<ItemEventArgs>(ListView_ItemClick);
            dialogView.ItemLongClick += ListView_ItemLongClick;;
            dialogView.Tag = root;
        }

        void ListView_ItemLongClick (object sender, AdapterView.ItemLongClickEventArgs e)
        {
			var elem = this.DialogAdapter.ElementAtIndex(e.Position);
            if (elem != null && elem.LongClick != null) {
				//                elem.LongClick(sender, e);
				elem.LongClick();
			}
        }

        void ListView_ItemClick(object sender, ItemEventArgs e)
        {
            var elem = this.DialogAdapter.ElementAtIndex(e.Position);
            if (elem != null && elem.Click != null) {
				//                elem.Click(sender, e);
				elem.Click();
			}
        }
    }
}