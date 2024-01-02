namespace AlwasataNew.Services.App
{
    public class Common:ICommon
    {
        public List<string> GetCliecntSource()
        {
            return new List<string>()
            {
                "واتس اب",
                "فيسبوك",
                "يوتيوب",
                "انستغرام",
                "تيك توك",
                "تيلغرام",
                "داتا",
            };
        }
    }
}
