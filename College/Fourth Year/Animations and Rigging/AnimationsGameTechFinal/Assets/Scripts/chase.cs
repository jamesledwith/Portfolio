using UnityEngine;
using System.Collections;

public class chase : MonoBehaviour {

	public Transform player;
	public Animator anim;
    public float chaseSpeed = 0.05f;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 direction = player.position - this.transform.position;
		//float angle = Vector3.Angle(direction,this.transform.forward);
		//if(Vector3.Distance(player.position, this.transform.position) < 10 && angle < 30)
        if (Vector3.Distance(player.position, this.transform.position) < 20 )
		{
			
			
            //Vector3 direction = player.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                      Quaternion.LookRotation(direction), 2.5f * Time.deltaTime);

			anim.SetBool("isIdle",false);
			if(direction.magnitude > 4)
			{
				this.transform.Translate(0,0,chaseSpeed);
				anim.SetBool("isWalking",true);
				anim.SetBool("isAttacking",false);
			}
			else
			{
				anim.SetBool("isAttacking",true);
				anim.SetBool("isWalking",false);
			}

		}
		else 
		{
			anim.SetBool("isIdle", true);
			anim.SetBool("isWalking", false);
			anim.SetBool("isAttacking", false);
		}

	}
}
