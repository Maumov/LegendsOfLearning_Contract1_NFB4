using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapRotate : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed;
    public enum RotationType { smooth, fixedRotation}
    public RotationType rotationType = RotationType.smooth;

    private void Update()
    {
        if(rotationType == RotationType.smooth)
        {
            Vector3 playerRotation = new Vector3(0f, 0f, player.rotation.z);
            Quaternion smooth = Quaternion.FromToRotation(transform.rotation.eulerAngles, playerRotation);
            transform.rotation = Quaternion.Lerp(transform.rotation, smooth, rotationSpeed * Time.deltaTime);
        }
    }

    private void LateUpdate()
    {
        if (rotationType == RotationType.fixedRotation)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, player.transform.rotation.z);
        }
    }
}