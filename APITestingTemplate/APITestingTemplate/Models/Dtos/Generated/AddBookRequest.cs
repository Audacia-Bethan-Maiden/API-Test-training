namespace APITestingTemplate.Models.Dtos
{
	[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v13.0.1.0)")]
	public partial class AddBookRequest 
	{
	    [Newtonsoft.Json.JsonProperty("title", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public string Title { get; set; }
	    [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public string Description { get; set; }
	    [Newtonsoft.Json.JsonProperty("author", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public string Author { get; set; }
	    [Newtonsoft.Json.JsonProperty("publishedYear", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public int? PublishedYear { get; set; }
	    [Newtonsoft.Json.JsonProperty("availableFrom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public System.DateTimeOffset? AvailableFrom { get; set; }
	    [Newtonsoft.Json.JsonProperty("hasEBook", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public bool? HasEBook { get; set; }
	    [Newtonsoft.Json.JsonProperty("bookCategoryId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
	    public int? BookCategoryId { get; set; }
	}
}
