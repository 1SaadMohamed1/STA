using System.Collections;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float distance = 6f; // المسافة اللي هتتحركها العربية
    public float speed = 2f; // سرعة الحركة
    private Vector3 targetPosition;
    private bool isMoving = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // جلب الـ Rigidbody
        targetPosition = transform.position + transform.forward * distance;
        StartCoroutine(MoveCar());
    }

    IEnumerator MoveCar()
    {
        isMoving = true;
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            rb.MovePosition(newPosition); // تحريك السيارة باستخدام الفيزياء
            yield return null;
        }
        rb.MovePosition(targetPosition); // ضبط الموضع النهائي
        isMoving = false;
    }
}
