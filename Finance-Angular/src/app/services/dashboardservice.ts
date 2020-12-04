import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';



@Injectable()

export class DashboardService{

    user:string="Nikita@123";

    constructor(private http: HttpClient) { }

    readonly Url = "https://localhost:44346/";

    getEmiCard(){
        return this.http.get(this.Url+"EMICard");
    }

    getPurchase(){
        return this.http.get(this.Url+"Purchase");
    }

    getAdmin(){
        return this.http.get(this.Url+"Admin");
    }

    /*putActivate(carddetails:Carddetails){
        return this.http.put(this.Url+"Activate",carddetails);
    }*/
}