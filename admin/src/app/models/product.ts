import { Base } from "./base";
import { ProductDetail } from "./product-detail";

export class Product extends Base {
    categoryId: number;
    price: number;
    urlImage: string;
    details: ProductDetail[]
}
