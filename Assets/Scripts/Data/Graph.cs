using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Graph<V>
{
    public Action<Vertex<V>> OnAddVertex;
    public Action<V> OnRemoveVertex;
    public Action<V, V, int> OnAddEdge;
    public Action<V, V> OnRemoveEdge;

    private List<Vertex<V>> _vertices;
    public List<Vertex<V>> Vertices
    {
        get => _vertices;
    }
    private Dictionary<V, Vertex<V>> _dataDictionary;
    public Dictionary<V, Vertex<V>> DataDictionary
    {
        get => _dataDictionary;
    }

    public Graph(List<Vertex<V>> vertices)
    {
        this._vertices = vertices;
        this._dataDictionary = new Dictionary<V, Vertex<V>>();
    }


    //to be used internally
    public bool AddVertex(Vertex<V> vertex)
    {
        // data should be unique
        if (_dataDictionary.ContainsKey(vertex.Data))
        {
            return false;
        }

        _vertices.Add(vertex);
        _dataDictionary.Add(vertex.Data, vertex);
        return true;
    }

    //to be used by frontend
    public bool AddVertex(V data)
    {
        Vertex<V> v = new Vertex<V>(data);
        if(AddVertex(v))
        {
            OnAddVertex?.Invoke(v);
            return true;
        }
        return false;
    }

    //to be used internally
    public void RemoveVertex(Vertex<V> v)
    {
        foreach (Vertex<V> u in v.Neighbors.Keys.ToList())
        {
            RemoveEdge(v, u);
        }
        _vertices.Remove(v);
        _dataDictionary.Remove(v.Data);
    }

    //to be used by frontend
    public void RemoveVertex(V v)
    {
        RemoveVertex(_dataDictionary[v]);
        OnRemoveVertex?.Invoke(v);
    }

    //to be used internally
    public bool AddEdge(Vertex<V> v1, Vertex<V> v2, int weight)
    {
        bool canAddAsNeighbors1 = v1.AddNeighbor(v2, weight);
        bool canAddAsNeighbors2 = v2.AddNeighbor(v1, weight);
        if(canAddAsNeighbors1 != canAddAsNeighbors2)
        {
            throw new BrokenGraphException("edge already exists for one vertex but not the other");
        }
        return canAddAsNeighbors1;
    }

    //to be used by frontend
    public bool AddEdge(V v1, V v2, int weight)
    {
        if(AddEdge(_dataDictionary[v1], _dataDictionary[v2], weight))
        {
            OnAddEdge?.Invoke(v1, v2, weight);
            return true;
        }
        return false;
    }


    public bool RemoveEdge(Vertex<V> v1, Vertex<V> v2)
    {
        if(ContainsEdge(v1, v2))
        {
            return v1.RemoveNeighbor(v2) && v2.RemoveNeighbor(v1); //exceptions can be added here.
        }
        return false; // if this point is reached, edge did not exist succesfull.
    }

    public bool RemoveEdge(V v1, V v2)
    {
        if(RemoveEdge(_dataDictionary[v1], _dataDictionary[v2]))
        {
            OnRemoveEdge?.Invoke(v1, v2);
            return true;
        }
        return false;
    }

    public bool ContainsEdge(Vertex<V> v1, Vertex<V> v2)
    {
        if(v1.HasNeighbor(v2) != v2.HasNeighbor(v1))
        {
            throw new BrokenGraphException("one vertex has other as neighbor but not the reverse");
        }
        return v1.HasNeighbor(v2);
    }

    public bool ContainsVertex(Vertex<V> vertex)
    {
        return _vertices.Contains(vertex);
    }

    public List<V> FindShortestPath(V v1, V v2)
    {
        throw new NotImplementedException();
        /*
        List<Vertex<V>> path = Dijkstra<V>.Run(_dataDictionary[v1], _dataDictionary[v2]); //checks need to be made to check if vertices exist in Dictionary!
        List<V> dataPath = new List<V>();
        foreach(Vertex<V> v in path)
        {
            dataPath.Add(v.Data);
        }
        return dataPath;*/
    }
}
