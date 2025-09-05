# show-reordered-index-listview-xamarin
How to show the reordered sorted index in   Xamarin.Forms ListView (SfListView) 

## Sample

```xaml
<ContentPage.Resources>
    <ResourceDictionary>
        <local:IndexConverter x:Key="indexConverter"/>
    </ResourceDictionary>
</ContentPage.Resources>

<syncfusion:SfListView x:Name="ToDoListView" ItemSize="60" IsStickyHeader="True" IsScrollBarVisible="False"
  ItemsSource="{Binding ToDoList}" DragStartMode="OnHold,OnDragIndicator" SelectionMode="None">

    <syncfusion:SfListView.DragDropController>
        <syncfusion:DragDropController UpdateSource="True"/>
    </syncfusion:SfListView.DragDropController>

    <syncfusion:SfListView.ItemTemplate>
        <DataTemplate>
            <code>
            . . .
            . . .
            <code>
        </DataTemplate>
    </syncfusion:SfListView.ItemTemplate>
</syncfusion:SfListView>

C#:
ListView.ItemDragging += ListView_ItemDragging;

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

Converter:
public class IndexConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null) return 0;

        var item = value as ToDoItem;
        var listView = parameter as SfListView;
        return listView.DataSource.DisplayItems.IndexOf(item);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
```
