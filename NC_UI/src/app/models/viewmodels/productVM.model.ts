import { StatusEnm } from "../common/allEnums.model";
import { Product } from "../product.model";

export class ProductVM extends Product {
    statusName: string = '';

    constructor();
    constructor(product?: Product) {
        super();
        if (product != null)
        {
            this.id = product.id;
            this.name = product.name;
            this.price = product.price;
            this.status = product.status;
            this.createdDateTime = product.createdDateTime;
            this.modifiedDateTime = product.modifiedDateTime;
            this.statusName = StatusEnm[product.status];
        }
    }

}
