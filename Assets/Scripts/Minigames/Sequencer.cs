using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Sequencer : MonoBehaviour
{
    Animator animator;

    [SerializeField] int startingLength;
    List<int> sequence;
    int currentOrdinal;

    void Start()
    {
        animator = GetComponent<Animator>();

        sequence = new List<int>();
        GenerateSequence(startingLength);
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            PlaySequence();
        }
    }

    void GenerateSequence(int length)
    {
        for (int i = 0; i < length; i++)
        {
            IncreaseSequence();
        }
    }

    void IncreaseSequence()
    {
        sequence.Add(Random.Range(0, 3));
    }

    public int[] GetSequence()
    {
        return sequence.ToArray();
    }

    public void PlaySequence()
    {
        int[] sequenceArray = GetSequence();
        for (int i = 0; i < sequenceArray.Length; i++)
        {
            animator.SetTrigger("1Sec");
            StartCoroutine(WaitForAnimation());
            Debug.Log("Hola");
        }
    }

    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }
}
