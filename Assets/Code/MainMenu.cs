using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
  
        // الدالة دي هتتنفذ لما نضغط على زرار Play
        public void PlayGame()
        {
            // تحميل المشهد بتاع الجيم باستخدام الاسم أو رقم الـ Index
            SceneManager.LoadScene("Demo_01");  // استبدل "GameScene" باسم مشهد اللعبة عندك
        }
    }
