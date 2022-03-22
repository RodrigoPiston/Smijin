using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]
public class ProgressBar : MonoBehaviour
{
    [SerializeField] public int maximum;
    [SerializeField] public int current;
    private float fillSmoothness = 0.001f;

    [SerializeField] Image mask;

    // Start is called before the first frame update
    void Update()
    {
        GetCurrentFill();
    }

    // Update is called once per frame
    void GetCurrentFill()
    {
        float prevFill = mask.fillAmount;
        float currFill = (float)current / maximum;
        if (currFill > prevFill) prevFill = Mathf.Min(prevFill + fillSmoothness, currFill);
        else if (currFill < prevFill) prevFill = Mathf.Max(prevFill - fillSmoothness, currFill);
        mask.fillAmount = prevFill;

    }
}
