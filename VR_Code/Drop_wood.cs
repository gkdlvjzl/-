using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_wood : MonoBehaviour
{
    [SerializeField] GameObject[] Tree;
    [SerializeField] GameObject last_tree;

    AudioSource Audio_tree;
    public int Re_tree = 10;
    int Num_tree;
    int i = 0;

    private void Start()
    {
        Num_tree = Tree.Length;
        Audio_tree = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (i >= (Num_tree - 1))
        {
            Invoke("RE_tree", Re_tree);
        }
    }

    void RE_tree()
    {
        Tree[i].SetActive(false);
        i = 0;
        Tree[i].SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("µµ³¢³¯"))
        {
            if (i < (Num_tree - 1))
            {
                Audio_tree.Play();
                Tree[i].SetActive(false);
                i++;
                Tree[i].SetActive(true);
            }
        }
    }
}
