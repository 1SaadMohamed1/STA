using System.Collections;
using UnityEngine;

public class Carride : MonoBehaviour
{
    public Transform player; // مرجع اللاعب
    public float moveDistance = 19f; // المسافة قبل اللفة
    public float turnMoveDistance = 10f; // المسافة بعد اللفة
    public float moveSpeed = 2f; // سرعة الحركة
    public float exitOffset = 2f; // المسافة التي ينزل بها اللاعب على يمين السيارة

    private bool isMoving = false;
    private bool hasActivated = false; // منع التشغيل المتكرر
    private CharacterController playerController;
    private Rigidbody playerRigidbody;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isMoving && !hasActivated)
        {
            hasActivated = true; // تشغيل لمرة واحدة فقط
            StartCoroutine(RideSequence(other.transform));
        }
    }

    private IEnumerator RideSequence(Transform playerTransform)
    {
        isMoving = true;

        // تعطيل حركة اللاعب
        playerController = playerTransform.GetComponent<CharacterController>();
        playerRigidbody = playerTransform.GetComponent<Rigidbody>();

        if (playerController != null)
        {
            playerController.enabled = false;
        }
        else if (playerRigidbody != null)
        {
            playerRigidbody.isKinematic = true; // إيقاف أي قوة فيزيائية
        }

        // إخفاء اللاعب وجعله Child للعربية
        playerTransform.gameObject.SetActive(false);
        playerTransform.SetParent(transform);

        // تحرك للأمام (المسافة المحددة)
        yield return MoveCar(transform.forward * moveDistance);

        // لف 90 درجة لليمين
        yield return RotateCar(90f);

        // تحرك للأمام بعد اللفة (المسافة القابلة للتعديل)
        yield return MoveCar(transform.forward * turnMoveDistance);

        // حساب موضع النزول على يمين السيارة
        Vector3 exitPosition = transform.position + (transform.right * exitOffset) + new Vector3(0, 1, 0);

        // إخراج اللاعب وفصله عن العربية
        playerTransform.SetParent(null);
        playerTransform.position = exitPosition;
        playerTransform.gameObject.SetActive(true);

        // إيقاف أي حركة بعد النزول
        if (playerController != null)
        {
            yield return new WaitForSeconds(0.1f); // وقت بسيط لتفادي أي مشاكل في الفيزياء
            playerController.enabled = true;
        }
        else if (playerRigidbody != null)
        {
            playerRigidbody.isKinematic = false; // إعادة تشغيل الفيزياء
            playerRigidbody.velocity = Vector3.zero; // إيقاف أي حركة بعد النزول
            playerRigidbody.angularVelocity = Vector3.zero; // منع أي دوران غير مرغوب فيه
        }

        isMoving = false;
    }

    private IEnumerator MoveCar(Vector3 direction)
    {
        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos + direction;

        while (Vector3.Distance(transform.position, targetPos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator RotateCar(float angle)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = startRotation * Quaternion.Euler(0, angle, 0);
        float elapsedTime = 0f;
        float rotateDuration = 1f;

        while (elapsedTime < rotateDuration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / rotateDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
    }
}