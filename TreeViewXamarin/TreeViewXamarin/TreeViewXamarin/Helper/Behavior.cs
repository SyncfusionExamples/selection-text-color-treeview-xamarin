using Syncfusion.XForms.TreeView;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TreeViewXamarin
{
    public class Behavior : Behavior<SfTreeView>
    {
        SfTreeView TreeView;
        protected override void OnAttachedTo(SfTreeView treeView)
        {
            TreeView = treeView;
            TreeView.SelectionChanging += TreeView_SelectionChanging;
            base.OnAttachedTo(treeView);
        }
        private void TreeView_SelectionChanging(object sender, Syncfusion.XForms.TreeView.ItemSelectionChangingEventArgs e)
        {
            if (TreeView.SelectionMode == Syncfusion.XForms.TreeView.SelectionMode.Single)
            {
                if (e.AddedItems.Count > 0)
                {
                    var item = e.AddedItems[0] as FileManager;
                    item.LabelColor = Color.Red;
                }
                if (e.RemovedItems.Count > 0)
                {
                    var item = e.RemovedItems[0] as FileManager;
                    item.LabelColor = Color.Black;
                }
            }
        }
        protected override void OnDetachingFrom(SfTreeView bindable)
        {
            TreeView.SelectionChanging -= TreeView_SelectionChanging;
			TreeView = null;
            base.OnDetachingFrom(bindable);
        }
    }
}
