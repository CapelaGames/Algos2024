using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollowPath : MonoBehaviour
{
    public AStar astar;
    public Node startNode;
    public Node endNode;
    private List<Node> path;
    void Start()
    {
         path = astar.FindShortestPath(startNode, endNode); 
         astar.DebugPath(path);
         StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        Node current = path[0];
        int i = 0;
        while (current != null)
        {
            Vector3 moveDirection = current.transform.position - transform.position;
            if (moveDirection.magnitude > 0.1f)
            {
                transform.position += moveDirection.normalized * (0.1f * Time.deltaTime);
            }
            else if (i == path.Count -1)
            {
                current = null;
            }
            else
            {
                i++;
                current = path[i];
            }
            yield return null;
        }
    }
}
