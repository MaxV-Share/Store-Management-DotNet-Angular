import { AutoMap } from "@automapper/classes";
import { BaseViewModel } from "../bases";

export class ProductInBill extends BaseViewModel {
    @AutoMap()
    id?: number;
}
