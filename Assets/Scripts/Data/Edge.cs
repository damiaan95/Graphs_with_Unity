/**
 * Not currently used!
 **/
public class Edge<V, E>
{
    private int weight;
    public int Weight
    {
        get { return weight; }
        private set { weight = value; }
    }

    private E data;
    public E Data
    {
        get { return data; }
        private set { data = value; }
    }

    // Maybe this use of an array can be used to represent also directed graphs.
    // Adopting the convention that index 0 is 'from' and index 1 is 'to' in the implementation of
    // an algorithm or other application might do the trick.
    private Vertex<V>[] vertices;

    public Vertex<V>[] Vertices
    {
        get { return vertices; }
    }

    public Edge(Vertex<V> v1, Vertex<V> v2, E data, int weight)
    {
        vertices = new Vertex<V>[2] { v1, v2 };
        Data = data;
        Weight = weight;
    }
}