using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController_2048 : MonoBehaviour
{
    public static GameController_2048 instance;

    public GameObject squarePanel;
    public GameObject infoPanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public enum GameState_2048
    {
        WELCOME,
        SETTING,
        GAMEING,
        GAMEOVER,
        QUIT
    }

    public GameState_2048 gameState_2048;

    private Square_Pri[] square_s;

    private void Start()
    {
        gameState_2048 = GameState_2048.WELCOME;
        square_s = new Square_Pri[16];

        for (int i = 0; i < 16; i++)
        {
            var tmpobj = squarePanel.transform.Find(string.Format("numberImage ({0})", i)).gameObject;
            if (tmpobj != null)
            {
                Debug.Log("tmpobj exist.");
                var tmpimage = tmpobj.GetComponent<Image>();
                var tmptext = tmpobj.transform.Find("Text").gameObject.GetComponent<Text>();

                if (tmpimage != null && tmptext != null)
                {
                    square_s[i] = new Square_Pri(tmpimage, tmptext);
                }

            }
        }
        int tmp_num = 2;
        foreach (var item in square_s)
        {
            item.number = tmp_num;
            tmp_num *= 2;
        }



    }

    public class Square_Pri
    {
        public Image numImage;
        public Text numText;

        private int m_number;

        public int number
        {
            get { return m_number; }
            set
            {
                m_number = value;
                if (m_number == 0)
                {
                    numImage.color = Color.gray;
                }
                else
                {
                    numImage.color = new Color(1f, ((int)Mathf.Log(m_number, 2) * 25 + 160) % 255 / 255f, 50f / 255f, 1f);
                }
                numText.text = m_number.ToString();
            }
        }
        public Square_Pri(Image image, Text text)
        {
            numImage = image;
            numText = text;
        }

    }
}
