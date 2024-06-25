using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataPage : MonoBehaviour
{
    [Header("View")]
    [SerializeField] private Slider _nationslider;
    [SerializeField] private Button _womanSexButton;
    [SerializeField] private Button _manSexButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Image _characterImage;
    [SerializeField] private TextMeshProUGUI _description;

    [Header("Model")]
    [SerializeField] private ShipRoleData _shipRoleData;

    private int _maxNationInex => _shipRoleData.ManVariantsSprites.Length - 1;
    private bool _isWoman = false;

    public DataPage Inizialize(ShipRoleData data)
    {
        _shipRoleData = data;
        _characterImage.sprite = data.ManVariantsSprites[0];
        _nationslider.maxValue = _maxNationInex;

        _womanSexButton.onClick.AddListener(SetWomanSex);
        _manSexButton.onClick.AddListener(SetManSex);
        _closeButton.onClick.AddListener(CloseTab);
        _nationslider.onValueChanged.AddListener(UpdateView);

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
        Destroy(gameObject);
    }

    public void UpdateView()
    {
        int index = (int)_nationslider.value;

        if (_isWoman)
        {
            _characterImage.sprite = _shipRoleData.WomanVariantsSprites[index];
        }
        else
        {
            _characterImage.sprite = _shipRoleData.ManVariantsSprites[index];
        }
    }

    public void UpdateView(float value)
    {
        int index = (int)value;

        if (_isWoman)
        {
            _characterImage.sprite = _shipRoleData.WomanVariantsSprites[index];
        }
        else
        {
            _characterImage.sprite = _shipRoleData.ManVariantsSprites[index];
        }
    }
}
