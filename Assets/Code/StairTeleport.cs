using UnityEngine;
using System.Collections; 
public class StairTeleport : MonoBehaviour
{
    //public Transform secondFloorPoint;
    public float moveSpeed = 1.5f;

    public Transform pointA;
    public Transform pointB;
    public bool isMoving = false;
    private Transform player;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
            other.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;
            player = other.transform;
            MoveObject();
            //reset position
            //2 points for the player to translate between, points children for the elev.
            //StartCoroutine(MovePlayerToSecondFloor(other.transform));
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            player.position = Vector3.MoveTowards(player.position, pointB.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(player.position, pointB.position) < 0.01f)
            {
                isMoving = false;
            }
        }
    }
    private void MoveObject()
    {
        pointB = (pointB == pointA || pointB == null) ? pointB : pointA;
        isMoving = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
            //StartCoroutine(MovePlayerToSecondFloor(other.transform));
        }
    }
    /*IEnumerator MovePlayerToSecondFloor(Transform player)
    {
        Vector3 startPos = player.position;
        Vector3 endPos = secondFloorPoint.position;
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            player.position = Vector3.Lerp(startPos, endPos, (elapsedTime / 1f));
            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }
        player.position = endPos; // تأكيد التمركز بدقة في النهاية
    }*/
}