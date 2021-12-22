import { BaseViewModel } from "@app/models";
import { AutoMap } from "@automapper/classes";

export class Discount extends BaseViewModel {
    @AutoMap()
    id?: number;
    @AutoMap()
    percentDiscount: number
    @AutoMap()
    maxDiscountPrice: number
    @AutoMap()
    fromDate: Date
    @AutoMap()
    toDate: Date

}
