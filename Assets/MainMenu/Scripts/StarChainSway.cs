using UnityEngine;

public class StarChainSwing : MonoBehaviour
{
    public GameObject pivotObject; // The GameObject to use as the pivot point
    public Vector3 pivotPointOffset; // Offset from the pivotObject position

    public float swingSpeed = 2f; // Speed of swing
    public float swingAngle = 30f; // Maximum angle of swing

    private Quaternion baseRotation; // Initial rotation of the star

    void Start()
    {
        // Calculate the initial rotation of the star relative to the pivot point
        Vector3 pivotPoint = pivotObject.transform.position + pivotPointOffset;
        Vector3 directionToPivot = transform.position - pivotPoint;
        baseRotation = Quaternion.FromToRotation(Vector3.up, directionToPivot);
    }

    void Update()
    {
        // Calculate the rotation angle using a sine wave
        float angle = Mathf.Sin(Time.time * swingSpeed) * swingAngle;

        // Apply the rotation to the star relative to the pivot point
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward) * baseRotation;
    }
}
