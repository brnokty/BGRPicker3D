using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FinishHandler : MonoBehaviour
{
    [SerializeField] private Transform ObjectPos;
    [SerializeField] private List<Material> materials = new List<Material>();


    public void FinishEffect(Transform obj)
    {
        var rb = obj.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        obj.DOJump(ObjectPos.position + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)), 3f,
            1, 0.5f).OnComplete(() =>
        {
            rb.isKinematic = false;
            obj.GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Count)];
        });
    }

    public void FinishEffect(RaycastHit[] objects)
    {
        StartCoroutine(EffectCoroutine(objects));
    }

    private IEnumerator EffectCoroutine(RaycastHit[] objects)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            var obj = objects[i].transform;
            if (obj.GetComponent<Carriable>() != null)
            {
                var rb = obj.GetComponent<Rigidbody>();
                rb.isKinematic = true;
                obj.DOJump(ObjectPos.position, 3f, 1, 0.2f).OnComplete(() =>
                {
                    rb.isKinematic = false;
                    obj.GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Count)];
                });
                yield return new WaitForSeconds(0.2f);
            }
        }

        yield return new WaitForSeconds(0.5f);
        MainManager.Instance.EventRunner.Win();
    }
}