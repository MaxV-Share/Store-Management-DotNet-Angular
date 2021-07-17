import { Base } from "../bases";
import { ProductDetail } from "./product-detail";

export class Product extends Base {
    categoryId?: number;
    price?: number;
    code?: string;
    imageUrl?: string;
    details: ProductDetail[]
}
