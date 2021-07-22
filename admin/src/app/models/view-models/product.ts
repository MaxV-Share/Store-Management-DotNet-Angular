
import { BaseViewModel ,ProductDetail} from "@app/models";

export class Product  extends BaseViewModel<number> {
    categoryId?: number = null;
    price?: number = null;
    code?: string = null;
    imageUrl?: string = null;
    details: ProductDetail[] = []
}
