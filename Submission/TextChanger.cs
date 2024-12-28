using UnityEngine;
using UnityEngine.UI;  // Import the UI namespace
//not a test

public class TextChanger : MonoBehaviour
{
    // Reference to the Text component
    public Text Round;
    public Text TimeRemaining;
    public Text ZKCount;
    public Text lives;
    public static int livesRemaining = 4;
    public  int livesRemaining2 = 4;//used to restore value of livesRemaining
    private int kCount2;
    private float timer = 0f; // Timer variable to track time
    private float remainer = 0f; // Timer variable to track time
    public float interval = 20f; // Interval in seconds (30 seconds)
    private static int round = 2;
    public static int kCount = 0;
    
    //update will change the text dynamically
    private void Update()
    {

        timer += Time.deltaTime;
        remainer = 20f - timer;

        // If 20 seconds have passed, execute the method
        if (timer >= interval)
        {
            Round.text = "Round "+round;
            timer = 0f;
            round++;
        }
        TimeRemaining.text = "Time remaining: \n" + remainer;
        if (remainer==0) { 
            remainer = 20f; 
        }

        kCount2 = kCount;
        ZKCount.text ="Zombies killed: " +kCount2;
        livesRemaining2 = livesRemaining;
        lives.text = "Lives: " + livesRemaining;

    }
}
