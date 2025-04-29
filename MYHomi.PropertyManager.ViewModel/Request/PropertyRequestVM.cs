namespace MyHomi.PropertyManager.ViewModel.Request
{
    public class PropertyRequestVM
    {
        public string Id { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public int Area { get; set; }

        public string Type { get; set; } = string.Empty;

        public int Price { get; set; }
    }
}
