using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DecreaseSizeOfMissleSpawner : MonoBehaviour
{
    public BoxCollider missleSpawnerArea;

    public float lerpedValue;
    public float decreaseAreaDuration = 3;
    private void Awake()
    {
        
    }
    private void Start()
    {
        missleSpawnerArea = this.GetComponent<BoxCollider>();
        

        StartCoroutine(DecreaseArea(70,1));
    }
    IEnumerator DecreaseArea(float startValue, float endValue)
    {
        float timeElapsed = 0;

        while (timeElapsed < decreaseAreaDuration)
        {
            lerpedValue = Mathf.Lerp(startValue, endValue, timeElapsed / decreaseAreaDuration);
            missleSpawnerArea.size = new Vector3(lerpedValue, 22.56f, lerpedValue);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        lerpedValue = endValue;
    }
}
