using System.Collections;
using UnityEngine;

public class DissolveScript : MonoBehaviour
{
    [SerializeField]
    private float dissolveAmount;

    [SerializeField]
    private float dissolveSpeed;

    public bool isDissolving;

    [ColorUsage(true, true)]
    public Color fadeOutColor;

    [ColorUsage(true, true)]
    public Color fadeInColor;

    private Material material;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    public void DissolveOut()
    {
        material.SetColor("_OutlineColor", fadeOutColor);
        StartCoroutine(dissolveOutRoutine());
    }

    public void DissolveIn()
    {
        material.SetColor("_OutlineColor", fadeInColor);
        StartCoroutine(dissolveInRoutine());
    }

    private IEnumerator dissolveInRoutine()
    {
        dissolveAmount = 0;

        while (dissolveAmount < 1)
        {
            dissolveAmount += dissolveSpeed * Time.deltaTime;
            material.SetFloat("_DissolveAmount", dissolveAmount);
            yield return null;
        }
        material.SetFloat("_DissolveAmount", 1);

        yield return new WaitForEndOfFrame();
    }

    private IEnumerator dissolveOutRoutine()
    {
        dissolveAmount = 1;

        while (dissolveAmount > 0)
        {
            dissolveAmount -= dissolveSpeed * Time.deltaTime;
            material.SetFloat("_DissolveAmount", dissolveAmount);
            yield return null;
        }
        material.SetFloat("_DissolveAmount", 0);

        yield return new WaitForEndOfFrame();
    }
}