using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataPage : MonoBehaviour
{
    public static ShipRoleData staticRoleData;
    [Header("View")]
    [SerializeField] private Button _nextNationButton;
    [SerializeField] private Button _womanSexButton;
    [SerializeField] private Button _manSexButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Image _characterImage;
    [SerializeField] private TextMeshProUGUI _description;

    [Header("Model")]
    [SerializeField] private ShipRoleData _defaultShipRoleData;

    private int nationIndex = 0;
    private int _maxNationInex => _defaultShipRoleData.ManVariantsSprites.Length - 1;
    private bool _isWoman = false;

    private void Start()
    {
        if (staticRoleData == null) staticRoleData = _defaultShipRoleData;
        Inizialize(staticRoleData);
    }

    public DataPage Inizialize(ShipRoleData data)
    {
        _defaultShipRoleData = data;
        _characterImage.sprite = data.ManVariantsSprites[0];

        _womanSexButton.onClick.AddListener(SetWomanSex);
        _manSexButton.onClick.AddListener(SetManSex);
        _closeButton.onClick.AddListener(CloseTab);
        _nextNationButton.onClick.AddListener(ChangeNation);

        return this;
    }

    public void SetManSex()
    {
        _isWoman = false;
        UpdateView();
    }

    public void SetWomanSex()
    {
        _isWoman = true;
        UpdateView();
    }

    public void CloseTab()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ChangeNation()
    {
        nationIndex++;

        if (nationIndex > _maxNationInex)
        {
            nationIndex = 0;
        }

        UpdateView();
    }

    public void ZoomPhoto()
    {
        if (_characterImage.transform.localScale.x > 1.5) return;
        _characterImage.transform.localScale = _characterImage.transform.localScale + Vector3.one / 10;
    }

    public void UnzoomPhoto()
    {
        if (_characterImage.transform.localScale.x == 1) return;
        _characterImage.transform.localScale = _characterImage.transform.localScale - Vector3.one/10;
    }

    public void UpdateView()
    {


        if (_isWoman)
        {
            _characterImage.sprite = _defaultShipRoleData.WomanVariantsSprites[nationIndex];
        }
        else
        {
            _characterImage.sprite = _defaultShipRoleData.ManVariantsSprites[nationIndex];
        }
    }
}
