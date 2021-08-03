import { BaseViewModel } from "../bases";
import { ProductDetail } from "./product-detail";
import { AutoMap } from "@automapper/classes";

export class Product  extends BaseViewModel {
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
    @AutoMap({ typeFn: () => ProductDetail })
    details: ProductDetail[]
}
