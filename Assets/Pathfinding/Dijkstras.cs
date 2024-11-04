using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstras : MonoBehaviour
{
    public Node startNode;
    public Node goalNode;

    protected Node[] _nodesInScene;

    protected void GetAllNodes()
    {
        _nodesInScene = FindObjectsOfType<Node>();
    }

    private void Awake()
    {
        GetAllNodes();
    }

    protected virtual void Start()
    {
        List<Node> path = FindShortestPath(startNode, goalNode);
        DebugPath(path);
    }

    public void DebugPath(List<Node> path)
    {
        for (int i = 0; i < path.Count -1; i++)
        {
            Debug.DrawLine(path[i].transform.position, 
                path[i + 1].transform.position,
                Color.green, 10f);
        }
    }

    public List<Node> FindShortestPath(Node start, Node goal)
    {
        if (RunAlgorithm(start, goal))
        {
            List<Node> results = new List<Node>();
            Node current = goal;
            do
            {
                results.Insert(0,current);
                current = current.previousNode;
            } while (current != null);
            return results;
        }
        return null;
    }

    protected virtual bool RunAlgorithm(Node start, Node goal)
    {
        List<Node> unexplored = new List<Node>();

        Node startNode = null;
        Node goalNode = null;

        foreach (Node nodeInScene in _nodesInScene)
        {
            nodeInScene.ResetNode();
            unexplored.Add(nodeInScene);

            if (start == nodeInScene)
            {
                startNode = nodeInScene;
            }
            if (goal == nodeInScene)
            {
                goalNode = nodeInScene;
            }
        }

        if (startNode == null || goalNode == null) return false;
        
        startNode.pathWeight = 0;
        while (unexplored.Count > 0)
        {
            unexplored.Sort((a,b)=>a.pathWeight.CompareTo(b.pathWeight));

            Node current = unexplored[0];
            unexplored.RemoveAt(0);

            foreach (Node neighbourNode in current.Neighbours)
            {
                if(!unexplored.Contains(neighbourNode)) continue;

                float neighbourWeight = Vector3.Distance(current.transform.position,
                    neighbourNode.transform.position);
                //  float neighbourWeight = (current.transform.position
                //               - neighbourNode.transform.position).sqrMagnitude;
                neighbourWeight += current.pathWeight;

                if (neighbourWeight < neighbourNode.pathWeight)
                {
                    neighbourNode.pathWeight = neighbourWeight;
                    neighbourNode.previousNode = current;
                }
            }

            if (current == goalNode) return true;
        }

        return false;
    }
}
