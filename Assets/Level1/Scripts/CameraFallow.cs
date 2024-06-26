using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // —сылка на объект игрока
    public float smoothing = 5f;

    private Vector3 offset;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target transform is not assigned.");
            return;
        }
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
