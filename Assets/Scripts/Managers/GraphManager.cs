using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class GraphManager
{
    public Graph<VertexController> Graph { get; private set; }
    public List<EdgeController> EdgeControllers { get; private set; }

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

    public GraphManager()
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
}
