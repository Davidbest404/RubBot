using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour
{
    public float Speed;
    public TextMeshProUGUI Text;
    public bool CloseCanvas = true;
    public GameObject Canvas;
    private bool Ended = false;

    void Update()
    {
        if (!Ended)
        {
            if (Text.alpha >= Speed * Time.deltaTime)
            {
                Text.alpha -= Time.deltaTime * Speed;
            }
            else
            {
                Ended = true;
                if (CloseCanvas)
                {
                    Text.alpha = 255;
                    Canvas.SetActive(false);
                }
            }
        }
    }
}
