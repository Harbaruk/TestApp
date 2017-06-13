import { Injectable } from '@angular/core';
import { Component } from '@angular/core';
import { ProductComponent } from './ProductComponent';
import { MyHttpService } from './dataservice';
//import { Ng2Bs3ModalModule } from 'ng2-bs3-modal/ng2-bs3-modal';


@Component({
    selector: 'my-app',
    templateUrl: 'app.component.html',
    styleUrls: ['app.component.css'],
    moduleId: module.id,
    providers: [MyHttpService],
})
export class AppComponent {
    products: ProductComponent[] = [];
    curr_product: ProductComponent;
    new_product: ProductComponent;

    constructor(private dataService: MyHttpService) {
        this.curr_product = new ProductComponent(0, 'all', 1, 'add', 'add');
        this.new_product = new ProductComponent(0, 'all', 1, 'add', 'add');
    }

    ngOnInit() {
        this.dataService.getJson('http://localhost:57608/phones/all/0/').subscribe(res => {
            res.phones.forEach((value: any, index: any) => this.products.push(new ProductComponent(value.id, value.model, value.price, value.description, value.company)))

        });
    }

    delete(id: number) {
        this.dataService.delete('http://localhost:57608/phones/delete/' + id).subscribe(res => {
            alert(res);
        })
    };

    edit(id: number) {
        this.curr_product = this.products[id];
    }

    update() {
        this.dataService.postJson('http://localhost:57608/phones/update', this.curr_product).subscribe(res => {
            alert(res);
        });
    }
    save() {
        this.dataService.postJson('http://localhost:57608/phones/add', this.new_product).subscribe(res => {
            alert(res);
        });
    }
}
