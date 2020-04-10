using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestController : MonoBehaviour
{
    #region Properties
    [SerializeField] GameObject ObjectPrefab = null;
    [SerializeField] TextMeshProUGUI txtFPS = null;
    [SerializeField] TextMeshProUGUI txtActiveObj = null;
    [SerializeField] TextMeshProUGUI txtEventCount = null;
    [SerializeField] TextMeshProUGUI txtEventSecond = null;
    [SerializeField] TextMeshProUGUI txtMessageCount = null;
    [SerializeField] TextMeshProUGUI txtMessageSecond = null;

    public static long eventCount = 0;
    public static long messageCount = 0;

    private bool is_eventActive = true;
    private long eventLastSec = 0;
    private long messageLastSec = 0;
    private float timeSeconds = 1;
    private int framesSecond = 0;

    List<Example> objList = new List<Example>();

    #endregion

    #region Events
    void Start()
    {
        txtFPS.SetText("0");
        txtActiveObj.SetText("0");
        txtEventCount.SetText("0");
        txtEventSecond.SetText("0");
        txtMessageCount.SetText("0");
        txtMessageSecond.SetText("0");
    }

    void Update()
    {
        CheckInput();

        CallEvents();

        UpdateUI();
    }

    public void ActivateEvents()
    {
        is_eventActive = true;
    }

    public void DeactivateEvents()
    {
        is_eventActive = false;
    }

    public void ClearData()
    {
        eventCount = 0;
        eventLastSec = 0;
        messageCount = 0;
        messageLastSec = 0;
        timeSeconds = 1f;
    }

    public void ClearObjects()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        objList.Clear();
    }

    public void ChangeObjects(int amount)
    {
        bool is_adding = (amount > 0);

        if (is_adding)
        {
            GameObject go;
            for (int i = 0; i < amount; i++)
            {
                go = Instantiate(ObjectPrefab);
                objList.Add(go.GetComponent<Example>());
                go.transform.parent = transform;
            }
        }
        else if (transform.childCount >= -amount)
        {
            for (int i = transform.childCount - 1; i >= transform.childCount + amount; i--)
            {
                objList.Remove(transform.GetChild(i).GetComponent<Example>());
                Destroy(transform.GetChild(i).gameObject);
            }
        }
        else
        {
            ClearObjects();
        }
    }
    #endregion

    #region Methods

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateEvents();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DeactivateEvents();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ClearData();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ClearObjects();
        }
    }

    void CallEvents()
    {
        if (is_eventActive && objList != null)
        {
            for (int i = 0; i < objList.Count; i++)
            {
                objList[i].MakeSomethingHappen();
            }
        }
    }

    void UpdateUI()
    {
        timeSeconds += Time.deltaTime;
        framesSecond++;

        //Dio: One second has passed
        if (timeSeconds >= 1f)
        {
            txtFPS.SetText((framesSecond).ToString("####0"));
            txtActiveObj.SetText(FormatNumber(transform.childCount));
            txtEventCount.SetText(FormatNumber(eventCount));
            txtEventSecond.SetText(FormatNumber(eventCount - eventLastSec));
            txtMessageCount.SetText(FormatNumber(messageCount));
            txtMessageSecond.SetText(FormatNumber(messageCount - messageLastSec));

            timeSeconds -= 1f;
            framesSecond = 0;
            eventLastSec = eventCount;
            messageLastSec = messageCount;
        }
    }

    #endregion

    #region Functions
    string FormatNumber(long number)
    {
        return number.ToString("###,###,###,###,##0");
    }
    #endregion
}
