using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    //public float strenght = 1f;
    public AnimationCurve strenght;
    public float duration = 5f;

    public float timeBetweenJumps = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu ("Shake")]
    public void Shake() {
        StartCoroutine(ShakeIt());
    }

    IEnumerator ShakeIt() {
        Vector3 initialPos = transform.position;
        float dur = 0f ;
        float x, y, z;
        
        while(dur <= duration) {
            float amp = strenght.Evaluate(dur / duration);
            x = Random.Range(0f, amp) - (amp * 0.5f);
            y = Random.Range(0f, amp) - (amp * 0.5f);
            z = Random.Range(0f, amp) - (amp * 0.5f);
            Vector3 randomPosition = new Vector3( x, y ,z);
            transform.position = initialPos + randomPosition;

            dur += Time.deltaTime;
            yield return null;
            //dur += timeBetweenJumps;
            //yield return new WaitForSeconds(timeBetweenJumps);
        }
        transform.position = initialPos;

        yield return null;

    }
}
