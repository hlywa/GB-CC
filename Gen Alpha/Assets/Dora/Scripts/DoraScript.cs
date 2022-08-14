using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoraScript : MonoBehaviour
{
    public Animator animator;

    void Start(){
        animator = this.GetComponent<Animator>();
    }

    public void standup(){
        animator.SetBool("sit",false);
    }

    public void standdown(){
        animator.SetBool("sit",true);
        animator.SetBool("happy",false);
    }

    public void happy(){
        animator.SetBool("happy",true);
    }
}
