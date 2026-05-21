using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job {

    public GameEngine theGame;

    private Player employee;
    private Account depositAccount;
    private double salary;
    private bool fullTime;

    public Job( Player player, Account account, double pay, bool time ) {
        employee = player;
        depositAccount = account;
        salary = pay;
        fullTime = time;
    }

    public void PaySalary() {
        depositAccount.Deposit( salary );
    }

    public double GetSalary() {
        return salary;
    }

    public void SetDepositAccount( Account account ) {
        depositAccount = account;
    }

}
