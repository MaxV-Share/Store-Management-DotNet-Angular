import { Lang } from "./lang";
import { Product } from "./product";

export class ProductDetail {
    productId: number;
    product: Product;
    langId: string;
    name: string;
    description: string;
}
