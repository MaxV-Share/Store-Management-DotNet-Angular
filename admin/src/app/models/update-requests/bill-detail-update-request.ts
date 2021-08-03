import { AutoMap } from "@automapper/classes";

export class BillDetailUpdateRequest {
    @AutoMap()
    id?: number;
    @AutoMap()
    productId?: number;
    @AutoMap()
    price?: number ;
    @AutoMap()
    quantity?: number ;
    @AutoMap()
    discountPrice?: number ;
}
