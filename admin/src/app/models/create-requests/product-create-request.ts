import { AutoMap } from "@automapper/classes";
import { BaseCreateRequest } from "..";
import { ProductDetailCreateRequest } from "./product-detail-create-request";

export class ProductCreateRequest extends BaseCreateRequest{
    @AutoMap()
    categoryId?: number;
    @AutoMap()
    price?: number;
    @AutoMap()
    code?: string;
    @AutoMap()
    imageUrl?: string;
    @AutoMap({ typeFn: () => ProductDetailCreateRequest })
    details: ProductDetailCreateRequest[]
}
