using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{

    public Transform plane;

    public Rigidbody sidehole;
    public Rigidbody nose;
    public Rigidbody neck;
    public Rigidbody tail;
    public Rigidbody hip;

    public Transform explosionPos;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.init(1000);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            sideHoleExplosion(1000, 5);
        }

    }

    public void roll(float rollValue, float rollTime)
    {
        LeanTween.rotateX(plane.gameObject, rollValue, rollTime);
    }
    public void Yaw(float yawValue, float yawTime)
    {

    }
    public void Pitch(float pitchValue, float pitchTime)
    {
        LeanTween.rotateZ(plane.gameObject, pitchValue, pitchTime);
    }
    public void sideHoleExplosion(float force, float explosionRadius)
    {
        sidehole.constraints = RigidbodyConstraints.None;
        sidehole.AddExplosionForce(force,);
    }
    public void noseExplosion(Vector3 force)
    {
        
    }
}
