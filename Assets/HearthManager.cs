using UnityEngine;
using UnityEngine.UI;

public class HearthManager : MonoBehaviour
{
    public static int health = 3;
    public Image[] hearth;

    public Sprite FullHearth;
    public Sprite EmptyHearth;

    void Awake()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Image img in hearth)
        {
            img.sprite = EmptyHearth;
        }

        for (int i = 0; i < health; i++)
        {
            hearth[i].sprite = FullHearth;
        }
    }
}
