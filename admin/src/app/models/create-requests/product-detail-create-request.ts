import { AutoMap } from "@automapper/classes";
import { BaseCreateRequest } from "..";

export class ProductDetailCreateRequest extends BaseCreateRequest {
    @AutoMap()
    productId: number ;
    @AutoMap()
    langId: string ;
    @AutoMap()
    name: string ;
    @AutoMap()
    description: string ;
}
