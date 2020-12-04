import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../services/dashboardservice';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  card: any=[];
  purchase: any;
  card_arr:any = [];
  purchase_arr:any = [];
  i:number=0;
  j:number=0;
  pic:string="C:\Users\Abhi's Laptop\Desktop\LTI\GET 864\Angular\Project\src\assets\Images";
  activate:boolean=false;
  user="Nikita@123";

  constructor(private dashService: DashboardService) { }

  ngOnInit(): void {
    this.EmiCard();
  }

  EmiCard() {
    this.card = this.dashService.getEmiCard().subscribe(
      (data) => { this.card = data }
    );

    /*for(this.i=0;this.i<this.card_arr.length;this.i++){
      if(this.card_arr[this.i]["Username"] == this.user){
        this.card.push(this.card_arr[this.i]);
        break;
      }
    }*/
  }

  GetPurchase() {
    this.purchase = this.dashService.getPurchase().subscribe(
      (data) => { this.purchase = data }
    );
    
    /*for(this.j=0;this.j < this.purchase_arr.length;this.j++){
      if(this.card["user_ob"].CustomerID == this.purchase_arr[this.j]["purch_ob"].CustomerID){
        this.purchase.push(this.purchase_arr[this.j]);
      }
    }*/
  }


}
