using UnityEngine;
using System.Collections;
using System;
using static UnityEngine.GraphicsBuffer;
using System.Collections.Generic;

// A tank driving on the x-y axis.
//currently this code uses the arrowkeys to drive 

public class Drive : MonoBehaviour
{
    public float speed = 0.0f;//scalar
    private Vector2 direction = new Vector2(0.0f, 0.1f);//9/17
    private Vector2 directionU = new Vector2(0.0f, 0.1f);//x y directions for up
    //private Vector2 directionD = new Vector2(0.0f, -0.1f);//x y directionsv for down//commented out to support nesting
    private Vector2 directionR = new Vector2(0.1f, 0.0f);//x y directions for left
    //private Vector2 directionL = new Vector2(0.1f, 0.0f);//x y directions for right//commented out to support nesting <-I think
    private Vector3 bump =new Vector3(-4.0f,0.0f,0.0f);
    private Vector3 bumpUp = new Vector3(0.0f, 4.0f, 0.0f);
    private Vector3 bumpLeft = new Vector3(-4.0f, 0.0f, 0.0f);
    private Vector3 bumpRight = new Vector3(4.0f, 0.0f, 0.0f);
    private Vector3 bumpDown = new Vector3(0.0f, -4.0f, 0.0f);
    private List<GameObject> zombies = new List<GameObject>();  // List to store zombies
    private Vector3 collide=new Vector3(1.0f,1.0f,0.0f);
    public float positionThreshold = 1.0f;//was 0.1f
    public Player player;
    
    private KeyCode lastKeyPressed;
    public GameObject punch;

    private void Start()//Unused for now
    {//Coords vectorUp = new Coords(0, 1, 0);//9/19
        zombies.AddRange(ZManager.instance.enemies);
    }

    void Update()
    {

        foreach (GameObject heart in ZManager.instance.hearts)
        {
            if (heart != null && Vector3.Distance(this.transform.position, heart.transform.position) <= positionThreshold)
            {
                // If the player is close enough to the heart, destroy it
                ZManager.instance.deleteHeart(heart);  // This removes the heart from the list and destroys it
                player.health = player.health +1;
                TextChanger.livesRemaining = player.health;
                Debug.Log("health" + player.health);
                Debug.Log("Heart collected!");
                break; // Exit after first heart is collected (if there's only one heart to collect at a time)
            }
        }
        foreach (GameObject lightning in ZManager.instance.zaps)
        {
            if (lightning != null && Vector3.Distance(this.transform.position, lightning.transform.position) <= positionThreshold)
            {
                // If the player is close enough to the lightning, destroy it
                ZManager.instance.deleteLightning(lightning);  // This removes the lightning from the list and destroys it
                this.speed += 0.05f;
                Debug.Log("p speed" + this.speed);
                //Debug.Log("Heart collected!");
                break; // Exit after first lightning is collected (if there's only one lightning to collect at a time)
            }
        }




        Vector3 position = this.transform.position;
        if (Input.GetKey(KeyCode.W))
        {//was space
            float preventTooFast = directionU.y;
            directionU.y = directionU.y + speed;
            position.y = position.y + directionU.y;
            lastKeyPressed = KeyCode.W;

            Debug.Log("direction" + directionU.y);
            directionU.y = preventTooFast;
        }
        if (Input.GetKey(KeyCode.S))//Using elseif removes the ability to move diagonally
        {

            float preventTooFast = directionU.y;
            directionU.y = directionU.y + speed;
            position.y = position.y - directionU.y;

            Debug.Log("directionS" + directionU.y);
            directionU.y = preventTooFast;
            lastKeyPressed = KeyCode.S;
        }
        if (Input.GetKey(KeyCode.A))
        {
            float preventTooFast = directionR.x;
            directionR.x = directionR.x + speed;
            position.x = position.x - directionR.x;
            Debug.Log("directionL" + directionR.x);
            directionR.x = preventTooFast;
            lastKeyPressed = KeyCode.A; // position.y = position.y + directionR.y;//unnecessarey
        }
        if (Input.GetKey(KeyCode.D))
        {
            float preventTooFast = directionR.x;
            directionR.x = directionR.x + speed;
            position.x = position.x + directionR.x;
            Debug.Log("directionR" + directionR.x);
            directionR.x = preventTooFast;
            lastKeyPressed = KeyCode.D;
        }
        this.transform.position = position;

        // Handle punching action when the I key is pressed
        if (Input.GetKey(KeyCode.I))
        {
            zombies.Clear();  // Clear the existing list
            zombies.AddRange(ZManager.instance.enemies);  // Add the latest enemies

            Vector3 punchPosition = new Vector3(0, 0, 0);
            GameObject punchObject = Instantiate(punch, punchPosition, Quaternion.identity);

            // Determine punch position based on last key pressed (player direction)
            if (lastKeyPressed == KeyCode.D)
            {
                punchPosition = position + bumpRight;
            }
            if (lastKeyPressed == KeyCode.W)
            {
                punchPosition = position + bumpUp;
            }
            if (lastKeyPressed == KeyCode.S)
            {
                punchPosition = position + bumpDown;
            }
            if (lastKeyPressed == KeyCode.A)
            {
                punchPosition = position + bumpLeft;
            }
            punchObject.transform.position = punchPosition;
            Destroy(punchObject, 0.5f);

            List<GameObject> zombiesToRemove = new List<GameObject>();


            foreach (GameObject enemy in zombies)
            {
                Zombie zombie = enemy.GetComponent<Zombie>();

                    // Check if the punch hits the zombie (within distance threshold)
                    if (Vector3.Distance(punchObject.transform.position, enemy.transform.position) <= positionThreshold && (punchObject.transform.position.x < enemy.transform.position.x))
                    {
                        Debug.Log("Punch hit zombie: " + enemy.name);

                        // Remove zombie from the zombie list and delete it
                        zombie.transform.position = zombie.transform.position + bumpRight;
                        zombie.health -= 1;
                        if (zombie.health == 0)
                        {
                            zombiesToRemove.Add(enemy); // Add to removal list
                        }
                    }
                    if (Vector3.Distance(punchObject.transform.position, enemy.transform.position) <= positionThreshold && (punchObject.transform.position.x > enemy.transform.position.x))
                    {
                        Debug.Log("Punch hit zombie: " + enemy.name);

                        // Remove zombie from the zombie list and delete it
                        zombie.transform.position = zombie.transform.position + bumpLeft;
                        zombie.health -= 1;
                        if (zombie.health == 0)
                        {
                            zombiesToRemove.Add(enemy); // Add to removal list
                        }
                    }
               
            }

            foreach (GameObject enemy in zombiesToRemove)
            {
                ZManager.instance.UnregisterEnemy(enemy);//12/9
                zombies.Remove(enemy); // Remove from the list
                Destroy(enemy); // Destroy the zombie GameObject
                TextChanger.kCount++;

            }

        }
    }

}