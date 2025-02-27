using UnityEngine;
using Fungus;

public class CashierInteraction : MonoBehaviour
{
   // public AudioSource alarmSound;  // صوت الإنذار
   // public CameraEffects cameraEffects; // سكريبت اهتزاز الكاميرا
    public Flowchart fungusFlowchart; // مرجع للـ Fungus Flowchart

   // private bool alarmTriggered = false; // التأكد من عدم تشغيل الإنذار أكثر من مرة

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") /*&& !alarmTriggered*/)
        {
            // Debug.Log("player");
           // alarmTriggered = true;
            //alarmSound.Play(); // تشغيل صوت الإنذار
           // StartCoroutine(cameraEffects.Shake(2f, 0.1f)); // تشغيل الاهتزاز
            fungusFlowchart.ExecuteBlock("EnterPassword"); // تشغيل الـ Dialogue
        }
    }
}
