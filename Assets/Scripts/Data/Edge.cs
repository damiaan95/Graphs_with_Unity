public class Edge<V>
{
    private int weight;
    public int Weight
    {
        get { return weight; }
        private set { weight = value; }
    }

    private Vertex<V>[] vertices;

    public Vertex<V>[] Vertices
    {
        get { return vertices; }
    }

    public Edge(Vertex<V> v1, Vertex<V> v2, int weight)
    {
        this.vertices = new Vertex<V>[2] { v1, v2 };
        this.Weight = weight;
    }
}