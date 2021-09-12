using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Node parent;
    public Node[] children;
    public Vector2 size;
    public Vector2 position;
    public int generation;

    private void Start()
    {
    }


    public Node(Vector2 size)
    {
        this.size = size;
        parent = null;
        position = Vector2.zero;
        children = new Node[2];
    }

    public Node(Node parent, Vector2 size, Vector2 position, int generation)
    {
        this.parent = parent;
        this.generation = generation;
        this.position = position;
        this.size = size;
        children = new Node[2];

    }
}
