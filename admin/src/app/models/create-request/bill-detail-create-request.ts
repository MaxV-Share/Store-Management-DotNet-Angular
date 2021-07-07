import { Product } from "../product";
import { ProductDetail } from "../product-detail";

export class BillDetailCreateRequest {
    productId?: number;
    product?: ProductDetail;
    price?: number;
    quantity?: number;
    discountPrice?: number;
}
