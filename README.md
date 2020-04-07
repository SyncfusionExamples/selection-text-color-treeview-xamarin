# How to change the TreeView selected node text color in Xamarin.Forms (SfTreeView)

In Xamarin.Forms [TreeView](https://help.syncfusion.com/xamarin/treeview/overview?), you can change the text color of selected node by using [SelectionChanging](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfTreeView.XForms~Syncfusion.XForms.TreeView.SfTreeView~SelectionChanging_EV.html?) event.

You can also refer the following aricle.

https://www.syncfusion.com/kb/11362/how-to-change-the-treeview-selected-node-text-color-in-xamarin-forms-sftreeview

**C#**

TextColor updated in SelectionChanging event, based on selection added or removed.

``` c#
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
        base.OnDetachingFrom(bindable);
    }
}
```
  
**XAML**

LabelColor bound to the Label added to SfTreeView in the [ItemTemplate](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfTreeView.XForms~Syncfusion.XForms.TreeView.SfTreeView~ItemTemplate.html?) and Behaviour.

``` xml
<syncfusion:SfTreeView x:Name="treeView" ItemHeight="40" Indentation="15" 
                       ExpanderWidth="40" SelectionMode="Single"
     ChildPropertyName="SubFiles"
     SelectionBackgroundColor="LightGray"
     ItemsSource="{Binding ImageNodeInfo}"
     AutoExpandMode="AllNodesExpanded">
    <syncfusion:SfTreeView.Behaviors>
        <local:Behavior/> 
    </syncfusion:SfTreeView.Behaviors>
    <syncfusion:SfTreeView.ItemTemplate>
        <DataTemplate>
            <ViewCell>
                <ViewCell.View>
                    <Grid x:Name="grid" RowSpacing="0" BackgroundColor="Transparent">
                        <Grid.RowDefinitions>
                            <RowDefinition Height="*" />
                            <RowDefinition Height="1" />
                        </Grid.RowDefinitions>
                        <Grid RowSpacing="0" Grid.Row="0">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="40" />
                                <ColumnDefinition Width="*" />
                            </Grid.ColumnDefinitions>
                            <Grid Padding="5,5,5,5">
                                <Image
                                      Source="{Binding ImageIcon}"
                                      VerticalOptions="Center"
                                      HorizontalOptions="Center"
                                      HeightRequest="35" 
                                      WidthRequest="35"/>
                            </Grid>
                            <Grid Grid.Column="1" RowSpacing="1" Padding="1,0,0,0"
                                  VerticalOptions="Center">
                                <Label x:Name="TextLabel" LineBreakMode="NoWrap" 
                                       Text="{Binding ItemName}" 
                                       TextColor="{Binding LabelColor}"
                                       VerticalTextAlignment="Center">
                                    <Label.FontSize>
                                        <OnPlatform x:TypeArguments="x:Double">
                                            <On Platform="Android,iOS">
                                                <OnIdiom x:TypeArguments="x:Double" Phone="16" Tablet="18" />
                                            </On>
                                        </OnPlatform>
                                    </Label.FontSize>
                                </Label>    
                            </Grid>
                        </Grid>
                        <StackLayout Grid.Row="1" HeightRequest="1"/>
                    </Grid>
                </ViewCell.View>
            </ViewCell>
        </DataTemplate>
    </syncfusion:SfTreeView.ItemTemplate>
</syncfusion:SfTreeView>
```

**Output**

![SelectionTextColorListView](https://github.com/SyncfusionExamples/selection-text-color-treeview-xamarin/blob/master/ScreenShots/SelectedNodeTextColor.png)
