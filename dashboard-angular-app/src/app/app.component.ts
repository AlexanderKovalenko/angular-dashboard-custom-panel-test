import { Component } from '@angular/core';
import { createStore } from 'devextreme-aspnet-data-nojquery';
import CustomStore from 'devextreme/data/custom_store';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  serverUrl: string = "https://localhost:44396";
  store: CustomStore;
  dashboardId: string = "";

  constructor() {
    this.store = createStore({
        key: "productID",
        loadUrl: this.serverUrl + "/dashboardpanel/dashboards"
    });
  }

  onFocusedRowChanged(e: any) {
    if (e.row && e.row.key)
      this.dashboardId = e.row.key.toString();
  }  
}