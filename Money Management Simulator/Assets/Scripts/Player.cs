using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameEngine theGame;

    private int birthMonth;
    private int birthYear;
    private HashSet<Account> accounts;
    private HashSet<Loan> loans;
    private HashSet<LineOfCredit> linesOfCredit;
    private HashSet<Residence> residences;
    private HashSet<Job> jobs;
    private double charitableDonations;

    public Player( int month, int year ) {
        birthMonth = month;
        birthYear = year;
        residences = new HashSet<Residence>();
        accounts = new HashSet<Account>();
        loans = new HashSet<Loan>();
        linesOfCredit = new HashSet<LineOfCredit>();
        accounts.Add( new CheckingAccount( 5000.0 ) );
    }

    public Player( int month, int year, double startingBalance ) {
        birthMonth = month;
        birthYear = year;
        residences = new HashSet<Residence>();
        accounts = new HashSet<Account>();
        loans = new HashSet<Loan>();
        linesOfCredit = new HashSet<LineOfCredit>();
        accounts.Add( new CheckingAccount( startingBalance ) );
    }

    public void AdvanceMonth() {
        foreach( Job job in jobs ) {
            job.PaySalary();
        }
        foreach( Account account in accounts ) {
            account.AdvanceMonth();
        }
        foreach( Loan loan in loans ) {
            loan.AdvanceMonth();
        }
        foreach( LineOfCredit lineOfCredit in linesOfCredit ) {
            lineOfCredit.AdvanceMonth();
        }

    }

    public int GetAge( int month, int year ) {
        return ( year - birthYear ) * 12 + month - birthMonth;
    }

    public double GetNetWorth() {
        double total = 0.0d;
        foreach( Account account in accounts ) {
            total += account.GetBalance();
        }
        foreach( Residence residence in residences ) {
            total += residence.GetValue();
        }
        foreach( Loan loan in loans ) {
            total -= loan.GetBalance();
        }
        foreach( LineOfCredit line in linesOfCredit ) {
            total -= line.GetBalance();
        }
        return total;
    }

    public HashSet<Account> GetAccounts() {
        return accounts;
    }

    public HashSet<Residence> GetResidences() {
        return residences;
    }

    public Residence GetPrimaryResidence() {
        foreach ( Residence residence in residences) {
            if ( residence.IsPrimaryResidence() ) {
                return residence;
            }
        }
        return null;
    }

    public bool PurchaseResidence( List<Account> accountsToUse, List<double> costsToPay, Residence residence ) {
        for ( int i = 0; i < accountsToUse.Count; i++ ) {
            if ( !accountsToUse[i].Withdraw( costsToPay[i] ) ) {
                return false;
            }
        }
        if ( residence.IsPrimaryResidence() ) {
            GetPrimaryResidence().SetPrimaryResidence( false );
        }
        residences.Add( residence );
        return true;
    }

    private double GetTotalBalance() {
        double balance = 0.0;
        foreach ( Account account in accounts ) {
            balance += account.GetBalance();
        }
        return balance;
    }

    public void GetJob( Job job, Account depositAccount ) {
        jobs.Add( job );
        job.SetDepositAccount( depositAccount );
    }

    public double GetYearlySalary() {
        double total = 0.0;
        foreach ( Job job in jobs ) {
            total += job.GetSalary();
        }
        return total;
    }

    public double GetMonthlySalary() {
        double total = 0.0;
        foreach ( Job job in jobs ) {
            total += job.GetSalary() / 12.0;
        }
        return total;
    }

    public bool Remove( Account accountToRemove ) {
        return accounts.Remove( accountToRemove );
    }

    public bool Remove( Loan loanToRemove ) {
        return loans.Remove( loanToRemove );
    }

    public bool Remove( LineOfCredit line ) {
        return linesOfCredit.Remove( line );
    }

    public double GetCharitableDonations() {
        return charitableDonations;
    }

    public HashSet<Loan> GetLoans() {
        return loans;
    }

    public HashSet<LineOfCredit> GetLinesOfCredit() {
        return linesOfCredit;
    }

}
