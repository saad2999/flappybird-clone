using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public player players;
    public GameObject Oprefab;
    float maxheight = 2.5f;
    float minheight = -2.5f;
    public float upper = 9f;
    public float lowwer =-5.5f ;
    
    Vector3 spwanpos = new Vector3(18f, 0, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        players = FindObjectOfType<player>();
       
            InvokeRepeating(nameof(obstaclespawn), 2, 7);
        // making gap between pipes Ajustable in inspector
        GameObject top = Oprefab.transform.GetChild(1).gameObject;
        GameObject bottom= Oprefab.transform.GetChild(0).gameObject;
        GameObject score= Oprefab.transform.GetChild(2).gameObject;
        top.transform.position = new Vector3(top.transform.position.x, upper, top.transform.position.z);
        bottom.transform.position = new Vector3(bottom.transform.position.x, lowwer, bottom.transform.position.z);
        score.GetComponent<BoxCollider>().size = new Vector3(score.GetComponent<BoxCollider>().size.x, (upper + lowwer) + 1.12f, score.GetComponent<BoxCollider>().size.z);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void obstaclespawn()
    {
        if (!players.isgameover)
        {
            
            spwanpos = new Vector3(18f, 0, 0);
            spwanpos.y = spwanpos.y + Random.Range(maxheight, minheight);

            Instantiate(Oprefab, spwanpos, Oprefab.transform.rotation);
        }
            
        
            
    }
}
