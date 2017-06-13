import { Injectable } from '@angular/core';
import { Component } from '@angular/core';
import { ProductComponent } from './ProductComponent';
import { MyHttpService } from './dataservice';
import { Ng2Bs3ModalModule } from 'ng2-bs3-modal/ng2-bs3-modal';


@Component({
    selector: 'my-app',
    templateUrl: 'app.component.html',
    styleUrls: ['app.component.css'],
    moduleId: module.id,
    providers: [MyHttpService],
})
export class AppComponent {
    products: ProductComponent[] = [];


    constructor(private dataService: MyHttpService) { }

    ngOnInit() {
        this.products.push(new ProductComponent('Iphone', 100, 'sss'));
        this.dataService.getJson('http://localhost:57608/phones/all/0/').subscribe(res => {
            res.phones.forEach((value: any, index: any) => this.products.push(new ProductComponent(value.model, value.price, value.Description)))

        });
    }


}
