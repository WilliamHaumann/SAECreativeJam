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

    public float force;
    public float explosionRadius;

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
            Invoke("sideHoleExplosion",0);
        }

    }

    public void roll(float rollValue, float rollTime)
    {
        LeanTween.rotateX(plane.gameObject, rollValue, rollTime);
    }
    public void Pitch(float pitchValue, float pitchTime)
    {
        LeanTween.rotateZ(plane.gameObject, pitchValue, pitchTime);
    }
    public void sideHoleExplosion()
    {
        sidehole.constraints = RigidbodyConstraints.None;
        sidehole.AddExplosionForce(force, explosionPos.position, explosionRadius);
    }
    public void noseExplosion(Vector3 force)
    {
        
    }
}
