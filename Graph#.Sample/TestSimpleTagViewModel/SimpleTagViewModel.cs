namespace GraphSharp.Sample.ViewModel
{
	public class SimpleTagViewModel
	{
		public string Text { get; set; }
		public SimpleTagViewModelCollection Tags { get; set; }

		public SimpleTagViewModel(string text)
		{
			Text = text;
			Tags = null;
		}

		public SimpleTagViewModel(string text, SimpleTagViewModelCollection simpleTags)
		{
			Text = text;
			Tags = simpleTags;
		}

		public static SimpleTagViewModelCollection Create()
		{
			SimpleTagViewModelCollection tags = new SimpleTagViewModelCollection();

			var Barbra = new SimpleTagViewModel("Barbra");
			var John = new SimpleTagViewModel("John");
			var Caroline = new SimpleTagViewModel("Caroline");

			John.Tags = new SimpleTagViewModelCollection { Barbra, Caroline };
			Barbra.Tags = new SimpleTagViewModelCollection { John };

			tags.Add(Barbra);
			tags.Add(John);
			tags.Add(Caroline);

			return tags;
		}
	}
}