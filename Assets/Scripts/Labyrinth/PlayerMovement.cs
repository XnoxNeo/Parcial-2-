using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public LabyrinthSolver solver;

    public GameObject playerPrefab;
    private GameObject player;

    private List<NodeMaze> path;

    private void Start()
    {
        path = solver.path;
        if (path != null && path.Count > 0)
        {
            player = Instantiate(playerPrefab, new Vector3(path[0].Position.x, path[0].Position.y, 0), Quaternion.identity);
            StartCoroutine(MovePlayer());
        }
    }

    private IEnumerator MovePlayer()
    {
        foreach (NodeMaze node in path)
        {
            Vector2 targetPosition = new Vector2(node.Position.x, node.Position.y);
            while (Vector2.Distance(player.transform.position, targetPosition) > 0.1f)
            {
                player.transform.position = Vector2.MoveTowards(player.transform.position, targetPosition, 2f * Time.deltaTime);
                yield return null;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
