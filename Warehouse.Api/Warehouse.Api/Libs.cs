namespace Warehouse.Api
{
    public class GridData
    {
        public int page { get; set; }
        public int total { get; set; }
        public object rows { get; set; }

        public GridData()
        {
        }
    }
}
