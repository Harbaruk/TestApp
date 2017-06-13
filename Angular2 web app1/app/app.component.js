"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var ProductComponent_1 = require('./ProductComponent');
var dataservice_1 = require('./dataservice');
//import { Ng2Bs3ModalModule } from 'ng2-bs3-modal/ng2-bs3-modal';
var AppComponent = (function () {
    function AppComponent(dataService) {
        this.dataService = dataService;
        this.products = [];
        this.curr_product = new ProductComponent_1.ProductComponent(0, 'all', 1, 'add', 'add');
        this.new_product = new ProductComponent_1.ProductComponent(0, 'all', 1, 'add', 'add');
    }
    AppComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.dataService.getJson('http://localhost:57608/phones/all/0/').subscribe(function (res) {
            res.phones.forEach(function (value, index) { return _this.products.push(new ProductComponent_1.ProductComponent(value.id, value.model, value.price, value.description, value.company)); });
        });
    };
    AppComponent.prototype.delete = function (id) {
        this.dataService.delete('http://localhost:57608/phones/delete/' + id).subscribe(function (res) {
            alert(res);
        });
    };
    ;
    AppComponent.prototype.edit = function (id) {
        this.curr_product = this.products[id];
    };
    AppComponent.prototype.update = function () {
        this.dataService.postJson('http://localhost:57608/phones/update', this.curr_product).subscribe(function (res) {
            alert(res);
        });
    };
    AppComponent.prototype.save = function () {
        this.dataService.postJson('http://localhost:57608/phones/add', this.new_product).subscribe(function (res) {
            alert(res);
        });
    };
    AppComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            templateUrl: 'app.component.html',
            styleUrls: ['app.component.css'],
            moduleId: module.id,
            providers: [dataservice_1.MyHttpService],
        }), 
        __metadata('design:paramtypes', [dataservice_1.MyHttpService])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map