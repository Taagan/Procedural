using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBSP : MonoBehaviour
{
    Node root;
    public GameObject cubePrefab;
    List<Node> nodes = new List<Node>();
    public int generations = 3;
    public int height;
    public int width;
    public int zValue;

    private void Start()
    {
        root = new Node(new Vector2(width, height));
        BSP(root);
        Debug.Log(nodes.Count);
    }



    public void BSP(Node node)
    {
        GameObject cube = Instantiate(cubePrefab,new Vector3(node.position.x, node.position.y, -node.generation), Quaternion.identity);
        cube.transform.localScale = new Vector3(node.size.x,node.size.y,1);
        cube.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f,1f,1f,1f,0.5f,1f);
        cube.gameObject.name = node.generation.ToString();
        nodes.Add(node);

        //Debug.Log(node.generation);
        //Debug.Log("Position : " + node.position);

        Split(node);

    }


    public void Split(Node node)
    {
        if (node.generation >= generations)
            return;

        Node node1, node2;

        int split = 0;

        //split = Random.Range(0, 2);

        if (split == 0)
        {
            //Split vertically
            float splitPoint = Random.Range(node.origin.x, node.size.x);
            //splitPoint = Mathf.Pow(splitPoint,2);
            //splitPoint = Mathf.Sqrt(splitPoint);
            //Debug.Log("Position X : " + node.position);
            //Debug.Log("Size X : " + node.size);
            //Debug.Log("Verical : " + splitPoint);
            node1 = new Node(node, new Vector2(splitPoint,node.size.y), node.origin, node.generation + 1);
            node.children[0] = node1;
            node2 = new Node(node, new Vector2(node.size.x - splitPoint, node.size.y),new Vector2(node.origin.x + splitPoint, node.origin.y), node.generation + 1);
            node.children[1] = node2;
            BSP(node1);
            BSP(node2);
        }
        else
        {
            //Split horizontal
            float splitPoint = Random.Range(node.position.y, node.size.y);
            //Debug.Log("Horizontal : " + splitPoint);
            node1 = new Node(node, new Vector2(node.size.x,splitPoint), node.position, node.generation + 1);
            node.children[0] = node1;
            node2 = new Node(node, new Vector2(node.size.x,node.size.y - splitPoint), new Vector2(node.position.x, splitPoint), node.generation + 1);
            node.children[1] = node2;
            BSP(node1);
            BSP(node2);
        }
    }



}
