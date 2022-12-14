using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scores : MonoBehaviour
{
    player Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            Player.scores++;
            Player.scoresIncrease = true;
        }
    }
}
