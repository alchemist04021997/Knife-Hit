using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] GameObject knifePrefab;
    public List<Image> knifeImage = new List<Image>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void CreatingKnife()
    {
        ClearKnife();
        GameObject go;
        for (int i = 0; i < GameplayManager.Instance.Board.numberKnife; i++)
        {
            go = Instantiate(knifePrefab);
            go.name = "knife" + i;
            go.transform.position += new Vector3(0, i * 30, 0);
            go.transform.SetParent(transform);
            knifeImage.Add(go.GetComponent<Image>());
        }
    }
    public void ChangeKnifeColorToBlack(int numberKnife)
    {
        if (numberKnife >= 0 && numberKnife < knifeImage.Count)
        {
            knifeImage[numberKnife].color = Color.black;
        }
    }
    public void ClearKnife()
    {
        for (int i = 0; i < knifeImage.Count; i++)
        {
            Destroy(knifeImage[i].gameObject);
        }
        knifeImage.Clear();
    }
}
