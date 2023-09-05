using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField]
    int startingBalance = 200;

    [SerializeField]
    int currentBalance;
    public int CurrentBalance
    {
        get { return currentBalance; }
    }

    void Awake()
    {
        currentBalance = startingBalance;
    }

    public void Deposit(int amount)
    {
        // Mathf.Abs -> avoid negative numbers, only positive amount to calculate
        currentBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
    }
}
