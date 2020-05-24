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
        if (Input.GetKeyDown(KeyCode.A))
        {
            roll(40, 5);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            roll(-40, 5);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Pitch(40, 5);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Pitch(-40, 5);
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
    public void sideHoleExplosion(float force)
    {
        sidehole.AddForce(0, 0, force);
        sidehole.constraints = RigidbodyConstraints.None;
    }
    public void noseExplosion(float force)
    {
        nose.AddForce(0, force, force);
        nose.constraints = RigidbodyConstraints.None;
    }
}
