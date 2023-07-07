using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector] public string keyString;
    [HideInInspector] public GameObject keyObject;

    public float cooldownTime;
    public float attackTime;
    private bool isActive;
    

    private List<string> ascii = new List<string>() {"A","B","C","D","E","F","G", "H",
        "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

    public GameObject AttackSpace;

    private void Start()
    {
        isActive = true;
        AttackSpace.SetActive(false);
    }

    private void Update()
    {
        if (isActive)
        {
            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key) && ascii.Contains(key.ToString()))
                {
                    keyString = key.ToString();
                    keyFeedback();
                }
            }
        }
    }

    void keyFeedback()
    {
        keyObject = transform.Find(keyString).gameObject;
        Debug.Log(keyString);
        StartCoroutine(Attack(attackTime));
        StartCoroutine(keyAnimation());

    }

    IEnumerator keyAnimation()
    {
        isActive = false;
        keyObject.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
        yield return new WaitForSeconds(cooldownTime);
        keyObject.transform.localScale = new Vector3(1f, 1f, 1f);
        isActive = true;
    }

    IEnumerator Attack(float time) //... or Jump!
    {
        AttackSpace.transform.position = keyObject.transform.position;
        AttackSpace.SetActive(true);
        yield return new WaitForSeconds(attackTime);
        AttackSpace.SetActive(false);
    }
}
