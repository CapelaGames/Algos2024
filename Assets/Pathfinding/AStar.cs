using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : Dijkstras
{
    protected void SetUpHeuristic()
    {
        foreach (Node nodeInScene in _nodesInScene)
        {
            nodeInScene.SetUpHeuristic(goalNode.transform.position);
        }
    }

    protected override bool RunAlgorithm(Node start, Node goal)
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
        SetUpHeuristic();
        while (unexplored.Count > 0)
        {
            unexplored.Sort((a,b)=>a.pathHeuristicWeight.CompareTo(b.pathHeuristicWeight));

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
