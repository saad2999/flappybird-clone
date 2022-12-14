using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveleft : MonoBehaviour
{
    public float speed = 10f;
    float leftbound = -30f;
    player myplayer;
    // Start is called before the first frame update
    void Start()
    {
        myplayer = FindObjectOfType<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!myplayer.isgameover)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);


            if (transform.position.x < leftbound && gameObject.CompareTag("obsticle"))
            {
                Destroy(gameObject);
            }
        }
            
        
    }
}
