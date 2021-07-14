using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeHitReaction : MonoBehaviour
{
    public int HP;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
      
    }

    public void Hit() { 
            HP = HP - 1;
            if (HP <= 0) {
                Destroy(this.gameObject);
            
        }
    }
}
