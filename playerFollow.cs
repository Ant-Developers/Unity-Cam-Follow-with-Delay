using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollow : MonoBehaviour
{
    #region Variables
    public Transform target;
    public float delay = 0.3f;
    public bool Delay;
    public bool SmoothMove;
    public float speed = 15;
    public Rigidbody2D camRigidbody;
    #endregion

    #region Functions

    void Update()
    {
        if(Delay && SmoothMove)
        {
            StartCoroutine("followDelaySmooth");
        }
        else if (Delay == true && SmoothMove == false)
        {
            StartCoroutine("follow");
        }
        else if(SmoothMove == true && Delay == false)
        {
            followSmooth();
        }
        else
        {
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
        rbSet();
    }

    public IEnumerator followDelaySmooth()
    {
        var i = 1;
        i = 1;
        yield return new WaitForSeconds(delay);
        while (i >= 1)
        {
            i--;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), speed * Time.deltaTime);
        }
    }

    public IEnumerator followDelay()
    {
        var i = 1;
        i = 1;
        yield return new WaitForSeconds(delay);
        while (i >= 1)
        {
            i--;
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }

    public void followSmooth()
    {
        var i = 1;
        i = 1;
        while (i >= 1)
        {
            i--;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), speed * Time.deltaTime);
        }
    }

    public void rbSet()
    {
        camRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        camRigidbody.isKinematic = true;
        camRigidbody.mass = 0f;
        camRigidbody.angularDrag = 0f;
        camRigidbody.drag = 0f;
        camRigidbody.gravityScale = 0;
    }

    #endregion
}
