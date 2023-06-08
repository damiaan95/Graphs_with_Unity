using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GraphManager
{
    public Graph<VertexController> Graph { get; private set; }
    public List<EdgeController> EdgeControllers { get; private set; }

    private VertexController[] selectedVertices = new VertexController[2];

    private static GraphManager instance;
    public static GraphManager Instance 
    {
        get
        {
            if (instance == null)
            {
                instance = new GraphManager();
            }
            return instance;
        }
    }

    private GraphManager()
    {
        EdgeControllers = new List<EdgeController>();
        Graph = new Graph<VertexController>(new List<Vertex<VertexController>>());
    }

    public EdgeController GetEdge(VertexController v1, VertexController v2)
    {
        EdgeController edgeController = EdgeControllers.FirstOrDefault(t => t.Vertices.Contains(v1) && t.Vertices.Contains(v2));
        return edgeController;
    }

    // handles communication with Graph
    public bool AddEdge(VertexController v1, VertexController v2, int weight)
    {
        return Graph.AddEdge(v1, v2, weight);   
    }

    public void RemoveEdge(VertexController v1, VertexController v2)
    {
        EdgeController e = GetEdge(v1, v2);
        if(e != null)
        {
            Graph.RemoveEdge(v1, v2);
        } else
        {
            throw new Exception("Existing edge " + e + "did not exist in Graph Manager EdgeControllers list");
        }
    }

    // handles communication with Graph
    internal bool AddVertex(VertexController vertexController)
    {
        return Graph.AddVertex(vertexController);  
    }

    internal void RemoveVertex(VertexController vertexController)
    {
        Graph.RemoveVertex(vertexController);
    }

    internal void SelectVertex(VertexController vertexController)
    {
        if(selectedVertices.Contains(vertexController))
        {
            Debug.Log("vertex controller " + vertexController + " already selected");
            int i = selectedVertices[0].Equals(vertexController) ? 0 : 1;
            selectedVertices[i] = null;
            vertexController.SetAppearance(VertexAppearance.NORMAL);
            return;
        }

        if (selectedVertices[0] != null && selectedVertices[1] != null)
        {
            Debug.Log("cannot select more that two vertices");
            return;
        }

        int index = selectedVertices[0] == null ? 0 : 1;
        Debug.Log("vertex controller selected at index " + index);
        selectedVertices[index] = vertexController;
        vertexController.SetAppearance(VertexAppearance.SELECTED);
    }

    internal void RunAlgorithm()
    {
        if (selectedVertices[0] == null || selectedVertices[1] == null)
        {
            Debug.Log("cannot run Dijkstra without selected vertices");
            return;
        }

        EdgeControllers.ForEach(e =>
        {
            e.GetComponent<LineRenderer>().startColor = Color.white;
            e.GetComponent<LineRenderer>().endColor = Color.white;
        });

        List<VertexController> path = Graph.FindShortestPath(selectedVertices[0], selectedVertices[1]);
      
        for(int i = 0; i < path.Count - 1; i++)
        {
            VertexController from = path[i];
            VertexController to = path[i+1];
            Debug.Log(from + ", " + to);
            EdgeController edge = EdgeControllers.Find(e => e.Vertices.Contains(from) && e.Vertices.Contains(to));
            Debug.Log(edge);
            edge.GetComponent<LineRenderer>().startColor = Color.red;
            edge.GetComponent<LineRenderer>().endColor = Color.red; 
        }
    }
}
