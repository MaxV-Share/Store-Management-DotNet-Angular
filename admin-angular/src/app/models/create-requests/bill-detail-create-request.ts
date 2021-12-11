import { BaseCreateRequest } from "@app/models";
import { AutoMap } from "@automapper/classes";
export class BillDetailCreateRequest extends BaseCreateRequest {
    @AutoMap()
    productId: number;
    @AutoMap()
    price: number;
    @AutoMap()
    quantity: number;
    @AutoMap()
    discountPrice: number;
}
