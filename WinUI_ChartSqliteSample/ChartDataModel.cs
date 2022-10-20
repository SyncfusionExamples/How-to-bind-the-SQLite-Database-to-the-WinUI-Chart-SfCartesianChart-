using SQLite;

namespace WinUI_ChartSqliteSample
{
    public class ChartDataModel
    {
        [PrimaryKey]
        public string XValue { get; set; }
        public double YValue { get; set; }
    }
}
