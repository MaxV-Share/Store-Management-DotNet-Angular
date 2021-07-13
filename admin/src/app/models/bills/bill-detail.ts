import { ProductInBill } from "./product-in-bill";



export class BillDetail {
    productId?: number;
    product?: ProductInBill;
    price?: number;
    quantity?: number;
    discountPrice?: number;
}
