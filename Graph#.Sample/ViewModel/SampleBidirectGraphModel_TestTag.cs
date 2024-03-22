using System;
using GraphSharp.Sample.Model;
using Scraper.ViewModel.Logs;

namespace GraphSharp.Sample.ViewModel
{
	public class SampleBidirectGraphModel_TestTag : IGraphGenerator
	{
		public GraphModel Generate()
		{
			var graph = new PocGraph();

			var from = new PocVertex("Force", 32);
			graph.AddVertex(from);
			Add(graph, from, TestTagViewModel.Create(), 0, 16);

			return new GraphModel("Fa", graph);
		}

	    private void Add(PocGraph graph, PocVertex from, TestTagViewModelCollection tags, int level, int fontsize)
	    {
	        if (tags == null)
			{
	            return;
			}
	        if (level > 2)
	        {
	            return;
	        }
	        foreach (TestTagViewModel model in tags)
	        {
	            var to = new PocVertex(model.Text, fontsize);
	            graph.AddVertex(to);
	            graph.AddEdge(new PocEdge(Guid.NewGuid().ToString(), from, to));

	            Add(graph, to, model.Tags, level + 1, fontsize / 2);
	        }
		}
	}
}