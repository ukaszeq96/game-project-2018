using UnityEngine;
using System.Collections;

public class Mato : MonoBehaviour
{
    
    protected Animator anim;
    private GameObject mato;
    public float speed = 1f;
    public float pos = 0f;

    void Start()
    {
        anim = GetComponent<Animator>();
        mato = GameObject.FindWithTag("Worm");
        

    }

    void Update()
    {
        while(pos < 3.57f){
        mato.transform.Translate(0, speed * Time.deltaTime, 0);
    }


    }

    void FixedUpdate()
    {
        new WaitForSeconds(Random.Range(2, 9));
        anim.SetTrigger(name: "appear");
        new WaitForSeconds(Random.Range(3, 6));
        anim.SetTrigger(name: "disappear");
    }

}