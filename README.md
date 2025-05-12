# How to bind the SQLite Database to the WinUI Chart (SfCartesianChart)

This example demonstrates how to show the SQLite database data to Chart. Please refer KB link for more details,

## Troubleshooting

#### Path too long exception

If you are facing a path too long exception when building this example project, close Visual Studio and rename the repository to a shorter name before building the project.

For more details, refer to the KB on [How to create custom legend items in WPF Chart?](https://www.syncfusion.com/kb/13689/how-to-bind-the-sqlite-database-to-the-winui-chart-sfcartesianchart).

Follow these steps to learn how to work with the WinUI Chart using the SQLite database.

**Step 1:** Add the  SQLite reference in your project. 

**Step 2:** Create the database access class as follows.

 ```

public class ChartDatabase
{
    readonly SQLiteConnection _database;

    public ChartDatabase(string dbPath)
    {
        _database = new SQLiteConnection(dbPath);
        _database.CreateTable<ChartDataModel>();
    }

    //Get the list of ChartDataModel items from the database
    public List<ChartDataModel> GetChartDataModel()
    {
        return _database.Table<ChartDataModel>().ToList();
    }

    //Insert an item in the database
    public int SaveChartDataModelAsync(ChartDataModel chartDataModel)
    {
        if (chartDataModel == null)
        {
            throw new Exception("Null");
        }

        return _database.Insert(chartDataModel);
    }

    //Delete an item in the database 
    public int DeleteChartDataModelAsync(ChartDataModel chartDataModel)
    {
        return _database.Delete(chartDataModel);
    }
}

```

```

public partial class App : Application
{
    static ChartDatabase database;
    …

    public static ChartDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new ChartDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ChartDataBase.db3"));
            }
            return database;
        }
    }
}

```

**Step 3:** Now, create the following Model for the Chart data.

```

public class ChartDataModel
{
        [PrimaryKey]
        public string XValue { get; set; }
        public double YValue { get; set; }
}

```

**Step 4:** Bind the retrieved data from the Database to the Chart.

```

<Page.DataContext>
    <local:ViewModel/>
</Page.DataContext>

<chart:SfCartesianChart>
    <chart:SfCartesianChart.XAxes>
        <chart:CategoryAxis/>
    </chart:SfCartesianChart.XAxes>
    <chart:SfCartesianChart.YAxes>
        <chart:NumericalAxis/>
    </chart:SfCartesianChart.YAxes>
    <chart:ColumnSeries ItemsSource="{Binding Data}" XBindingPath="XValue" YBindingPath="YValue"/>
</chart:SfCartesianChart>

```

**Step 5:** Retrieving the database data of Chart as follows.

```

public partial class ChartSample : ContentPage
{
      public ChartSample ()
      {
             InitializeComponent ();
             (DataContext as ViewModel).Data = App.Database.GetChartDataModel();
      }
}

```

## Output:

![Displaying the database data in a ListView](https://user-images.githubusercontent.com/53489303/197127843-4f05decc-e96b-43bc-ae62-1c72d67e8d4f.png)

_**Initial page to display the SQLite database data**_

![Inserting an data item in the database](https://user-images.githubusercontent.com/53489303/197127829-c7fef669-0a32-4dda-8398-d9a56366d014.png)

_**Inserting an item into the database**_

![Output after inserting a data into the database](https://user-images.githubusercontent.com/53489303/197127813-ca892a71-2ffd-48c7-9fa0-1153659dedf4.png)

_**After inserting data into the database**_

![Chart output based on the database data](https://user-images.githubusercontent.com/53489303/197127796-6850b42d-58f2-4bde-ad21-8f61fb368a47.png)

_**Display the chart with generated data**_

## See also

Refer our [feature tour](https://www.syncfusion.com/winui-controls/charts) page to know more features available in our charts.
