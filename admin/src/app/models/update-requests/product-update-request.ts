import { AutoMap } from "@automapper/classes";
import { BaseUpdateRequest } from "..";
import { ProductDetailUpdateRequest } from "./product-detail-update-request";

export class ProductUpdateRequest extends BaseUpdateRequest  {
    @AutoMap()
    id?: number;
    @AutoMap()
    categoryId?: number;
    @AutoMap()
    price?: number;
    @AutoMap()
    code?: string;
    @AutoMap()
    imageUrl?: string;
    @AutoMap({ typeFn: () => ProductDetailUpdateRequest })
    details: ProductDetailUpdateRequest[]
}
