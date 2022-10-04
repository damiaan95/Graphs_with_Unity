using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EdgeController : GraphElement
{
    VertexController v1;
    VertexController v2;

    public List<VertexController> Vertices { get; private set; }

    public int Weight { get; private set; }
    LineRenderer lr;
    bool isInitialized;
    EdgeCollider2D edgeCollider;
    List<Vector2> colliderPoints;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        lr = GetComponent<LineRenderer>();
        colliderPoints = new List<Vector2> { new Vector2(0,0), new Vector2(0,0) };
        edgeCollider = GetComponent<EdgeCollider2D>();
        edgeCollider.SetPoints(colliderPoints);
    }

    public void Initialize(VertexController v1, VertexController v2, int weight)
    {
        Weight = weight;
        this.v1 = v1;
        this.v2 = v2;
        Vertices = new List<VertexController>();
        Vertices.Add(v1);
        Vertices.Add(v2);
        isInitialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(v1 != null && v2 != null)
        {
            // not happy with this code. It might get expensive, and ideally
            // we don't run this if the position did not change.
            lr.SetPosition(0, v1.transform.position);
            lr.SetPosition(1, v2.transform.position);
            SetColliderPoints();
        } else if(isInitialized)
        {
            Destroy(gameObject);
        }
    }

    private void SetColliderPoints()
    {
        colliderPoints[0] = transform.InverseTransformPoint(new Vector3(lr.GetPosition(0).x, lr.GetPosition(0).y));
        colliderPoints[1] = transform.InverseTransformPoint(new Vector3(lr.GetPosition(1).x, lr.GetPosition(1).y));
        edgeCollider.SetPoints(colliderPoints);
    }

    public void OnClick(BaseEventData eventData)
    {
        PointerEventData pointerData = eventData as PointerEventData;
        if(pointerData.pointerId == -2)
        {
            GraphManager.Instance.RemoveEdge(v1, v2);
        }
    }

    public void DeleteEdge()
    {
        Destroy(gameObject);
    }
}
