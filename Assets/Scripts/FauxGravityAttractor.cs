using UnityEngine;
using System.Collections;

public class FauxGravityAttractor : MonoBehaviour {

public float gravity = -10;
    public Rigidbody myRigidbody;

    public void Attract(Transform body) {
        myRigidbody = GetComponent<Rigidbody> ();
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;

        myRigidbody.AddForce (gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation (bodyUp, gravityUp) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50f * Time.deltaTime);
    }
}
