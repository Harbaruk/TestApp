export class ProductComponent {
    Id: number;
    Model: string = 'Samsung'
    Price: number = 100;
    Description: string = 'Cool';
    Company: string;
    Category: number;

    constructor(id: number, name: string, price: number, descrip: string, comp: string) {
        this.Id = id;
        this.Model = name;
        this.Price = price;
        this.Description = descrip;
        this.Company = comp;
        this.Category = 0;
    }
}
