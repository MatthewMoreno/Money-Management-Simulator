using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokerageAccount : Account {

    private List<Asset> assets;

    public BrokerageAccount( double startingBalance ) {
        balance = startingBalance;
        assets = new List<Asset>();
        mayDeposit = true;
        mayWithdraw = false;
    }

    public bool BuyAsset( Asset asset ) {
        if( CanWithdraw( asset.Cost() ) ) {
            balance -= asset.Cost();
            assets.Add( asset );
            return true;
        }
        return false;
    }

    public override void AdvanceMonth() {

    }

}
