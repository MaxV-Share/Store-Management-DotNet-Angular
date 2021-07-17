import { ProductDetail } from "../products/product-detail";

export class BillDetailCreateRequest {
    productId?: number;
    product?: ProductDetail;
    price?: number;
    quantity?: number;
    discountPrice?: number;
}
