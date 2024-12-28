using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health=4;
    public GameObject myPlayer;

    public void deletePlayer()
    {
        Destroy(myPlayer);

    }
}
