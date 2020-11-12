using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ListViewXamarin
{
    public class Behavior : Behavior<ContentPage>
    {
        #region Fields
        SfListView ListView;
        #endregion

        #region Overrides
        protected override void OnAttachedTo(ContentPage bindable)
        {
            ListView = bindable.FindByName<SfListView>("ToDoListView");
            ListView.ItemDragging += ListView_ItemDragging;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            ListView.ItemDragging -= ListView_ItemDragging;
            ListView = null;
            base.OnDetachingFrom(bindable);
        }
        #endregion

        #region Call back
        private void ListView_ItemDragging(object sender, ItemDraggingEventArgs e)
        {
            if (e.Action == DragAction.Drop)
            {
                if (e.NewIndex < e.OldIndex)
                {
                    Device.BeginInvokeOnMainThread(() => ListView.RefreshListViewItem(-1, -1, true));
                };
            }
        }
        #endregion
    }
}
