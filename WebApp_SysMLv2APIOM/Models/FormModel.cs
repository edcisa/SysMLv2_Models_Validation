namespace WebApp_SysMLv2APIOM.Models
{
    public class FormModel
    {
        public string Path { get; set; } = string.Empty;
        public string ParsedObjects { get; set; } = string.Empty;

        public string ParsedErrors { get; set; } = string.Empty;

        public List<Dictionary<string,string>> toPrintErrors { get; set; } = [];

        public Dictionary<string, string> toPrintSuggestions { get; set; } = new Dictionary<string, string>();

        public string Suggestions { get; set; } = string.Empty;

        public List<int> errorsIDs { get; set; } = [];
    }
}
