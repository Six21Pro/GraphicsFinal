using UnityEngine;
using System.Collections;

//for zombies driving on the x-y plane.

public class Drive1 : MonoBehaviour
{
    public GameObject target; // Reference to the target object (moving)
    public static float speed =0.05f; // Zombies speed
    public float stoppingDistance; // Distance at where the zombie stops 

    private Vector3 direction; // Direction to the target
    private Coords dirNormal; // Normalized direction to the target
    public Player player;

    private Vector3 bump = new Vector3(-4.0f, 0.0f, 0.0f);
    private Vector3 bumpUp = new Vector3(0.0f, 4.0f, 0.0f);
    private Vector3 bumpLeft = new Vector3(-4.0f, 0.0f, 0.0f);
    private Vector3 bumpRight = new Vector3(4.0f, 0.0f, 0.0f);
    private Vector3 bumpDown = new Vector3(0.0f, -4.0f, 0.0f);
    public float positionThreshold = 1.0f;//was 0.1f

    private void Start()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player"); // Find the target by tag (e.g., "Player")
            if (target == null)
            {
                Debug.LogError("Target not found! Make sure an object with the 'Player' tag exists.");
                return;
            }
        }

        if (player == null)
        {
            player = GameObject.FindWithTag("Player").GetComponent<Player>(); // Find the player by tag and get the Player component
            if (player == null)
            {
                Debug.LogError("Player not found! Make sure an object with the 'Player' tag and a Player component exists.");
                return;
            }
        }

        // Initial direction to the target
        direction = target.transform.position - this.transform.position;
        Coords vecCoordinates = new Coords(direction);
        dirNormal = MyMath.Normalize(vecCoordinates);
    }

    void Update()
    {
        if (target == null) return;

        // Calculate the distance to the target
        float distanceToTarget = Vector3.Distance(this.transform.position, target.transform.position);

        // Only move towards the target if it's farther than the stopping distance
        if (distanceToTarget > stoppingDistance)//I have stopping distance at zero, this is from an old program
        {
            // Recalculate direction to the target every frame
            direction = target.transform.position - this.transform.position;
            Coords vecCoordinates = new Coords(direction);
            dirNormal = MyMath.Normalize(vecCoordinates);

            // Move towards the target
            this.transform.position = this.transform.position + speed * dirNormal.ToVector();
        }


        if ((Vector3.Distance(target.transform.position, this.transform.position) <= positionThreshold) && (target.transform.position.x < this.transform.position.x))
        {
            target.transform.position = target.transform.position + bumpLeft;
            player.health = player.health - 1;
            TextChanger.livesRemaining = player.health;
            if (player.health == 0)
            {
                player.deletePlayer();
            }
        }
        if ((Vector3.Distance(target.transform.position, this.transform.position) <= positionThreshold) && (target.transform.position.x > this.transform.position.x))
        {
            target.transform.position = target.transform.position + bumpRight;
            player.health = player.health - 1;
            TextChanger.livesRemaining = player.health;
            if (player.health == 0)
            {
                player.deletePlayer();
            }
        }
        if ((Vector3.Distance(target.transform.position, this.transform.position) <= positionThreshold) && (target.transform.position.y < this.transform.position.y))
        {
            target.transform.position = target.transform.position + bumpUp;
            player.health = player.health - 1;
            TextChanger.livesRemaining = player.health;
            if (player.health == 0)
            {
                player.deletePlayer();

            }
        }
        if ((Vector3.Distance(target.transform.position, this.transform.position) <= positionThreshold) && (target.transform.position.y > this.transform.position.y))
        {
            target.transform.position = target.transform.position + bumpDown;
            player.health = player.health - 1;
            TextChanger.livesRemaining = player.health;
            if (player.health == 0)
            {
                player.deletePlayer();
            }
        }
    }
}