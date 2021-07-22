import { BaseCreateRequest } from "@app/models";
export class BillDetailCreateRequest extends BaseCreateRequest {
    productId: number = null;
    price: number = null;
    quantity: number = null;
    discountPrice: number = null;
}
