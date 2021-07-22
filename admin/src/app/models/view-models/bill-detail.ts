import { BaseViewModel } from "../bases";
import { ProductInBill } from "./product-in-bill";
export class BillDetail extends BaseViewModel<number> {
    productId?: number = null;
    product?: ProductInBill = null;
    price?: number = null;
    quantity?: number = null;
    discountPrice?: number = null;
}
