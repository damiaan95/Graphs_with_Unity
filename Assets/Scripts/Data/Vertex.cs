using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex<V>
{
    private Dictionary<Vertex<V>, int> neighbors;

    public Dictionary<Vertex<V>, int> Neighbors
    {
        get { return neighbors; }
    }
    private V data;

    public V Data
    {
        get { return data; }
        set { data = value; }
    }

    public Vertex(V data)
    {
        Data = data;
        neighbors = new Dictionary<Vertex<V>, int>();
    }

    public bool AddNeighbor(Vertex<V> v, int weight)
    {
        if(!neighbors.ContainsKey(v))
        {
            neighbors.Add(v, weight);
            return true;
        }
        return false;
    }

    public bool RemoveNeighbor(Vertex<V> v)
    {
        return neighbors.Remove(v);
        
    }
    public bool HasNeighbor(Vertex<V> v)
    {
        return neighbors.ContainsKey(v);
    } 




}
