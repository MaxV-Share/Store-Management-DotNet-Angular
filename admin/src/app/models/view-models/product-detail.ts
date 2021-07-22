import { BaseViewModel,Product } from "@app/models";

export class ProductDetail extends BaseViewModel<number>  {
    productId: number = null;
    product: Product = null;
    price?: number = null;
    langId: string = null;
    name: string = null;
    description: string = null;
}
