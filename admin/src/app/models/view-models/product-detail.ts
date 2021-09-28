import { BaseViewModel,Product } from "@app/models";
import { AutoMap } from "@automapper/classes";

export class ProductDetail extends BaseViewModel {
    @AutoMap()
    id?: number;
    @AutoMap()
    productId: number;
    @AutoMap()
    product: Product;
    @AutoMap()
    price?: number;
    @AutoMap()
    langId: string;
    @AutoMap()
    name: string;
    @AutoMap()
    description: string;
}
