using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;
public class CollisionFuniture : MonoBehaviour
{
    [SerializeField]
    GameObject DrawerPanel;
    
    #region RUOut
    [SerializeField]
    GameObject OutPanel;
    [SerializeField]
    Button Yes;
    [SerializeField]
    Button No;
    #endregion

    public Button DoorBtn;
    Sprite DoorOpen;
    Sprite Door;

    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    void Start()
    {
        DoorOpen = Resources.Load( "inside", typeof(Sprite)) as Sprite;
        Door = Resources.Load( "Door", typeof(Sprite)) as Sprite;
        BindView();
    }

    void BindView()
    {
        Yes.OnClickAsObservable()
            .Subscribe(_ =>
            {
                //AudioManager.Inst.PlaySFX(SoundType.main_button_touch.ToString());
                SceneService.Instance.LoadScene(SceneName.OutSide);
                DoorEvent();
            })
            .AddTo(gameObject);

        No.OnClickAsObservable()
            .Subscribe(_ =>
            {
                //AudioManager.Inst.PlaySFX(SoundType.main_button_touch.ToString());
                OutPanel.SetActive(false);
                DoorEvent();
            })
                .AddTo(gameObject);
    }
    void DoorEvent()
    {
        if(OutPanel.activeSelf)
            DoorBtn.GetComponent<Image>().sprite = DoorOpen;
        else
            DoorBtn.GetComponent<Image>().sprite = Door;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // other : zone GameObject의 Collider2D Component만 인자로 넘어옴
        if (other.tag == "Funiture")
        {
            switch (other.gameObject.name)
            {
                case "Button (Door)":
                    DrawerPanel.SetActive(false);
                    OutPanel.SetActive(true);
                    break;
                case "Button (Drawer)":
                    OutPanel.SetActive(false);
                    DrawerPanel.SetActive(true);
                    break;
                case "Image(Floor)":
                    OutPanel.SetActive(false);
                    DrawerPanel.SetActive(false);
                    break;
            }
            DoorEvent();
            //Debug.Log($"[KHW] object Name is {other.gameObject.name}");
        }
        else
        {
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
