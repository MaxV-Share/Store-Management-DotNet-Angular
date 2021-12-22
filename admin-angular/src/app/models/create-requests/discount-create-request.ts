import { AutoMap } from "@automapper/classes";
import { BaseCreateRequest } from "..";

export class DiscountCreateRequest extends BaseCreateRequest{
    @AutoMap()
    percentDiscount: number
    @AutoMap()
    maxDiscountPrice: number
    @AutoMap()
    fromDate: Date
    @AutoMap()
    toDate: Date
}
