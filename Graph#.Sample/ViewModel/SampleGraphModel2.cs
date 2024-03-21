using System;
using GraphSharp.Sample.Model;

namespace GraphSharp.Sample.ViewModel
{
	public class SampleGraphModel2 : IGraphGenerator
	{
		private static System.Collections.Generic.Dictionary<string, Guid> addedTags;

		public GraphModel Generate()
		{
			addedTags = new System.Collections.Generic.Dictionary<string, Guid> ();

			var graph = new PocGraph();

			Add(graph, null, SimpleTagViewModel.Create(), 0, 16);

			addedTags.Clear();

			return new GraphModel("Fa", graph);
		}

		private static void Add(PocGraph graph, PocVertex from, SimpleTagViewModelCollection tags, int level, int fontsize)
		{
			if (tags == null || tags.Count == 0)
				return;

			if (level > 3)
				return;

			if (from == null)
				foreach (SimpleTagViewModel model in tags)
				{
					from = new PocVertex(model.Text, fontsize);
					graph.AddVertex(from);

					GetGuidFor(model.Text);

					Add(graph, from, model.Tags, level, level);
				}
			else
				foreach (SimpleTagViewModel model in tags)
				{
					var to = new PocVertex(model.Text, fontsize);
					graph.AddVertex(to);

					var destinationGuid = GetGuidFor(model.Text);

					graph.AddEdge(new PocEdge(destinationGuid.ToString(), from, to));

					Add(graph, to, model.Tags, level + 1, fontsize / 2);
				}
		}

		private static Guid GetGuidFor(string text)
		{
			bool guidFound = addedTags.TryGetValue(text, out var guid);

			if (!guidFound) guid = Guid.NewGuid();

			return guid;
		}
	}
}