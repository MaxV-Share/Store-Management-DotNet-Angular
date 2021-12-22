import { AutoMap } from "@automapper/classes";
import { BaseViewModel } from "../bases";
import { ProductInBill } from "./product-in-bill";
export class BillDetail extends BaseViewModel {
    @AutoMap()
    id?: number;
    @AutoMap()
    productId?: number;
    @AutoMap()
    product?: ProductInBill;
    @AutoMap()
    price?: number ;
    @AutoMap()
    quantity?: number ;
    @AutoMap()
    discountPrice?: number ;
}
