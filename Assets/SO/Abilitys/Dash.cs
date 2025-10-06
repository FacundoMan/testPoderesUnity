using UnityEditor.Callbacks;
using UnityEngine;
[CreateAssetMenu]
public class Dash : Ability
{
    public float dashVelocity;
    private Vector3 old;
    private Vector3 newVelocity;
    public override void Activate(GameObject parent)
    {
        Rigidbody rb = parent.GetComponent<Rigidbody>();
        old = parent.transform.forward;
        newVelocity = old * dashVelocity;
        rb.AddForce(old * dashVelocity, ForceMode.VelocityChange);
    }
    /*public override void Desactivate(GameObject parent)
    {
        Rigidbody rb = parent.GetComponent<Rigidbody>();
        rb.linearVelocity = new Vector3(old.x, rb.linearVelocity.y, old.z);
    }*/
}
