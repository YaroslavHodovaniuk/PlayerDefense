using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _template;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        foreach (var weapon in _weapons)
        {
            AddItem(weapon);
        }
    }

    private void AddItem(Weapon weapon)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.BuyButtonClick += OnBuyButtonClick;
        view.Render(weapon);
    }

    private void OnBuyButtonClick(Weapon weapon, WeaponView view)
    {
        TryBuyWeapon(weapon, view);
    }

    private void TryBuyWeapon(Weapon weapon, WeaponView view)
    {
        if (weapon.Price <= _player.Money)
        {
            _player.BuyWeapon(weapon);
            weapon.Buyed();
            view.BuyButtonClick -= OnBuyButtonClick;
        }
    }
}
