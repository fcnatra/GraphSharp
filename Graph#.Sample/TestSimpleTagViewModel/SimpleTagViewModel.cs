namespace GraphSharp.Sample.ViewModel
{
	public class SimpleTagViewModel
	{
		public string Text { get; set; }
		public SimpleTagViewModelCollection Tags  { get; set; }

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
			SimpleTagViewModelCollection tags = new SimpleTagViewModelCollection
			{
				new SimpleTagViewModel("1", new SimpleTagViewModelCollection
				{
					new SimpleTagViewModel("2", new SimpleTagViewModelCollection
					{
						new SimpleTagViewModel("1"),
						//new SimpleTagViewModel("Barbra")
					})
				}),
			};

			return tags;
		}
	}
}