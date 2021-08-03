import { AutoMap } from "@automapper/classes";
import { BaseUpdateRequest } from "..";
import { ProductUpdateRequest } from "./product-update-request";

export class ProductDetailUpdateRequest extends BaseUpdateRequest {
    @AutoMap()
    id?: number;
    @AutoMap()
    productId: number;
    @AutoMap()
    price?: number;
    @AutoMap()
    langId: string;
    @AutoMap()
    name: string;
    @AutoMap()
    description: string;
}
