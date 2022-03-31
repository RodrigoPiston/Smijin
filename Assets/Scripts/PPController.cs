using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PPController : MonoBehaviour
{
    private PostProcessVolume globalVolume;
    private Vignette colorEffect; 

    private void Awake()
    {
        globalVolume = GetComponent<PostProcessVolume>();
        globalVolume.profile.TryGetSettings(out colorEffect);         
    }

    IEnumerator Damage() 
    {
        colorEffect.color.value = Color.red;
        colorEffect.intensity.value = Mathf.Lerp(0.4f,0.2f,0.05f) ;
        yield return new WaitForSeconds(0.5f);
        colorEffect.color.value = Color.grey;
        //colorEffect.intensity.value =  ;
    }

    public void onDamage()
    {
        StartCoroutine(Damage());
    }
}
