using System;
using GraphSharp.Sample.Model;

namespace GraphSharp.Sample.ViewModel
{
	public class SampleBidirectGraphModel_SimpleTag : IGraphGenerator
	{
		private static System.Collections.Generic.Dictionary<string, PocVertex> addedVertex;

		public GraphModel Generate()
		{
			addedVertex = new System.Collections.Generic.Dictionary<string, PocVertex> ();

			var graph = new PocGraph();
			Add(graph, null, SimpleTagViewModel.Create(), 0, 16);

			addedVertex.Clear();

			return new GraphModel("Fa", graph);
		}

		private static void Add(PocGraph graph, PocVertex from, SimpleTagViewModelCollection tags, int level, int fontsize)
		{
			if (tags == null || tags.Count == 0)
				return;

			if (level > 2)
				return;

			if (from == null)
				foreach (SimpleTagViewModel model in tags)
				{
					from = GetVertexFor(model.Text, fontsize);
					graph.AddVertex(from);

					Add(graph, from, model.Tags, level, fontsize);
				}
			else
				foreach (SimpleTagViewModel model in tags)
				{
					var to = GetVertexFor(model.Text, fontsize);
					graph.AddVertex(to);
					graph.AddEdge(new PocEdge(Guid.NewGuid().ToString(), from, to));

					var nextLevel = level + 1;

                    Add(graph, to, model.Tags, nextLevel, fontsize / 2);
				}
		}

		private static PocVertex GetVertexFor(string text, int fontSize)
		{
			bool vertexFound = addedVertex.TryGetValue(text, out var vertex);

			if (!vertexFound) vertex = new PocVertex(text, fontSize);

			return vertex;
		}
	}
}