namespace Codenutz.XFLabs.Basics.Model
{
    public class Home
    {
        public Home(string _searchText, string _description, string _image)
        {
            this.OptionSearch = _searchText;
            this.Description = _description;
            this.Image = _image;
        }
        public string OptionSearch { private set; get; }
        public string Description { private set; get; }
        public string Image { private set; get; }
    }

}
